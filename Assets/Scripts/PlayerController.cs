using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public PlayerControls controls;

    Vector2 moveDirection = Vector2.zero;
    Vector2 mousePositon = Vector2.zero;
    private void Awake()
    {
        controls = new PlayerControls();
    }
    private void OnEnable()
    {
        controls.Player.Movement.Enable();
        controls.Player.MousePosition.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Movement.Disable();
        controls.Player.MousePosition.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = controls.Player.Movement.ReadValue<Vector2>();
        mousePositon = controls.Player.MousePosition.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
        RotatePosition();
    }

    private void RotatePosition()
    {
        mousePositon = Camera.main.ScreenToWorldPoint(mousePositon);
        Vector2 direction = new Vector2(mousePositon.x - transform.position.x, mousePositon.y - transform.position.y);
        transform.up = direction;

    }
}
