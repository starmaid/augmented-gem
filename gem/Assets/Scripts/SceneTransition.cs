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
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")&& !other.isTrigger){
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
