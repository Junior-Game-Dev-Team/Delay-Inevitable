using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light spotlight;
    private bool isOn;

    private void Start()
    {
        isOn = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        isOn = !isOn;
        spotlight.enabled = isOn;
    }
}
