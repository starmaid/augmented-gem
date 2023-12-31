using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLocation : MonoBehaviour
{
    [Header("Signals")]
    [SerializeField] public SignalSO overlapSignal;
    [SerializeField] public SignalSO endOverlapSignal;

    [Header("Ink")]
    //[SerializeField] private TextAsset inkJSON;
    [SerializeField] private string knotName;

    private bool playerInRange;

    private bool alreadyCalled;
    private void Awake()
    {
        playerInRange = false;
        alreadyCalled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !alreadyCalled)
        {
            playerInRange = true;
            if (overlapSignal != null)
            {
                overlapSignal.Raise();
            }

            if (knotName != null && knotName != "")
            {
                StoryManager.GetInstance().EnterDialogueMode(knotName);
            }
            print(playerInRange);
            alreadyCalled = true;
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
