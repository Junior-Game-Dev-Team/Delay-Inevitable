using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput),typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Configuration")]
    [SerializeField] private float speed = 20f;

    [HideInInspector] public Rigidbody rb;
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

        // Rotate the body to look in the direction of the camera
        transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
    }

    private void UpdateAnimator()
    {
        // TODO
        // Play running animations when the player is moving
    }
}
