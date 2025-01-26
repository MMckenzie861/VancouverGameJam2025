using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    [SerializeField]    
    public List<BossAttack> attacks;

    private bool isPerformingAttack = false;

    private BossAttack lastAttack = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var attack in attacks)
        {
            attack.Initialize(this);
        }
        PerformNextAttack();
    }

    void PerformNextAttack()
    {
        if (isPerformingAttack || attacks.Count == 0)
            return;
        BossAttack selectedAttack = null;
        if (attacks.Count == 1)
        {
            // If there's only one attack, just use it
            selectedAttack = attacks[0];
        }
        else
        {
            // Select a random attack, excluding the last one
            do
            {
                int randomIndex = Random.Range(0, attacks.Count);
                selectedAttack = attacks[randomIndex];
            }
            while (selectedAttack == lastAttack); // Keep picking until it's not the last attack
        }

        // Store the current attack as the last attack
        lastAttack = selectedAttack;

        // Execute the attack
        isPerformingAttack = true;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform != null)
        {
            selectedAttack.PerformAttack(transform, playerTransform);
        }
    }

    public void OnAttackComplete(BossAttack completedAttack)
    {
        Debug.Log($"{completedAttack.attackName} is complete. Selecting next attack.");
        isPerformingAttack = false;

        // Perform the next attack after the current one completes
        PerformNextAttack();
    }
}
