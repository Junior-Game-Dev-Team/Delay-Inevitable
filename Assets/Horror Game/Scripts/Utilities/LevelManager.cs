using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Doors")]
    [SerializeField] private GameObject exitDoorlocked;
    [SerializeField] private GameObject exitDoorOpen;

    [Header("Requirements")]
    [SerializeField] private int howManyItemsToUnlockExitDoor = 1;

    [Header("Audio")]
    [SerializeField] private EventReference ExitDoorTrigger;

    private int itemsCollected = 0;

    private bool isExitDoorUnlocked = false;

    private void Start()
    {
        exitDoorOpen.SetActive(false);
        exitDoorlocked.SetActive(true);
    }

    public void UpdateHowManyToUnlockExitDoor(int index) 
    {
        itemsCollected += index;
        
        // Update UI

        if (itemsCollected >= howManyItemsToUnlockExitDoor)
        {
            SetExitDoorState(true);
        }
    }

    private void UpdateExitDoorState()
    {
        if (isExitDoorUnlocked)
        {
            // Switch door model to be opened.
            exitDoorlocked.SetActive(false);
            exitDoorOpen.SetActive(true);

            // Play sound
            FMODUnity.RuntimeManager.PlayOneShot(ExitDoorTrigger, exitDoorOpen.transform.position);

        }
        else if (!isExitDoorUnlocked)
        {
            // Door model is locked
            exitDoorOpen.SetActive(false);
            exitDoorlocked.SetActive(true);

            // Play sound
        }
    }

    public void SetExitDoorState(bool statement)
    {
        isExitDoorUnlocked = statement;
        UpdateExitDoorState();
    }
}
