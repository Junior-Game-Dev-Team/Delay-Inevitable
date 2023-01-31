using UnityEngine;

namespace Lucid
{
    public abstract class NullAction : ScriptableAction
    {
        public override string QueryParent()
        {
            return "NullAction";
        }

        public override void Execute(GameObject go)
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(string stringval, int intval)
        {
            throw new System.NotImplementedException();
        }
    }
}