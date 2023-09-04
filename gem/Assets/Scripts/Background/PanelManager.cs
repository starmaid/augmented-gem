using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Controller of Start Menu and Pause Menu
public class PanelManager : MonoBehaviour
{
    private PlayerInput playerInput;
    // public PlayerControls playerControls;
    private bool gamePaused;
    private bool gameStarted;
    public GameObject pauseMenuUI;
    public GameObject player;

    void Awake()
    {
        pauseMenuUI.SetActive(false);
        playerInput = player.GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Transitional").Enable();
        gameStarted = true;

        playerInput.actions["Pause"].performed += ctxt => {
            Debug.Log("attempting to tpause");
            if (gameStarted){
                if (gamePaused){
                    // playerInput.SwitchCurrentActionMap("UI");
                    resume();
                }else if (!gamePaused){
                    pause();
                }
            }
        };
    }

    public void pause(){
        // playerInput.actions.FindActionMap("Adventurer").Disable(); 
        // playerInput.actions.FindActionMap("UI").Enable(); 

        player.GetComponent<PlayerStateManager>().SeizeAdvControl();
        // playerControls.Adventurer.Disable();
        // playerControls.Gem.Enable();
        playerInput.SwitchCurrentActionMap("UI");

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    

    public void resume(){
        // playerInput.actions.FindActionMap("UI").Disable(); 
        // playerInput.actions.FindActionMap("Adventurer").Enable(); 
        
        player.GetComponent<PlayerStateManager>().ReturnAdvControl();
        // playerControls.Adventurer.Enable();
        // playerControls.Gem.Disable();
        playerInput.SwitchCurrentActionMap("Adventurer");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
