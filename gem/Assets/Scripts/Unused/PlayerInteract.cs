using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private BoxCollider2D c;
    private PlayerMovement pMovement;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<BoxCollider2D>();
        pMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }
}
