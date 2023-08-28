using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GemMovement : MonoBehaviour
{
    private Animator _animator;
    // public PlayerControls _playerControls;
    public PlayerInput _playerInput;
    public GameObject player;
    public SignalSO GetNoticedSignal;


    // Start is called before the first frame update
    void Awake()
    {
        // _playerControls = player.GetComponent<PlayerControls>();
        _animator = GetComponent<Animator>();
        _playerInput = player.GetComponent<PlayerInput>();
        _playerInput.actions["Wiggle"].performed += ctxt => Wiggle(ctxt);
        _playerInput.actions["Wiggle"].canceled += ctxt => Wiggle(ctxt);
    }

    private void Wiggle(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton()){
            _animator.SetBool("moving",true);
            GetNoticed();
            Debug.Log("Getting noticed...1");
        }else{
            _animator.SetBool("moving",false);
        }
    }

    private IEnumerator GetNoticed()
    {
        Debug.Log("Getting noticed...2");
        if(GetNoticedSignal != null){
            GetNoticedSignal.Raise();
            // StoryManager.pauseAndHideStory();
            Debug.Log("FOUND YOU !");
        }
        yield return new WaitForSeconds(3f); //amount of seconds to wait
    }
}
