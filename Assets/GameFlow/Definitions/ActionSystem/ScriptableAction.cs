using UnityEngine;

enum actionTarget
{
    self,
    other
};

public abstract class ScriptableAction : ScriptableObject
{
    public abstract void Execute();

    public abstract void Execute(GameObject obj);
}
