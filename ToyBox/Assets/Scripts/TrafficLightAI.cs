using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightAI : MonoBehaviour
{
    public Sprite redLightSprite;

    public Sprite greenLightSprite;

    public Sprite yellowLightSprite;

    public float waitTimer;

    private SpriteRenderer spriteRenderer;

    private float tempTime;

    private GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        parentGameObject = this.transform.parent.gameObject;
        spriteRenderer = parentGameObject.GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = redLightSprite; // set the sprite to sprite1
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    // Update is called once per frame
        void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime > waitTimer)
        {
            tempTime = 0;
            ChangeSprite();
        }
    }


    /**
     * Switch between red/yellow/green light
     */
    void ChangeSprite()
    {
        if (spriteRenderer.sprite == redLightSprite)
        {
            spriteRenderer.sprite = greenLightSprite;
            gameObject.tag = "runTrigger";
        }
        else if (spriteRenderer.sprite == yellowLightSprite)
        {
            spriteRenderer.sprite = redLightSprite;
            gameObject.tag="stopTrigger";
        } else
        {
            spriteRenderer.sprite = yellowLightSprite;
            gameObject.tag = "runTrigger";
        }
    }
}
