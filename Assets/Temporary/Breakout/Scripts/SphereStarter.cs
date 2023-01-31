using UnityEngine;

namespace Lucid.Breakout
{
    public class SphereStarter : MonoBehaviour
    {
        public float pushPower;
        private void Start()
        {
            Vector3 startVector = new Vector3(Random.Range(-1f,1f), 0, 1);
            GetComponent<Rigidbody>().AddForce(startVector * pushPower);
        }
    }
}
