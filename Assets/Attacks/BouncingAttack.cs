using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BouncingAttack : MonoBehaviour
{
    public Vector2 initialVelocity = new Vector2(5f, 5f); // Set the initial velocity
    public float rotationSpeed = 100f; // Rotation speed in degrees per second
    private Rigidbody2D rb;
    // public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = initialVelocity;

        // Ensure no drag or gravity affects the motion
        // rb.linearDamping = 0;
        // rb.angularDamping = 0;
        // rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Smooth collisions
        rb.angularVelocity = rotationSpeed;
        // gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

    }

    void Update()
    {
        // Ensure the velocity is constant
        rb.linearVelocity = rb.linearVelocity.normalized * initialVelocity.magnitude;
    }

    // void /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player")) {
    //         Debug.Log("HITTING player");
    //         gameManager.Hit(1);
    //     }
    // }
}
