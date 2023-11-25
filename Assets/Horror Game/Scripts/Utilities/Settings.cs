using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private List<GameObject> configurations = new List<GameObject>();

    [Header("Visual Settings")]
    [SerializeField] private TMP_Text resolutionText;

    private List<Resolution> resolutions = new List<Resolution>();
    private string screenWidth;
    private string screenHeight;

    private int selectedResolution = 0;

    private void Start()
    {
        SetActiveTab(1);

        GetScreenResolutions();
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

    private void GetScreenResolutions()
    {
        resolutions.Clear();

        resolutions = Screen.resolutions.ToList();
        
        selectedResolution = resolutions.FindIndex(0, resolutions.Count, x => x.width == Screen.currentResolution.width && x.height == Screen.currentResolution.height);

        UpdateResolutionText();
    }

    public void ResLeft() 
    {
        selectedResolution--;

        if (selectedResolution < 0)
        {
            selectedResolution = resolutions.Count - 1;
        }
        ChangeResolution();
    }

    public void ResRight()
    {
        selectedResolution++;

        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = 0;
        }
        ChangeResolution();
    }


    private void ChangeResolution() 
    {
        Screen.SetResolution(resolutions[selectedResolution].width, resolutions[selectedResolution].height, true);

        UpdateResolutionText();
    }

    private void UpdateResolutionText()
    {
        screenWidth = resolutions[selectedResolution].width.ToString();
        screenHeight = resolutions[selectedResolution].height.ToString();

        resolutionText.text = screenWidth + "x" + screenHeight;
    }

    public void SetFrameLimit(int framerate) 
    {
        Application.targetFrameRate = framerate;
    }

    public void SetWindowMode(bool isFullScreen)
    {
        if (isFullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else if(!isFullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}