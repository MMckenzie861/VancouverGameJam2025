using UnityEngine;

[CreateAssetMenu(fileName = "BounceAttack", menuName = "Scriptable Objects/BounceAttack")]
public class BounceAttack : BossAttack
{
    public GameObject bounceObstaclePrefab;

    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);
        Instantiate(bounceObstaclePrefab, bossTransform.position, Quaternion.identity);
    }
}
