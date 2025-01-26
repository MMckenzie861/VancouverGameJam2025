using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class SwitchAttack : MonoBehaviour
{
    public float toggleInterval = 2.0f;  // Interval for toggling the collider and color
    public Color triggerColor = Color.green;  // Color when collider is a trigger
    public Color regularColor = Color.red; // Color when collider is regular
    public float colorTransitionSpeed = 2.0f; // Speed of the color transition
    public float moveSpeed = 3.0f; // Movement speed of the object
    public float escapeDistance = 5.0f; // How far to try to escape from the player when in trigger mode

    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private bool isTrigger = false; // Initially, the collider is regular
    private Color currentTargetColor; // The target color for the transition
    private Color currentColor; // The current color of the sprite
    public float escapeSpeed = 0.8f;
    public float chaseSpeed = 4f;

    public Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        // Get references to CircleCollider2D and SpriteRenderer
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial color to regular collider color
        currentColor = spriteRenderer.color;
        currentTargetColor = regularColor;

        // Find the player in the scene (assumes the player object has a tag "Player")
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Update timer
        timer += Time.deltaTime;

        // Check if it's time to toggle the collider and color
        if (timer >= toggleInterval)
        {
            ToggleCollider();
            timer = 0f; // Reset the timer
        }

        // Gradually transition to the target color
        currentColor = Color.Lerp(currentColor, currentTargetColor, colorTransitionSpeed * Time.deltaTime);
        spriteRenderer.color = currentColor;

        // Move the object based on whether it's in trigger or regular mode
        if (isTrigger)
        {
            EscapeFromPlayer();
        }
        else
        {
            ChasePlayer();
        }
    }

    void ToggleCollider()
    {
        // Toggle between trigger and regular collider
        isTrigger = !isTrigger;
        circleCollider.isTrigger = isTrigger;

        // Set the target color for the transition based on the collider type
        currentTargetColor = isTrigger ? triggerColor : regularColor;
    }

    void ChasePlayer()
    {
        // Move towards the player when the collider is not a trigger
        if (playerTransform != null)
        {
            moveSpeed = chaseSpeed;
            // Calculate direction to player
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    void EscapeFromPlayer()
    {
        // Move away from the player when the collider is a trigger
        if (playerTransform != null)
        {
            moveSpeed = escapeSpeed;
            // Calculate direction away from player
            Vector3 direction = (transform.position - playerTransform.position).normalized;

            // Move away from the player
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, moveSpeed * Time.deltaTime);
        }
    }

    // void /// <summary>
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
