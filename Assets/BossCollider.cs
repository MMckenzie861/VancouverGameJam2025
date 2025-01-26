using UnityEngine;
using System.Collections;
public class BossCollider : MonoBehaviour
{   
    public GameManager gameManager;

    public float damage = 1;

    public void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Orbital"))
        {
            Debug.Log("Boss Hit");

            gameManager.BossHit(damage);
        }
    }
}
