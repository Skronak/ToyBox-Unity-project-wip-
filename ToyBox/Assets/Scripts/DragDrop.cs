using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private bool selected;
    private Vector3 groundPosition;
    
    public GameObject previewGameObjectRef;

    private GameObject previewGameObjectCopy;

    private int originLayer;

    // Update is called once per frame
    void Update()
    {
        if (selected) {
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPos.x, cursorPos.y, transform.position.z);
            previewGameObjectCopy.transform.position = new Vector2(cursorPos.x, groundPosition.y);
//            previewImage.transform.localScale=new Vector3(transform.localScale.x, transform.localScale.y,0);

            if (Input.GetMouseButtonUp(0)) {
               gameObject.layer=originLayer;
                selected = false;
                EventSystem.current.GetComponent<CameraDragMove>().enabled = true;
               // transform.position = new Vector3(previewImage.transform.position.x, previewImage.transform.position.y, previewGameObject.transform.position.z);
                Destroy(previewGameObjectCopy);
            }
        }
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)) {
            selected = true;
            EventSystem.current.GetComponent<CameraDragMove>().enabled = false;
            originLayer = gameObject.layer;
            gameObject.layer=11; // ignoreAllCollision layer
            
            groundPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
            groundPosition.y=groundPosition.y+1;
            previewGameObjectCopy = Instantiate(previewGameObjectRef, transform.position, transform.rotation);
            previewGameObjectCopy.transform.localScale = previewGameObjectRef.transform.localScale;
        }
    }
}

