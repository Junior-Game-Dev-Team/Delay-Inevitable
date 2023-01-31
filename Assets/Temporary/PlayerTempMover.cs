using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTempMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    private Vector3 move3d;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = move3d * moveSpeed;
    }

    public void OnMove(InputValue magnitude)
    {
        Vector2 mag = magnitude.Get<Vector2>();
        move3d.Set(mag.x, 0, mag.y);
    }
}
