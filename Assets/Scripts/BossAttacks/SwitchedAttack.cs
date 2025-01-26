using UnityEngine;

[CreateAssetMenu(fileName = "SwitchedAttack", menuName = "Scriptable Objects/SwitchedAttack")]
public class SwitchedAttack : BossAttack
{
    public GameObject switchPrefab;
    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);
        Instantiate(switchPrefab, bossTransform.position, Quaternion.identity);
    }
}
