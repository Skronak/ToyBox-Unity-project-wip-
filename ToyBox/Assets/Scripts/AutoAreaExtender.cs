using UnityEngine.EventSystems;
using UnityEngine;

public class AutoAreaExtender : MonoBehaviour
{
    public float maxLeftPosition;
    public float maxRightPosition;
    private CameraDragMove cameraScript;
    public int extendMargin=20;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript= EventSystem.current.GetComponent<CameraDragMove>();

        evaluateScenebounds();
    }

    /**
     * Evaluate most far gameobjects from each side to extends the bounds of the scene
     **/
    public void evaluateScenebounds()
    {
        GameObject[] objectsInScene = GameObject.FindGameObjectsWithTag("prefab");

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("prefab"))
        {
            if (go.transform.position.x > maxRightPosition)
            {
                maxRightPosition = go.transform.position.x;
                extendBoundRight(maxRightPosition);
            }
            else if (go.transform.position.x < maxLeftPosition)
            {
                maxLeftPosition = go.transform.position.x;
                extendBoundLeft(maxLeftPosition);
            }
        }
    }

    private void extendBoundRight(float newLimit)
    {
        cameraScript.boundRight = newLimit + extendMargin;
        ground.transform.localScale += new Vector3(newLimit, 0,0);
        ground.transform.position += new Vector3(newLimit/2, 0, 0);
    }

    private void extendBoundLeft(float newLimit)
    {
        cameraScript.boundLeft = newLimit - extendMargin;
        ground.transform.localScale += new Vector3(-newLimit, 0, 0);
        ground.transform.position -= new Vector3(-newLimit/2, 0, 0);
    }

}
