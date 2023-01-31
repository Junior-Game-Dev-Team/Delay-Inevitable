using UnityEngine;

namespace Lucid
{
    [AddComponentMenu("Game Elements/Action on Zone Trigger (No Target)")]
    public class OnTriggerZoneAction : ActionBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player") RunAction(actionValue, actionValue.QueryParent());
        }
    }
}
