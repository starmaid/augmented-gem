using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{
    [Header("General")]
    [SerializeField] public bool isEnabled = true;

    [Header("Signals")]
    [SerializeField] public SignalSO overlapSignal;
    [SerializeField] public SignalSO endOverlapSignal;
    [SerializeField] public SignalSO interactSignal;

    [Header("Ink")]
    //[SerializeField] private TextAsset inkJSON;
    [SerializeField] private string knotName;
    // [SerializeField] private BooleanSO isRetrieved;

    public bool playerInRange;
    void Awake()
    {
        playerInRange = false;
    }

    public bool GetPlayerInRange() { return playerInRange; }

    //instead of how its written here, have this func trigger when it hears interactSignal raise from player
    public void InteractTrigger()
    {
        if (!isEnabled) { return; }

        // Debug.Log("entered InteractTrigger(), playerInRange is "+ playerInRange);
        if (!StoryManager.GetInstance().dialogueIsPlaying)
        {
            // Debug.Log("before testing");
            
            if (interactSignal != null)
            {
                Debug.Log("interacting!!!");
                interactSignal.Raise();
            }
            if (knotName != null)
            {
                print("trying to enter dialogue " + knotName);
                StoryManager.GetInstance().EnterDialogueMode(knotName);
            }
        }
        // Debug.Log("playerInRange:" + playerInRange);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isEnabled) { return; }

        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            if (overlapSignal != null)
            {
                // Debug.Log("overlapping! " + knotName);
                overlapSignal.Raise();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!isEnabled) { return; }

        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            if (endOverlapSignal != null)
            {
                //  Debug.Log("ending overlap!");
                endOverlapSignal.Raise();
            }
        }
    }

    public void DisableKnot(){
        knotName = null;
    }
}
