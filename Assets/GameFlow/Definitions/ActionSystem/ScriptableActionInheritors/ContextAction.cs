using UnityEngine;

[CreateAssetMenu(fileName = "New Context Action", menuName = "Actions/Game Flow/Context Action")]
public class ContextAction : ScriptableAction
{
    [SerializeField]
    ContextStateSO state;
    public override void Execute()
    {
        if(state == null)
        {
            Debug.Log("Attempted context change has no target state!");
            return;
        }
        ContextMonitor.currentContext = state;
        Debug.Log($"Context changed to {state.ToString()}");
    }

    public override void Execute(GameObject obj)
    {
        Execute();
    }
}
