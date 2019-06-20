using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startPosition;

    public GameObject previewImage;

    private GameObject triggerPrefab;

    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Disable camera script to prevent dragdrop to affect camera
        EventSystem.current.GetComponent<CameraDragMove>().enabled = false;

        startPosition = transform.position;
        triggerPrefab = Instantiate(previewImage, Camera.main.ScreenToWorldPoint(transform.position), transform.rotation);
        triggerPrefab.transform.localScale = transform.localScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        triggerPrefab.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 10));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // unable camera dragdrop script
        EventSystem.current.GetComponent<CameraDragMove>().enabled = true;

        transform.position = startPosition;
        Destroy(triggerPrefab);
    }
}
