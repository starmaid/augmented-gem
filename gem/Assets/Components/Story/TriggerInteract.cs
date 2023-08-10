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

    private bool playerInRange;
    private void Awake()
    {
        playerInRange = false;
    }

    public void InteractTrigger()
    {
        if (playerInRange && !StoryManager.GetInstance().dialogueIsPlaying)
        {
            
            if (interactSignal != null)
            {
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
            playerInRange = true;
            if (overlapSignal != null)
            {
                overlapSignal.Raise();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            if (endOverlapSignal != null)
            {
                endOverlapSignal.Raise();
            }
        }
    }
}
