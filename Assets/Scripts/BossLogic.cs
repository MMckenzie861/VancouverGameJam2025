using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    [SerializeField]    
    public List<BossAttack> attacks;

    private bool isPerformingAttack = false;

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

        // Select a random attack
        int randomIndex = Random.Range(0, attacks.Count);
        BossAttack selectedAttack = attacks[randomIndex];
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
