using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Controller of Start Menu and Pause Menu
public class PanelManager : MonoBehaviour
{
    private PlayerInput playerInput;
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

    public void LoadSceneByStr(String name){
        SceneManager.LoadScene(name);
    }

    public void pause(){
        playerInput.actions.FindActionMap("Adventurer").Disable(); 
        playerInput.actions.FindActionMap("UI").Enable(); 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void resume(){
        playerInput.actions.FindActionMap("UI").Disable(); 
        playerInput.actions.FindActionMap("Adventurer").Enable(); 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
