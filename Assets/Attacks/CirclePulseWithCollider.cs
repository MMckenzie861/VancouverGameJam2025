using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CirclePulseWithCollider : MonoBehaviour
{
    public float minScale = 0.5f; // Minimum scale of the circle
    public float maxScale = 2.0f; // Maximum scale of the circle
    public float pulseSpeed = 2.0f; // Speed of the pulsing effect

    private CircleCollider2D circleCollider; // Reference to the CircleCollider2D
    private SpriteRenderer spriteRenderer;   // Reference to the SpriteRenderer
    private float originalColliderRadius;    // Original radius of the collider
    private float originalSpriteSize;        // Diameter of the sprite in world units

    void Start()
    {
        // Get references
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original collider radius
        originalColliderRadius = circleCollider.radius;

        // Calculate the original sprite's diameter in world units (largest axis is used)
        originalSpriteSize = Mathf.Max(spriteRenderer.bounds.size.x, spriteRenderer.bounds.size.y);
    }

    void Update()
    {
        // Smooth pulsing effect using Mathf.Sin
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2);
        transform.localScale = new Vector3(scale, scale, 1f);

        // Update the collider's radius to match the sprite's size at the new scale
        float currentSpriteSize = originalSpriteSize * scale; // Calculate the current sprite size
        circleCollider.radius = (currentSpriteSize / 2f) / transform.localScale.x; // Set radius in proportion
    }
}
