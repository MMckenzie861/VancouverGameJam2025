using UnityEngine;

[CreateAssetMenu(fileName = "PulsingAttack", menuName = "Scriptable Objects/PulsingAttack")]
public class PulsingAttack : BossAttack
{
    public GameObject pulsePrefab;
    public float cooldown;

    private GameObject currentPulse;
    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);

        // Spawn the pulsing prefab
        currentPulse = Instantiate(pulsePrefab, bossTransform.position, Quaternion.identity);

        // Start the cooldown timer for the attack
        if (bossTransform.TryGetComponent(out MonoBehaviour monoBehaviour))
        {
            monoBehaviour.StartCoroutine(AttackDurationRoutine());
        }
        else
        {
            Debug.LogError("Boss Transform does not have a MonoBehaviour to run coroutines!");
        }
    }

    private System.Collections.IEnumerator AttackDurationRoutine()
    {
        // Wait for the duration of the cooldown
        yield return new WaitForSeconds(cooldown);

        // Destroy the pulsing prefab after the cooldown
        if (currentPulse != null)
        {
            Destroy(currentPulse);
        }

        // Notify the parent (BossAttack) when the attack is done
        NotifyAttackComplete();
    }
}
