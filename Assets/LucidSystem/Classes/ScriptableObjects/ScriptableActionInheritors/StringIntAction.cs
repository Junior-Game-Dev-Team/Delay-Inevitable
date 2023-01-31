using UnityEngine;

namespace Lucid
{
    public abstract class StringIntAction : ScriptableAction
    {
        public override string QueryParent()
        {
            return "StringIntAction";
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Execute(GameObject go)
        {
            throw new System.NotImplementedException();
        }
    }
}
