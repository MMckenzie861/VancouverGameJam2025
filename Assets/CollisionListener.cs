using UnityEngine;

// Abstract code to be attached to anything that can hit the player
public class CollisionListener : MonoBehaviour
{
    public GameManager gameManager;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected with Player: " + collision.gameObject.name);
            if (gameManager != null)
            {
                gameManager.Hit(damage);
            }
        }
    }
}
