using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactExecutor : MonoBehaviour
{
    [SerializeField]
    private actionTarget target = new actionTarget();
    
    [SerializeField]
    private ScriptableAction action;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Sphere") return;
        switch(target)
        {
            case actionTarget.self:
                action.Execute(gameObject);
                break;
            case actionTarget.other:
                action.Execute(collision.gameObject);
                break;
        }
    }
}
