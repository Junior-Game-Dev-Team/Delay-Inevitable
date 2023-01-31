using UnityEngine;

namespace Lucid.Breakout
{

    public class HittableWall : MonoBehaviour, IHittable
    {
        public enum WallPosition
        {
            left, right, top
        }

        [SerializeField] GameObject ball;
        [SerializeField] WallPosition wallPosition;
        private Vector3 forceDir;

        private void Start()
        {
            ball = FindObjectOfType<SphereStarter>().gameObject;
        }

        public void Hit()
        {
            switch (wallPosition)
            {
                case WallPosition.left: forceDir = Vector3.right; break;
                case WallPosition.right: forceDir = Vector3.left; break;
                case WallPosition.top: forceDir = Vector3.back; break;
            }
            ball.GetComponent<Rigidbody>().AddForce(forceDir * ball.GetComponent<SphereStarter>().pushPower);
            return;
        }
    }
}
