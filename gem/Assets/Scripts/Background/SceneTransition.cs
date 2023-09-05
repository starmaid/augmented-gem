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
    public TriggerInteract thisTrigger;
    public BooleanSO Unlocked {get{return unlocked;}} //use signallistener to catch signal that unlocks this. if it doesnt? check if this is working first

    
    private void Awake(){
        thisTrigger = GetComponent<TriggerInteract>();
        // if(Unlocked){
        //     this.enabled = true;
        // }else{
        //     this.enabled = false;
        // }
    }

    public void SetUnlocked (bool val){
        unlocked.initialValue = val;
        Debug.Log("door is currently unlocked? " + unlocked.initialValue);
        thisTrigger.DisableKnot(); 
        // usually if a door is openable, there wont be dialogue anymore. will there be other cases?
        // god . who knows
    }

    // public void OnTriggerEnter2D(Collider2D other){
    //     // Debug.Log ("wanna go through the door? " + Unlocked.initialValue + Unlocked + unlocked);
    //     if(other.CompareTag("Player")&& !other.isTrigger && Unlocked.initialValue){
    //         ChangeScene();
    //     }
    // }

    // if this were to be called, you need a triggerinteract on the same gameobject!!
    public void ChangeSceneViaTrigger(){
        if (Unlocked.initialValue){
            ChangeScene();
        }
    }

    public void ChangeScene(){
        if (Application.CanStreamedLevelBeLoaded(sceneName)){
            Debug.Log("Calling save from SceneTransition");
            StoryManager.GetInstance().SaveFile();
            currentPlayerPos.initialValue = transportTo.initialValue;
            // yield return new WaitForSeconds(1f);
            // SceneManager.LoadScene(sceneName);
            MainMenu.GetInstance().LoadSceneByStrRunner(sceneName);
            // Calling load still acts on the current storymanager - scene hasnt changed
            //StoryManager.GetInstance().LoadFile();
        }
        else{
            Debug.LogError(sceneName + " is not found");
        }

    }
}
