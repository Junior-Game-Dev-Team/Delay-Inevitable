using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider masterVolslider;
    [SerializeField] private Slider SFXVolslider;
    [SerializeField] private Slider BGMVolslider;

    private FMOD.Studio.Bus Master;
    private FMOD.Studio.Bus SFX;
    private FMOD.Studio.Bus BGM;

    private float masterVolume = 0.5f;
    private float SFXVolume = 0.5f;
    private float BGMVolume = 0.5f;



    private void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        BGM = FMODUnity.RuntimeManager.GetBus("bus:/Music");

        Master.setVolume(masterVolume);
        SFX.setVolume(SFXVolume);
        BGM.setVolume(BGMVolume);

        masterVolslider.value = masterVolume;
        SFXVolslider.value = SFXVolume;
        BGMVolslider.value = BGMVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Master.setVolume(masterVolume);
        SFX.setVolume(SFXVolume);
        BGM.setVolume(BGMVolume);
    }

    public void MasterVolLevel(float volume)
    {
        masterVolume = volume;
    }

    public void SFXVolLevel(float volume)
    {
        SFXVolume = volume;
    }

    public void BGMVolLevel(float volume)
    {
        BGMVolume = volume;
    }
}
