using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{
    [Header("Signals")]
    [SerializeField] public SignalSO overlapSignal;
    [SerializeField] public SignalSO endOverlapSignal;
    [SerializeField] public SignalSO interactSignal;

    [Header("Ink")]
    //[SerializeField] private TextAsset inkJSON;
    [SerializeField] private string knotName;

    // private bool playerInRange;
    private void Awake()
    {
        // playerInRange = false;
    }

    //instead of how its written here, have this func trigger when it hears interactSignal raise from player
    public void InteractTrigger()
    {
        // Debug.Log("entered InteractTrigger(), playerInRange is "+ playerInRange);
        if (!StoryManager.GetInstance().dialogueIsPlaying)
        {
            Debug.Log("before testing");
            
            if (interactSignal != null)
            {
                Debug.Log("interacting!!!");
                interactSignal.Raise();
            }
            if (knotName != null)
            {
                print("trying to enter dialogue");
                StoryManager.GetInstance().EnterDialogueMode(knotName);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // playerInRange = true;
            if (overlapSignal != null)
            {
                Debug.Log("overlapping!");
                overlapSignal.Raise();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // playerInRange = false;
            if (endOverlapSignal != null)
            {
                 Debug.Log("ending overlap!");
                endOverlapSignal.Raise();
            }
        }
    }
}
