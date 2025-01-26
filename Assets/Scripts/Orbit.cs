using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject target; 
    public float speed = 10f; 
    public Vector2 offset = new Vector2(2, 0); 

    private float angle; 

    void Update()
    {
        if (target != null)
        {
          
            angle += speed * Time.deltaTime;

            
            float radians = angle * Mathf.Deg2Rad;

           
            Vector2 newPosition = (Vector2)target.transform.position + new Vector2(
                offset.x * Mathf.Cos(radians) - offset.y * Mathf.Sin(radians),
                offset.x * Mathf.Sin(radians) + offset.y * Mathf.Cos(radians)
            );

            
            transform.position = newPosition;
        }
    }

}
