using UnityEngine;

namespace Lucid
{
    public class ActionBase : MonoBehaviour
    {
        public ScriptableAction actionValue;
        public int intValue;
        public float floatValue;
        public string stringValue;
        public GameObject gameObjectValue;

        public void RunAction(ScriptableAction action, string parentType)
        {
            if (parentType == string.Empty) Debug.Log($"{action.ToString()} has no parent type set!");

            if (parentType == "StringIntAction") actionValue.Execute(stringValue, intValue);
            if (parentType == "GmObjAction") actionValue.Execute(gameObjectValue);
        }
    }
}
