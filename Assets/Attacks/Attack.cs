using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 1;
    public float speed = 5;
    public float attackInterval = 1f;
    public float attackTimer = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player destroyed!");
        }
    }
}
