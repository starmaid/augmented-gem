using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] BooleanSO isRetrieved;
    [SerializeField] TriggerInteract triggerInteract;
    [SerializeField] AudioSource pickUpSound;

    // Start is called before the first frame update
    void Awake()
    {
        // triggerInteract = GetComponent<TriggerInteract>();
        triggerInteract.playerInRange = false;
        if(isRetrieved.initialValue){
            this.gameObject.SetActive(false);
        }else{
            this.gameObject.SetActive(true);
        }
    }

    public void GetPickedUp(){
        if(triggerInteract.playerInRange){
            pickUpSound.Play();
            isRetrieved.initialValue = true;
            StartCoroutine(PlayAudioAndDisable(pickUpSound));
        }
    }

    IEnumerator PlayAudioAndDisable(AudioSource sound){
        sound.Play();
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }

}
