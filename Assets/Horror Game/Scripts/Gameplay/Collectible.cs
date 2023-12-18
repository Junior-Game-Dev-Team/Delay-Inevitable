using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    [Header("Audio")]
    [SerializeField] private EventReference ItemTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.UpdateHowManyToUnlockExitDoor(1);

            // Play sound
            FMODUnity.RuntimeManager.PlayOneShot(ItemTrigger, transform.position);

            Destroy(this.gameObject);
        }
    }
}
