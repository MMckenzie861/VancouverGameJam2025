using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class SwitchAttack : MonoBehaviour
{
    public float toggleInterval = 2.0f;  // Interval for toggling the collider and color
    public Color triggerColor = Color.green;  // Color when collider is a trigger
    public Color regularColor = Color.red; // Color when collider is regular
    public float colorTransitionSpeed = 2.0f; // Speed of the color transition

    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private bool isTrigger = false; // Initially, the collider is regular
    private Color currentTargetColor; // The target color for the transition
    private Color currentColor; // The current color of the sprite

    void Start()
    {
        // Get references to CircleCollider2D and SpriteRenderer
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial color to regular collider color
        currentColor = spriteRenderer.color;
        currentTargetColor = regularColor;
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
    }

    void ToggleCollider()
    {
        // Toggle between trigger and regular collider
        isTrigger = !isTrigger;
        circleCollider.isTrigger = isTrigger;

        // Set the target color for the transition based on the collider type
        currentTargetColor = isTrigger ? triggerColor : regularColor;
    }
}
