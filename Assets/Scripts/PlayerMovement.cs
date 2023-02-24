using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput),typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 moveVal;
    private Vector3 movement;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    // Reads the input value from the input device(s)
    public void OnMovement(InputValue value)
    {
        // Gets a vector 2 value
        moveVal = value.Get<Vector2>();

        // Forward, sideway movement
        movement = new Vector3(moveVal.x, 0, moveVal.y);
    }

    private void Movement()
    {
        // Make the player move
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
