using UnityEngine;

public class PulseAttack : MonoBehaviour
{
    public float minScale = 0.5f; // Minimum scale of the circle
    public float maxScale = 2.0f; // Maximum scale of the circle
    public float pulseSpeed = 2.0f; // Speed of the pulsing effect
    public float moveSpeed = 2.0f;

    private Vector3 originalScale; // Original scale of the circle
    private bool expanding = true; // Whether the circle is currently expanding
    private Transform player;

    void Start()
    {
        // Store the original scale
        originalScale = transform.localScale;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Get the current scale
        float currentScale = transform.localScale.x;

        // Expand or shrink the circle
        if (expanding)
        {
            currentScale += pulseSpeed * Time.deltaTime;
            if (currentScale >= maxScale)
            {
                currentScale = maxScale;
                expanding = false; // Start shrinking
            }
        }
        else
        {
            currentScale -= pulseSpeed * Time.deltaTime;
            if (currentScale <= minScale)
            {
                currentScale = minScale;
                expanding = true; // Start expanding
            }
        }

        // Apply the new scale uniformly
        transform.localScale = new Vector3(currentScale, currentScale, 1f);
        ChasePlayer();
    }

    void ChasePlayer()
    {
        // Move towards the player when the collider is not a trigger
        if (player != null)
        {
            // Calculate direction to player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    // void /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    // void OnTriggerEnter2D(Collision2D other)
    // {
        // if (other.gameObject.CompareTag("Orbital")) {
        //     Destroy(gameObject);
        // }
    // }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orbital")) {
            Destroy(gameObject);
        }
    }
}
