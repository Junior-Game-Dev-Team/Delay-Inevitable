using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> uiElements = new List<GameObject>();

    public void EnableMenu(string MenuName)
    {
        foreach (GameObject UI in uiElements) 
        {
            if (UI.name != MenuName)
            {
                UI.gameObject.SetActive(false); 
            }

            if (UI.name == MenuName && UI.CompareTag("UI"))
            {
                UI.gameObject.SetActive(true);
            }
        }
    }
}
