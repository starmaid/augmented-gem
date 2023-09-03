using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITransmutable : MonoBehaviour
{
    // [SerializeField] public Material goldMaterial;
    public AudioSource transmuteSFX;
    protected bool isEnabled;
    public bool IsEnabled {get{return isEnabled;}}
    protected TriggerInteract interactState;
    protected SpriteRenderer mySpriteRenderer;

    // void Awake();
    // {
    // isEnabled = true;
    // SpriteRenderer = GetComponent<SpriteRenderer>();
    // interactState = GetComponent<TriggerInteract>();
    // }

    //When isEnabled is true, transmute.
    //An object can only be transmuted once. After transmuting, it is turned into an interactable object
    public abstract IEnumerator Transmute();

}