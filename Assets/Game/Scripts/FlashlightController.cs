using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Light spotlight;
    private bool isFlashLightOn;

    private void Start()
    {
        isFlashLightOn = true;
    }

    private void OnFlashLight()
    {
        // Press F to turn the flash light on or off
        isFlashLightOn = !isFlashLightOn;
        spotlight.enabled = isFlashLightOn;
    }
}
