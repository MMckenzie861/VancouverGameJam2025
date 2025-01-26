using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "BombAttack", menuName = "Scriptable Objects/BombAttack")]
public class BombAttack : BossAttack
{
    public GameObject bombPrefab;
    public float cooldown;
    public Vector2[] spawnAreas;

    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);

        foreach (Vector2 spawnArea in spawnAreas)
        {
            Vector3 spawnPosition = new Vector3(spawnArea.x, spawnArea.y, 0f);
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

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
