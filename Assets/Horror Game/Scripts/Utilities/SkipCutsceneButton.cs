using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkipCutsceneButton : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private RectTransform parentImage;

    private Vector2 startParentImageScale;

    [SerializeField]
    private Vector2 targetParentImageScale = new Vector2 (1.2f, 1.2f);

    [SerializeField]
    private InputAction button;

    [SerializeField]
    private float fillAmountSpeed = 0.001f;

    [SerializeField]
    private float fillAmountCooldownSpeed = 0.6f;

    [SerializeField]
    private UnityEvent onFillAmountFilled;

    bool hasFunctionTriggered = false;


    private void OnEnable()
    {
        button.Enable();
    }

    private void OnDisable()
    {
        button.Disable();
    }

    private void Awake()
    {
        Assert.IsNotNull (fillImage);
        Assert.IsNotNull (parentImage);

        startParentImageScale = parentImage.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount += ((button.IsPressed() && !hasFunctionTriggered) ? 
            fillAmountSpeed * Time.deltaTime : (-fillAmountCooldownSpeed) * Time.deltaTime);

        parentImage.localScale = Vector2.Lerp(startParentImageScale, targetParentImageScale, fillImage.fillAmount * fillImage.fillAmount);

        if (!hasFunctionTriggered && fillImage.fillAmount >= 1)
        {
            hasFunctionTriggered = true;
            onFillAmountFilled?.Invoke();
        }
    }
}
