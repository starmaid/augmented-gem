using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public String sceneName;
    public VectorValue transportTo;
    public VectorValue currentPlayerPos;
    [SerializeField] BooleanSO unlocked; 
    public BooleanSO Unlocked {get{return unlocked;} set{unlocked = value;}} //use signallistener to catch signal that unlocks this. if it doesnt? check if this is working first

    
    private void Awake(){
        // if(Unlocked){
        //     this.enabled = true;
        // }else{
        //     this.enabled = false;
        // }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")&& !other.isTrigger && Unlocked){
            if (Application.CanStreamedLevelBeLoaded(sceneName)){
                currentPlayerPos.initialValue = transportTo.initialValue;
                SceneManager.LoadScene(sceneName);
            }
            else{
                Debug.LogError(sceneName + " is not found");
            }
        }
    }
}
