using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Interactable
{
    [SerializeField] private LevelManager levelManager;

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

        // TODO

        // Destroy game object
        Destroy(gameObject);

        // Add to collected
        levelManager.UpdateProgress();

        // Particle effect
        // Sound
    }
}
