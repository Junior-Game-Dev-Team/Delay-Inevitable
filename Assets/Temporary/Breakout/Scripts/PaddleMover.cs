using UnityEngine;
using UnityEngine.InputSystem;

namespace Lucid.Breakout
{
    public class PaddleMover : MonoBehaviour, IHittable
    {
        [SerializeField]
        private Rigidbody rb;

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private GameObject ball;

        private Vector3 move3d;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            ball = FindObjectOfType<SphereStarter>().gameObject;
        }

        private void Update()
        {
            rb.velocity = move3d * moveSpeed;
        }

        public void Hit()
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * ball.GetComponent<SphereStarter>().pushPower);
        }

        public void OnMove(InputValue magnitude)
        {
            Vector2 mag = magnitude.Get<Vector2>();
            move3d.Set(mag.x, 0, 0);
        }
    }
}