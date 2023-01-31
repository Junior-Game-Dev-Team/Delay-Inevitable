using UnityEngine;

namespace Lucid.Breakout
{
    public class HittableBlock : MonoBehaviour, IHittable
    {
        [SerializeField] GameObject ball;

        private void Start()
        {
            ball = FindObjectOfType<SphereStarter>().gameObject;
        }

        public void Hit()
        {
            ball.GetComponent<Rigidbody>().AddForce(Vector3.back * ball.GetComponent<SphereStarter>().pushPower);
            Destroy(gameObject);
            return;
        }
    }
}
