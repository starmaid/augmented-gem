using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteImgGlowComponent : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Image myImage;
    private Sprite mySprite;
    private GameObject newObject;

    private SpriteRenderer newSpriteComponent;
    private Image newImageComponent;

    public Material newMaterial;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        if (mySpriteRenderer != null )
        {
            mySprite = mySpriteRenderer.sprite;

            // build the child sprite renderer
            newObject = new GameObject(name + "_glow");
            newObject.transform.SetParent(this.transform, false);
            
            newSpriteComponent = newObject.AddComponent<SpriteRenderer>();
            newSpriteComponent.sprite = mySprite;
            newSpriteComponent.material = newMaterial;
            newSpriteComponent.sortingLayerName = "GlowSprites";

        }

        myImage = GetComponent<Image>();

        if (myImage != null)
        {
            mySprite = myImage.sprite;

            // build the child sprite renderer
            newObject = new GameObject(name + "_glow");
            newObject.transform.SetParent(this.transform, false);

            newImageComponent = newObject.AddComponent<Image>();
            newImageComponent.sprite = mySprite;
            newImageComponent.material = newMaterial;
            newImageComponent.rectTransform.sizeDelta = myImage.rectTransform.sizeDelta;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (mySpriteRenderer != null)
        {
            if (mySpriteRenderer.sprite != mySprite)
            {
                mySprite = mySpriteRenderer.sprite;
                newSpriteComponent.sprite = mySprite;
            }
        }
        else if (myImage != null)
        { 
            if (myImage.sprite != mySprite)
            {
                mySprite = myImage.sprite;
                newImageComponent.sprite = mySprite;
            }
        }

    }
}
