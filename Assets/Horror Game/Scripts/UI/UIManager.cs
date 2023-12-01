using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> uiElements = new List<GameObject>();

    public void EnableMenu(string MenuName)
    {
        foreach (GameObject element in uiElements) 
        {
            element.SetActive(false);

            // Check if menu name matches a name in the list 
            // and it has the correct tag
            // This is to prevent activating other game objects.
            if (element.name == MenuName && element.CompareTag("UI")) 
            {
                element.SetActive(true);
                Debug.Log("Working");
            }
        }
    }
}
