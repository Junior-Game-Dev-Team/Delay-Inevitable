using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Settings : MonoBehaviour
{
    [Header("Visual Settings")]
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private TMP_Text screenModeText;
    [SerializeField] private TMP_Text frameRateText;
    [SerializeField] private List<int> frameRates = new List<int>();

    private List<Resolution> resolutions = new List<Resolution>();
    private string screenWidth;
    private string screenHeight;

    private int resolutionIndex = 0;
    private int screenModeIndex = 0;
    private int framerateIndex = 0;

    private void Start()
    {
        frameRateText.text = "60";
        GetScreenResolutions();
        UpdateScreenModeText(Screen.fullScreenMode.ToString());
        Application.targetFrameRate = 60;
    }

    private void GetScreenResolutions()
    {
        resolutions.Clear();

        resolutions = Screen.resolutions.Where(x => x.refreshRate == 60).ToList();
        
        resolutionIndex = resolutions.FindIndex(0, resolutions.Count, x => x.width == Screen.currentResolution.width && x.height == Screen.currentResolution.height);

        UpdateResolutionText();
    }

    public void ResLeft() 
    {
        resolutionIndex--;

        if (resolutionIndex < 0)
        {
            resolutionIndex = resolutions.Count - 1;
        }
        ChangeResolution();
    }

    public void ResRight()
    {
        resolutionIndex++;

        if (resolutionIndex > resolutions.Count - 1)
        {
            resolutionIndex = 0;
        }
        ChangeResolution();
    }


    private void ChangeResolution() 
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, true);

        UpdateResolutionText();
    }

    private void UpdateResolutionText()
    {
        screenWidth = resolutions[resolutionIndex].width.ToString();
        screenHeight = resolutions[resolutionIndex].height.ToString();

        resolutionText.text = screenWidth + "x" + screenHeight;
    }

    private void SetFramerateLimit(int framerate) 
    {
        Application.targetFrameRate = frameRates[framerate];
        frameRateText.text = Application.targetFrameRate.ToString();
    }

    public void FramerateLeft() 
    {
        framerateIndex--;

        if (framerateIndex < 0) 
        {
            framerateIndex = frameRates.Count;
        }
        SetFramerateLimit(framerateIndex);
    }

    public void FramerateRight()
    {
        framerateIndex++;

        if (framerateIndex > 3)
        {
            framerateIndex = 0;
        }
        SetFramerateLimit(framerateIndex);
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
        screenModeIndex--;

        if (screenModeIndex < 0)
        {
            screenModeIndex = 2;
        }
        SetWindowMode(screenModeIndex);
    }

    public void ScreenModeRight()
    {
        screenModeIndex++;

        if (screenModeIndex > 2)
        {
            screenModeIndex = 0;
        }
        SetWindowMode(screenModeIndex);
    }
}