using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmutable : MonoBehaviour
{
    [SerializeField] public Material goldMaterial;
    protected TriggerInteract interactState;
    public AudioSource transmuteSFX;
    protected bool isEnabled;
    public bool IsEnabled {get{return isEnabled;}}
    [HideInInspector] public SpriteRenderer SpriteRenderer;
    // public Rigidbody2D RigidBody2d;
    
    void Awake(){
        isEnabled = true;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        // RigidBody2d = GetComponent<Rigidbody2D>();
        interactState = GetComponent<TriggerInteract>();
        // Debug.Log("Awake is called from Transmutable.cs, isenabled = " + isEnabled);
        // transmuteSFX = Resources.Load<AudioSource>("Audio/SFX/Player/transmute.wav");
    }

    public IEnumerator Transmute(){
        isEnabled = false;
        SpriteRenderer.material = goldMaterial;
        interactState.isEnabled = true;
        this.gameObject.tag="interactable";
        transmuteSFX.Play();
        yield return new WaitForSeconds(transmuteSFX.clip.length);
        Debug.Log("transmute called in Transmutable.cs, isenabled = " + isEnabled);
    }
}
