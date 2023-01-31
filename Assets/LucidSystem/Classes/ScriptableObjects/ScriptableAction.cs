using UnityEngine;

namespace Lucid
{
    public abstract class ScriptableAction : ScriptableObject
    {
        [HideInInspector]public string parentType;

        public abstract void Execute();
        public abstract void Execute(GameObject go);
        public abstract void Execute(string stringval, int intval);
        public abstract string QueryParent();
    }
}
