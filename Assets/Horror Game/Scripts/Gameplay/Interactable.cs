using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public void OnStartHighlight() 
    {
        //Visual effects goes here
    }

    public void OnEndHighlight()
    { 
        //Reverse visual effects
    }

    public void OnInteract()
    {
        //Event calling setup will go here
        Debug.Log(transform.name);
    }
}
