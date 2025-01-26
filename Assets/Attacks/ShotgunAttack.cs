using UnityEngine;

public class ShotgunAttack : MonoBehaviour
{
    public Attack attack;
    public GameObject circlePrefab;
    public Transform player;
    public int numberOfCircles = 5;
    public float spreadAngle = 45f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        attack.attackTimer += Time.deltaTime;

        if (attack.attackTimer >= attack.attackInterval)
        {
            Shoot();
            attack.attackTimer = 0f;
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
