using UnityEngine;

namespace Lucid
{
    [CreateAssetMenu(fileName = "Hittable Interface Action", menuName = "Actions/Objects/Hittable Interface Action")]
    public class IHittableAction : GmObjAction
    {
        public override void Execute(GameObject go)
        {
            go.GetComponent<IHittable>().Hit();
        }
    }
}

