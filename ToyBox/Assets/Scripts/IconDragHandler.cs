using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class IconDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector3 groundPosition;

    private Vector2 startPosition;
    
    public GameObject previewImage;

    private GameObject previewPrefab;

    public GameObject targetPrefab;
     Transform startParent;

 public void OnBeginDrag(PointerEventData eventData)
 {
    //Disable camera script to prevent dragdrop to affect camera
   EventSystem.current.GetComponent<CameraDragMove>().enabled = false;

    startPosition = transform.position;
    previewPrefab = Instantiate(previewImage, Camera.main.ScreenToWorldPoint(transform.position), transform.rotation);
    previewPrefab.transform.localScale = transform.localScale;
    groundPosition = Camera.main.ScreenToWorldPoint(Vector3.zero);
 }

 public void OnDrag(PointerEventData eventData)
 {
    transform.position = Input.mousePosition;
    previewPrefab.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, groundPosition.y,10));
 }

 public void OnEndDrag(PointerEventData eventData)
 {
    // unable camera dragdrop script
   EventSystem.current.GetComponent<CameraDragMove>().enabled = true;

   transform.position = startPosition;
   Instantiate(targetPrefab, new Vector3(previewPrefab.transform.position.x,previewPrefab.transform.position.y, targetPrefab.transform.position.z), previewPrefab.transform.rotation);
   Destroy(previewPrefab);
 }
}
