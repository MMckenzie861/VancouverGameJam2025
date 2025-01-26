using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Scriptable Objects/Shotgun")]
public class Shotgun : BossAttack
{
    public GameObject shotgunPrefab;
    public float cooldown;
    public Vector2 spawnArea;
    GameObject currentShotgun;

    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);

            Vector3 spawnPosition = new Vector3(spawnArea.x, spawnArea.y, 0f);
            currentShotgun = Instantiate(shotgunPrefab, spawnPosition, Quaternion.identity);

        

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
        Destroy(currentShotgun);
        // Notify the parent (BossAttack) when the attack is done
        NotifyAttackComplete();
    }
}
