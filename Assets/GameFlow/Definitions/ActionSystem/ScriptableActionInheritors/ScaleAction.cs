using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scale Action", menuName = "Actions/Object Interactions/Scale Action")]
public class ScaleAction : ScriptableAction
{
    [SerializeField]
    private float scale;

    public override void Execute(GameObject go)
    {
        go.transform.localScale *= scale;
    }
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}
