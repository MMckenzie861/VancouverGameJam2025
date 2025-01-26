using UnityEngine;
using System.Collections;
public class BossCollider : MonoBehaviour
{   
    public GameManager gameManager;

    public float damage = 1;
   

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Boss Hit Orbital");

        Debug.Log("Orbital Hit Boss" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Orbital"))
        {
            Debug.Log("Boss Hit");

            gameManager.BossHit(damage);
        }
    }
}
