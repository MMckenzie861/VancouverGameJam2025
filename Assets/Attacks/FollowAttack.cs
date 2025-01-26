using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public Attack attack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * attack.speed * Time.deltaTime;
        }
    }
}
