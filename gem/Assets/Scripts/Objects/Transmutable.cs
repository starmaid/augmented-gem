using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmutable : ITransmutable
{
    [SerializeField] public List<Sprite> texFrames;

    void Start()
    {
        isEnabled = true;
        interactState = GetComponent<TriggerInteract>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = texFrames[0];
    }

    public override IEnumerator Transmute()
    {
        if(isEnabled){
            isEnabled = false;
            //change the image to something else
            mySpriteRenderer.sprite = texFrames[1];
            interactState.isEnabled = true;
            transmuteSFX.Play();
            yield return new WaitForSeconds(transmuteSFX.clip.length);
        }
    }
}
