using UnityEngine;

public class ShotgunAttack : MonoBehaviour
{
    public Attack attack;
    public GameObject circlePrefab;
    public Transform player;
    public int numberOfCircles = 5;
    public float spreadAngle = 45f; 
    public float shotInterval = 1f;

    private float shotTimer;

    void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= shotInterval)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    public void Shoot()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        float startAngle = baseAngle - spreadAngle / 2f;
        float angleStep = spreadAngle / (numberOfCircles - 1);

        for (int i = 0; i < numberOfCircles; i++)
        {
            float angle = startAngle + angleStep * i;
            float radian = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

            GameObject circle = Instantiate(circlePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
                rb.linearVelocity = direction * attack.speed;
            }
        }
    }
}
