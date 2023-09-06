using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelectComponent : MonoBehaviour
{
    // [SerializeField] public Material newMaterial;
    [SerializeField] public Material intMaterial;
    [SerializeField] public Material transMaterial;

    [Range(0f, 1f)]
    [SerializeField] public float highlightScale = 0.2f;
    

    [SerializeField] public bool doesntHaveAnimator = false;

    private bool highlightEnabled;

    private SpriteRenderer mySpriteRenderer;
    private Sprite mySprite;
    
    private GameObject newObject;
    private SpriteRenderer newSpriteComponent;

    private float timer;
    private float newScale;

    // Start is called before the first frame update
    void Start()
    {
        highlightEnabled = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySprite = mySpriteRenderer.sprite;

        // set things up
        if (mySpriteRenderer != null)
        {
            // this is stupid and wasnt a good idea
            //mySprite = Sprite.Create(mySpriteRenderer.sprite.texture,
            //    mySpriteRenderer.sprite.rect, new Vector2(0.5f, 0.5f), 
            //    mySpriteRenderer.sprite.pixelsPerUnit);

            // this should work but idk why
            //mySprite = Sprite.Create(mySpriteRenderer.sprite.texture,
            //    mySpriteRenderer.sprite.rect, mySpriteRenderer.sprite.pivot, 
            //    mySpriteRenderer.sprite.pixelsPerUnit,
            //    (uint) 20);

            // build the child sprite renderer
            newObject = new GameObject(name + "_highlight");
            newObject.transform.SetParent(this.transform, false);

            newSpriteComponent = newObject.AddComponent<SpriteRenderer>();
            
            newSpriteComponent.sprite = mySprite;
            newSpriteComponent.material = intMaterial; //default
            newSpriteComponent.sortingLayerName = "HighlightSprites";

            // set it as inactive (we are just setting up!)
            newObject.SetActive(false);
        }

        
    }

    public void tryEnable()
    {
        if (!highlightEnabled)
        {
            if(this.CompareTag("interactable")){
                newSpriteComponent.material = intMaterial;
            }else if(this.CompareTag("transmutable")){
                newSpriteComponent.material = transMaterial;
            }

            highlightEnabled = true;
            timer = 0;
            if (newObject != null)
            {
                newObject.SetActive(true);
            }
        }
    }

    public void tryDisable()
    {
        if (highlightEnabled)
        {
            highlightEnabled = false;
            if (newObject != null)
            {
                newObject.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (newObject != null && highlightEnabled) 
        {
            timer += Time.deltaTime * 5;
            newScale = highlightScale * Mathf.Sin(timer);
            newObject.transform.localScale = Vector3.one + Vector3.one * highlightScale + (Vector3.one * newScale);
        }

        if (newObject != null && doesntHaveAnimator)
        { 
            mySprite = mySpriteRenderer.sprite;
            newSpriteComponent.sprite = mySprite;
            newSpriteComponent.flipX = mySpriteRenderer.flipX;
        }

    }
}
