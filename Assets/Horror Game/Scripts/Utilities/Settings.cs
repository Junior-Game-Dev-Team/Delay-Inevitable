using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private TMP_Text screenModeText;
    [SerializeField] private TMP_Text frameRateText;

    private List<Resolution> resolutions = new List<Resolution>();
    private string screenWidth;
    private string screenHeight;

    private int selectedResolution = 0;
    private int selectedScreenMode = 0;

    private void Start()
    {
        GetScreenResolutions();
        UpdateScreenModeText(Screen.fullScreenMode.ToString());    
    }

    private void GetScreenResolutions()
    {
        resolutions.Clear();

        resolutions = Screen.resolutions.Where(x => x.refreshRate == 60).ToList();
        
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

    private void SetWindowMode(int Mode)
    {
        switch(Mode) 
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                UpdateScreenModeText("Fullscreen");
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                UpdateScreenModeText("Borderless");
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                UpdateScreenModeText("Windowed");
                break;
            default:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                UpdateScreenModeText("Fullscreen");
                break;
        }
    }

    private void UpdateScreenModeText(string name)
    {
        screenModeText.text = name;
    }

    public void ScreenModeLeft()
    {
        selectedScreenMode--;

        if (selectedScreenMode < 0)
        {
            selectedScreenMode = 2;
        }
        SetWindowMode(selectedScreenMode);
    }

    public void ScreenModeRight()
    {
        selectedScreenMode++;

        if (selectedScreenMode > 2)
        {
            selectedScreenMode = 0;
        }
        SetWindowMode(selectedScreenMode);
    }
}