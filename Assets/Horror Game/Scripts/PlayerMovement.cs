using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;

    public float rotationSpeed;
    public float moveSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    // Update is called once per frame
    void Update()
    {
        GetInput();

        Vector3 inputDir = player.forward * verticalInput + player.right * horizontalInput;

        if (inputDir != Vector3.zero)
            player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    } 

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = player.forward * verticalInput + player.right * horizontalInput;


        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
