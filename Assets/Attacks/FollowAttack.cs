using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public Attack attack;
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * attack.speed * Time.deltaTime;
        }
    }
}
