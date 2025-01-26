using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "Scriptable Objects/ProjectileAttack")]
public class ProjectileAttack : BossAttack
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    public override void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        base.PerformAttack(bossTransform, playerTransform);
        GameObject projectile = Instantiate(projectilePrefab, bossTransform.position, Quaternion.identity);

      
        Vector2 direction = (playerTransform.position - bossTransform.position).normalized;

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
        else
        {
            projectile.transform.Translate(direction * projectileSpeed * Time.deltaTime);
        }

    }
}
