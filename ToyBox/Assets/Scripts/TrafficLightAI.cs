using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightAI : MonoBehaviour
{
    public Sprite trafficLightRed;

    public Sprite trafficLightGreen;

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
            spriteRenderer.sprite = trafficLightRed; // set the sprite to sprite1
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


    void ChangeSprite()
    {
        if (spriteRenderer.sprite == trafficLightRed)
        {
            spriteRenderer.sprite = trafficLightGreen;
            gameObject.tag = "runTrigger";
        }
        else
        {
            spriteRenderer.sprite = trafficLightRed;
            gameObject.tag="stopTrigger";
        }
    }
}
