using UnityEngine;

public class CircleHitDetection : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Get the point of collision
            Vector2 collisionPoint = contact.point;

            // Calculate the direction vector from the center of the circle to the collision point
            Vector2 direction = collisionPoint - (Vector2)transform.position;

            // Calculate the angle (in degrees) of the collision point relative to the circle's local forward direction
            float worldAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Normalize the world angle to [0, 360)
            if (worldAngle < 0)
            {
                worldAngle += 360;
            }

            // Adjust the angle based on the circle's current rotation (subtract local rotation)
            float localAngle = worldAngle - transform.eulerAngles.z;

            // Normalize the local angle to [0, 360)
            if (localAngle < 0)
            {
                localAngle += 360;
            }

            Debug.Log($"Collision occurred at local angle: {localAngle} degrees (relative to the circle's forward direction)");

            // Determine which part of the circle was hit
            if (localAngle >= 0 && localAngle < 120)
            {
                Debug.Log("Collision occurred in Segment 1 (0° to 120° relative to forward)");
            }
            else if (localAngle >= 120 && localAngle < 240)
            {
                Debug.Log("Collision occurred in Segment 2 (120° to 240° relative to forward)");
            }
            else if (localAngle >= 240 && localAngle < 360)
            {
                Debug.Log("Collision occurred in Segment 3 (240° to 360° relative to forward)");
            }
        }
    }
}
