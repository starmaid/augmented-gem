using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelectComponent : MonoBehaviour
{
    public Material newMaterial;
    public float highlightScale = 0.2f;
    [Range(0.1f, 1f)]

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
            mySprite = mySpriteRenderer.sprite;

            // build the child sprite renderer
            newObject = new GameObject(name + "_highlight");
            newObject.transform.SetParent(this.transform, false);

            newSpriteComponent = newObject.AddComponent<SpriteRenderer>();
            newSpriteComponent.sprite = mySprite;
            newSpriteComponent.material = newMaterial;
            newSpriteComponent.sortingLayerName = "HighlightSprites";

            // set it as inactive (we are just setting up!)
            newObject.SetActive(false);
        }

        
    }

    public void tryEnable()
    {
        if (!highlightEnabled)
        {
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

    }
}
