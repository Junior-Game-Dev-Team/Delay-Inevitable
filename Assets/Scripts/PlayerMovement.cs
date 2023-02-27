using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput),typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector2 moveVal;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private float gravityValue = -9.81f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void OnMovement(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    private void Movement()
    {
        // Check if the player is on the ground
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        Vector3 move = new Vector3(moveVal.x, 0, moveVal.y);

        // Take into consideration of the camera direction
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * speed);

        // Character Controller ignores the gravity
        // So have to code it manually
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
