using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;

    public float moveSpeed;
    public float rotationSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Transform cam;

    private Quaternion playerRot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    } 

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = cam.forward * verticalInput + cam.right * horizontalInput;
        // Prevent Player from levitating
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            // Facing the direction of input
            playerRot = Quaternion.Slerp(playerRot, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotationSpeed);
            player.rotation = playerRot;
        }

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
