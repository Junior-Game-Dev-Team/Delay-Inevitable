using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LM_Level1 : LevelManager
{
    [SerializeField] private TMP_Text doorText;
    [SerializeField] private TMP_Text cluesText;


    public override void UpdateProgress()
    {
        collectedClues++;
        cluesText.text = "Clues: " + collectedClues + "/" + totalClues;

        if (collectedClues >= totalClues)
        {
            doorOpen = true;
            exitDoor.GetComponent<Animator>().SetBool("IsDoorOpen", doorOpen);
            doorText.text = "Exit Door Open";
        }
    }
}
