using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] BooleanSO isRetrieved;
    [SerializeField] SpriteSelectComponent spriteSelectedComp;
    [SerializeField] AudioSource pickUpSound;

    // Start is called before the first frame update
    void Awake()
    {
        // triggerInteract = GetComponent<TriggerInteract>();
        // spriteSelectedComp.HighlightEnabled = false;
        if(isRetrieved.initialValue){
            this.gameObject.SetActive(false);
        }else{
            this.gameObject.SetActive(true);
        }
    }

    public void GetPickedUp(){
        if(spriteSelectedComp.isActiveAndEnabled && spriteSelectedComp.HighlightEnabled){
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
