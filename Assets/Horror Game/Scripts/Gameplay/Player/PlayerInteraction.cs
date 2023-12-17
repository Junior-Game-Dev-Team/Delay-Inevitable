using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private GameEvent pauseMenuEvent;
    [SerializeField] private GameEvent interactEvent;

    [SerializeField] private float maxInteractDistance;
    //Make sure that Player collider is given a specific layer other than default (such as IgnoreRaycast)
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private Transform currentInteractTarget;

    //Using this for testing
    [SerializeField] private GameObject orbOfInteraction;

    [SerializeField] private Canvas pauseMenu;
    private bool isPauseMenu = false;

    private void Start()
    {
        orbOfInteraction.SetActive(false);
    }
    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, maxInteractDistance, interactLayerMask))
        {
            if (hit.transform != currentInteractTarget)
            {
                if (hit.transform.GetComponent<Interactable>())
                {
                    if (currentInteractTarget != null)
                        currentInteractTarget.GetComponent<Interactable>().OnEndHighlight();

                    currentInteractTarget = hit.transform;
                    currentInteractTarget.GetComponent<Interactable>().OnStartHighlight();
                }
                else 
                {
                    currentInteractTarget.GetComponent<Interactable>().OnEndHighlight();
                    currentInteractTarget = null;
                }
            }

        }
        else 
        {
            if (currentInteractTarget != null)
            {
                currentInteractTarget.GetComponent<Interactable>().OnEndHighlight();
                currentInteractTarget = null;
            }
        }
    }

    
    private void OnPauseMenu() 
    {
        isPauseMenu = !isPauseMenu;

        if (isPauseMenu)
        {
            // Player movement stop
            gameEvent.RaiseBool(false);
            pauseMenuEvent.RaiseBool(true);
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            gameEvent.RaiseBool(true);
            pauseMenuEvent.RaiseBool(false);
            pauseMenu.gameObject.SetActive(false);
        }
    }

    private void OnInteract() 
    {
        if (currentInteractTarget != null)
            currentInteractTarget.GetComponent<Interactable>().OnInteract();
    }
}
