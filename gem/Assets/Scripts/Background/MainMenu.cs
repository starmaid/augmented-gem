using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.IO;

public class MainMenu : MonoBehaviour
{
    // public Animator transitionAnimator;
    [SerializeField] public GameObject Transitioner;

    [SerializeField] public float transitionTime;

    [SerializeField] public TextAsset mainInkAsset;
    private static MainMenu instance;

    public static MainMenu GetInstance()
    {
        return instance;
    }
    void Awake(){
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

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

    public void LoadNextScene(){
        Debug.Log("start");
        StartCoroutine(LoadSceneByInt(SceneManager.GetActiveScene().buildIndex+1));
        Debug.Log("end");
    }

    IEnumerator LoadSceneByStr(String sceneName){
        Time.timeScale = 1f;
        Transitioner.GetComponent<Animator>().SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByStrRunner(String sceneName){
        // Debug.Log("start");
        StartCoroutine(LoadSceneByStr(sceneName));
        // Debug.Log("end");
    }


    public void StartNewGame(){

        // begin hack to create new blank story
        // stolen from the StoryManager's Save function
        // because i dont want to add a whole storymanager to this scene
        Story currentStory = new Story(mainInkAsset.text);
        string path = Application.persistentDataPath + "/savedata.json";
        string storystate = currentStory.state.ToJson();
        File.WriteAllText(path, storystate);
        // end hack to create new blank 

        StartCoroutine(LoadSceneByInt(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void QuitGame(){
        Debug.Log("kill this fucker");
        Application.Quit();
    }


}
