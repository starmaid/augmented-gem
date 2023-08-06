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
        if (playerInRange)
        {
            interactSignal.Raise();
            StoryManager.GetInstance().EnterDialogueMode(knotName);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            overlapSignal.Raise();

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            endOverlapSignal.Raise();
        }
    }
}
