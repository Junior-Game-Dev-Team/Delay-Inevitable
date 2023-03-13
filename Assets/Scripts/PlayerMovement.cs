using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput),typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private Transform cam;

    private Vector2 moveInput;
    private Vector3 moveDirection;

    private void Awake()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Movement()
    {
        // Move in the camera direction
        moveDirection = moveInput.x * cam.right + moveInput.y * cam.forward;

        rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}
