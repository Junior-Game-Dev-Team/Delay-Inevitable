using UnityEngine;

namespace Lucid
{
    [CreateAssetMenu(fileName = "Light Toggle Action", menuName = "Actions/Objects/Light Toggle Action")]
    public class ToggleLightAction : GmObjAction
    {
        public override void Execute(GameObject go)
        {
            if (go.GetComponent<Light>() == null) Debug.Log("Object has no attached light!");
            else
            {
                Debug.Log("Trying to change Light!");
                if (go.activeSelf) go.SetActive(false);
                else go.SetActive(true);
            }
        }
    }
}
