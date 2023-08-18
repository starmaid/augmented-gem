using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    // void OnControllerColliderHit (ControllerColliderHit hit){
    //     Debug.Log("just got hit ow");
    // }
    [SerializeField] GameObject _player;
    private Rigidbody2D _myRigidbody;

    public Rigidbody2D MyRigidBody{get{return _myRigidbody;}}

    // public bool IsPushed;
    void Awake(){
        _myRigidbody = GetComponent<Rigidbody2D>();
        // _myCollider = GetComponent<Collider2D>();
        // context = _player.gameObject.GetComponent<PlayerStateManager>();
        // IsPushed = false;
    }

    // void OnCollisionStay2D(Collision2D other)
    // {
    //     Rigidbody2D pusher = other.gameObject.GetComponent<Rigidbody2D>();
    //     if (_isPushed){

    //     }
    //     // PlayerBaseState hm = context.CurrentState;
    //     // if (other.gameObject.tag == "Player" && context.CurrentState == PlayerPushState)
    //     // {
    //         // Debug.Log("lets roll");
    //         // Vector3 diff = pusher.transform.position - transform.position;
    //         // _myRigidbody.MovePosition
    //         // (
    //         //     transform.position + 
    //         // //make sure framerate drop doesnt affect distance
    //         // );
    //     // }

    //     _isPushed = true;
    // }

    public void MoveObj(float currentSpeed, Vector3 change){
        // if (IsPushed){
            _myRigidbody.MovePosition
            (
                transform.position + 2 * currentSpeed * Time.fixedDeltaTime * change
            );
        // }
    }
    
}
