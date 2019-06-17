using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ObjectDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 groundPosition;
    
    public GameObject previewGameObjectRef;

    private GameObject previewGameObjectCopy;

    private int originLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("eee");
        EventSystem.current.GetComponent<CameraDragMove>().enabled = false;
        originLayer = gameObject.layer;
        gameObject.layer=11; // ignoreAllCollision layer
        
        groundPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
        groundPosition.y=groundPosition.y+1;
        previewGameObjectCopy = Instantiate(previewGameObjectRef, transform.position, transform.rotation);
        previewGameObjectCopy.transform.localScale = previewGameObjectRef.transform.localScale;
    }

    public void OnDrag(PointerEventData data){
        Debug.Log("drag");
         Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.position = new Vector3(cursorPos.x, cursorPos.y, transform.position.z);
         previewGameObjectCopy.transform.position = new Vector2(cursorPos.x, groundPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData){
        gameObject.layer=originLayer;
        EventSystem.current.GetComponent<CameraDragMove>().enabled = true;
        // transform.position = new Vector3(previewImage.transform.position.x, previewImage.transform.position.y, previewGameObject.transform.position.z);
        Destroy(previewGameObjectCopy);
    }

}
