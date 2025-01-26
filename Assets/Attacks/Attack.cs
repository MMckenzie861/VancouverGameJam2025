using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameManager gameManager;
    public float damage = 1;
    public float speed = 5;
    public float attackInterval = 1f;
    public float attackTimer = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                Debug.Log("Collision detected with Object: " + collision.gameObject.name);
                gameManager.Hit(damage);
                Debug.Log(gameManager.playerHealth);
        }
    }
}