using UnityEngine;

public class PulseAttack : MonoBehaviour
{
    public float minScale = 0.5f; // Minimum scale of the circle
    public float maxScale = 2.0f; // Maximum scale of the circle
    public float pulseSpeed = 2.0f; // Speed of the pulsing effect

    private Vector3 originalScale; // Original scale of the circle
    private bool expanding = true; // Whether the circle is currently expanding

    void Start()
    {
        // Store the original scale
        originalScale = transform.localScale;
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
    }
}
