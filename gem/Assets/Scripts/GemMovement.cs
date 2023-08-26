using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GemMovement : MonoBehaviour
{
    private Animator _animator;
    public PlayerControls _playerControls;


    // Start is called before the first frame update
    void Awake()
    {
        _playerControls = new PlayerControls(); 
        _playerControls.Gem.Wiggle.performed += ctxt => Wiggle(ctxt);
        _playerControls.Gem.Wiggle.canceled += ctxt => Wiggle(ctxt);
    }

    private void Wiggle(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton()){
            _animator.SetBool("moving",true);
        }else{
            _animator.SetBool("moving",false);
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
