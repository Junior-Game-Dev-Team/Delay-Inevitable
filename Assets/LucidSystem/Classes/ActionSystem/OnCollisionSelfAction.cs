using UnityEngine;

namespace Lucid
{
    [AddComponentMenu("Game Elements/Action on Collision (Self)")]
    public class OnCollisionSelfAction : ActionBase
    {
        [SerializeField] private string tagToCollideWith;

        private void Start()
        {
            gameObjectValue = gameObject;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(tagToCollideWith)) RunAction(actionValue, actionValue.QueryParent());
        }
    }
}
