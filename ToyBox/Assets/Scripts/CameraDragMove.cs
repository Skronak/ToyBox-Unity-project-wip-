using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDragMove : MonoBehaviour {
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag=false;

    // bound to block camera drag
    public float boundRight=20;
    public float boundLeft=-20;

    void Start () {
        ResetCamera = Camera.main.transform.position;
    }

    void LateUpdate () {
        if (Input.GetMouseButton(0)) {
            if (EventSystem.current.IsPointerOverGameObject()) {
                return;
            }
            Diference=(Camera.main.ScreenToWorldPoint (Input.mousePosition))- Camera.main.transform.position;
                if (Drag==false){
                    Drag=true;
                    Origin=Camera.main.ScreenToWorldPoint (Input.mousePosition);
                }
        } else {
            Drag=false;
        }
        if (Drag==true){
            Vector2 position = Origin - Diference;

            if (position.x > boundLeft && position.x < boundRight)
            {
                Camera.main.transform.position = new Vector3(position.x, Camera.main.transform.position.y, -10);
            }
        }

        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton (1)) {
            Camera.main.transform.position=ResetCamera;
        }
    }
}
