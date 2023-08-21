using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameObject player;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Guys there're more than one GameManagers in here wtf");
        }
        instance = this;
       playerInput = player.GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
