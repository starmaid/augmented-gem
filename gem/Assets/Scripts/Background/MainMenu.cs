using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // public Animator transitionAnimator;
    public GameObject Transitioner;

    public float transitionTime;

    void Start(){
        Transitioner.SetActive(true);
    }
    IEnumerator LoadSceneByInt(int index){
        Time.timeScale = 1f;
        Transitioner.GetComponent<Animator>().SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }

    public void LoadSceneByIntRunner(int index){
        Debug.Log("start");
        StartCoroutine(LoadSceneByInt(index));
        Debug.Log("end");
    }

    public void StartNewGame(){
        StartCoroutine(LoadSceneByInt(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void QuitGame(){
        Debug.Log("kill this fucker");
        Application.Quit();
    }


}
