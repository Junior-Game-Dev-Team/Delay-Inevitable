using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private List<GameObject> configurations = new List<GameObject>();

    private void Start()
    {
        SetActiveTab(0);
    }

    public void SetActiveTab(int ID)
    {
        // Hover over button
        // Find the corresponsive tab
        // Activate the tab
        // Disable the other tabs

        configurations[ID].SetActive(true);

        for (int i = 0; i < configurations.Count; i++)
        {
            if (i != ID)
            {
                configurations[i].SetActive(false);
            }
        }
    }
}