using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAI : MonoBehaviour 
{
    private new Renderer renderer;
    private GameObject parentGameObject;
    private bool selected, validate;
    public List<GameObject> treeList;
    public int treeLevel;

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
                if (treeLevel < treeList.Count-1)
                {
                    treeLevel++;
                    Instantiate(treeList[treeLevel], parentGameObject.transform.position, parentGameObject.transform.rotation);
                    validate = true;
                    Destroy(parentGameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "waterTrigger")
        {           
            renderer.material.color = Color.blue;
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
