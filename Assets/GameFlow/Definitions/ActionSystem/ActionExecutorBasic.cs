using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionExecutorBasic : MonoBehaviour
{
    public List<ScriptableAction> actions = new List<ScriptableAction>();
    void Start()
    {
        for(int i = 0; i < actions.Count; i++)
        {
            actions[i].Execute();
        }
    }
}
