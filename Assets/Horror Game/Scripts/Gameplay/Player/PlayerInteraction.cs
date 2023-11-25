using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private GameEvent pauseMenuEvent;

    [SerializeField] private Canvas pauseMenu;
    private bool isPauseMenu = false;

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
}