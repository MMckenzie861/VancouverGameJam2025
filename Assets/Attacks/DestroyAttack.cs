using UnityEngine;

public class DestroyAttack : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
