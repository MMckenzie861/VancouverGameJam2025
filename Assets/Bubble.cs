using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject popEffect; // Particle effect prefab to show on popping
    public Sprite[] bubbleSprites;
    public GameObject bubbleSFX;

    void Start()
    {
        bubbleSFX = GameObject.FindGameObjectWithTag("BubbleSFX");
        // Get the SpriteRenderer component of the bubble
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Pick a random sprite from the array
        if (bubbleSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, bubbleSprites.Length);
            spriteRenderer.sprite = bubbleSprites[randomIndex];
        }
        else
        {
            Debug.LogError("No sprites assigned to the bubble!");
        }
    }

    private void OnMouseDown()
    {
        bubbleSFX.GetComponent<AudioSource>().Play();
        // Spawn pop effect
        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);
        }

        // Destroy the bubble
        Destroy(gameObject);
    }
}
