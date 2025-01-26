using UnityEngine;
using System.Collections;
public class BossCollider : MonoBehaviour
{   
    public GameManager gameManager;

    public float damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boss"))
        {
            gameManager.BossHit(damage);
        }
    }
}
