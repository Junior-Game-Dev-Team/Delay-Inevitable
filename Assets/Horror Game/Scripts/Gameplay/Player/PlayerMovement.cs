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

    private bool canPlayerMove = true;

    private void Awake()
    {
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (canPlayerMove)
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
        rb.AddForce(new Vector3(moveDirection.x, 0, moveDirection.z) * speed, ForceMode.Force);
    }

    public void CanPlayerMove(bool state) 
    {
        canPlayerMove = state;
    }
}
