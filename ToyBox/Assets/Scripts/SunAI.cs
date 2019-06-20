using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAI : MonoBehaviour
{
    private new Renderer renderer;
    private bool selected, validate;
    public GameObject rainObject;
    private GameObject parentGameObject;


    // Start is called before the first frame update
    void Start()
    {
        parentGameObject = this.transform.parent.gameObject;
        renderer = parentGameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Instantiate(rainObject, new Vector2(-3,5), gameObject.transform.rotation);
                validate = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "waterTrigger")
        {
            renderer.material.color = Color.red;
            selected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "waterTrigger" && !validate)
        {
            renderer.material.color = Color.white;
            //            selected = false;
        }
    }

    private void Awake()
    {
    }
}