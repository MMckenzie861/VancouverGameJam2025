using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // Prefab of the bubble
    public int maxBubbles = 50;    // Maximum number of bubbles
    public float spawnInterval; // Time between spawns
    public Vector2 spawnArea;     // The spawn area dimensions
    public float minBubbleSpeed;
    public float maxBubbleSpeed;
    public int prepopulatedBubbles;
    private int currentBubbleCount = 0;

    void Start()
    {
        // Prepopulate some bubbles at the start of the game
        for (int i = 0; i < prepopulatedBubbles; i++)
        {
            SpawnPrepopulatedBubble(); // Use the custom spawn method for prepopulated bubbles
        }
        InvokeRepeating(nameof(SpawnBubble), 0f, spawnInterval);
    }

    void SpawnBubble()
    {
        if (currentBubbleCount >= maxBubbles) return;

        // Generate a fixed X position or a random value for X within a range
        float randomX = Random.Range(-spawnArea.x, spawnArea.x); // Or change this to a fixed value if you want

        // Set Y spawn position to a fixed value
        float fixedY = spawnArea.y; // Set to any value you want for fixed Y (e.g., 0f or any other value in the spawn area)

        Vector3 spawnPosition = new Vector3(randomX, fixedY, 0f); // Use fixedY for Y position

        // Spawn the bubble prefab at the fixed position
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // Add upward velocity to the bubble
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Set the upward velocity
            float randomSpeed = Random.Range(minBubbleSpeed, maxBubbleSpeed);
            rb.linearVelocity = new Vector2(0f, randomSpeed); // Use .velocity instead of .linearVelocity
        }

        // Destroy the bubble after 10 seconds
        Destroy(bubble, 20f);

        // Increment the bubble count
        currentBubbleCount++;
    }

    void SpawnPrepopulatedBubble()
    {
        if (currentBubbleCount >= maxBubbles) return;

        // Generate a fixed X position or a random value for X within a range
        float randomX = Random.Range(-spawnArea.x, spawnArea.x); // Or change this to a fixed value if you want

        // Set Y spawn position to a fixed value (e.g., somewhere in the middle of the screen)
        float middleY = Random.Range(-4, 4); // Use this for the Y position in the middle of the spawn area

        Vector3 spawnPosition = new Vector3(randomX, middleY, 0f); // Use middleY for Y position

        // Spawn the bubble prefab at the fixed position
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);

        // Add upward velocity to the bubble
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Set the upward velocity
            float randomSpeed = Random.Range(minBubbleSpeed, maxBubbleSpeed);
            rb.linearVelocity = new Vector2(0f, randomSpeed); // Use .velocity instead of .linearVelocity
        }

        // Destroy the bubble after 20 seconds
        Destroy(bubble, 20f);

        // Increment the bubble count
        currentBubbleCount++;
    }
}
