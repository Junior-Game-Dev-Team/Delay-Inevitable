using UnityEngine;

namespace Lucid
{
    [AddComponentMenu("Game Elements/Action on Start")]
    public class OnStartAction : ActionBase
    {
        private void Start()
        {
            //Debug.Log("Running Action!");
            RunAction(actionValue, actionValue.QueryParent());
        }
    }
}
