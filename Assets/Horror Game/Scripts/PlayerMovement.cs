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
    private Transform cam;

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
        // calculate movement direction
        moveDirection = cam.forward * verticalInput + cam.right * horizontalInput;
        moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
