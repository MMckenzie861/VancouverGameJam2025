using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SwitchedAttack", menuName = "Scriptable Objects/SwitchedAttack")]
public class SwitchedAttack : BossAttack
{
    public GameObject switchPrefab;
    public float cooldown; // Individual cooldown for this attack
    public int spawnAmount;
    public float offsetRange;
    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);

        for (int index = 0; index < spawnAmount; index++)
        {
            Vector3 randomOffset = new Vector3(
                   Random.Range(-offsetRange, offsetRange),
                   Random.Range(-offsetRange, offsetRange),
                   0f);

            // Calculate spawn position with random offset
            Vector3 spawnPosition = bossTransform.position + randomOffset;

            // Instantiate the prefab at the calculated position
            Instantiate(switchPrefab, spawnPosition, Quaternion.identity);
        }
      

        // Start the cooldown timer for this attack
        if (bossTransform.TryGetComponent(out MonoBehaviour monoBehaviour))
        {
            monoBehaviour.StartCoroutine(AttackCooldownRoutine());
        }
        else
        {
            Debug.LogError("Boss Transform does not have a MonoBehaviour to run coroutines!");
        }
    }

    private System.Collections.IEnumerator AttackCooldownRoutine()
    {
        // Wait for the duration of this attack's cooldown
        yield return new WaitForSeconds(cooldown);
      
        // Notify the parent (BossAttack) when the attack is done
        NotifyAttackComplete();
    }
}
