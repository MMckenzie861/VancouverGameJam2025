using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    [SerializeField]    
    public List<BossAttack> attacks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PerformRandomAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PerformRandomAttack()
    {
        // Select a random attack
        int randomIndex = Random.Range(0, attacks.Count);
        BossAttack selectedAttack = attacks[randomIndex];

        // Execute the attack
        selectedAttack.PerformAttack(transform, GameObject.FindGameObjectWithTag("Player").transform);
    }
}
