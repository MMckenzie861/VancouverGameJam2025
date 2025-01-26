using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BombAttackVariant", menuName = "Scriptable Objects/BombAttackVariant")]
public class BombAttackVariant : BossAttack
{
    public GameObject bombPrefab;
    public float cooldown;
    public Vector2[] spawnAreas;
    public float spawnDelay;
    public override void PerformAttack(Transform bossTransform, Transform playerTransform) { 
   base.PerformAttack(bossTransform, playerTransform);

            // Start a coroutine to spawn bombs one by one
            if (bossTransform.TryGetComponent(out MonoBehaviour monoBehaviour))
            {
                monoBehaviour.StartCoroutine(SpawnBombsWithDelay());
                monoBehaviour.StartCoroutine(AttackCooldownRoutine());
            }
            else
    {
        Debug.LogError("Boss Transform does not have a MonoBehaviour to run coroutines!");
    }
        }

        private System.Collections.IEnumerator SpawnBombsWithDelay()
    {
        foreach (Vector2 spawnArea in spawnAreas)
        {
            Vector3 spawnPosition = new Vector3(spawnArea.x, spawnArea.y, 0f);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified delay before spawning the next bomb
            yield return new WaitForSeconds(spawnDelay);
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
