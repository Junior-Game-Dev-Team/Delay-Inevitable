using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField] protected int totalClues;
    [SerializeField] protected GameObject exitDoor;

    protected int collectedClues = 0;
    protected bool doorOpen = false;

    public virtual void UpdateProgress()
    {
    }
}
