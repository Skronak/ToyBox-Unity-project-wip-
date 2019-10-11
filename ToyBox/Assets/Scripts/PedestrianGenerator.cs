using System.Collections;
using UnityEngine;

public class PedestrianGenerator : MonoBehaviour
{
    public GameObject pedestrian;
    public int nbPedestrian;
    public int delay;
    private bool generateRight = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= nbPedestrian; i++)
        {
            Invoke("generatePedestrian", delay*i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void generatePedestrian()
    {
        pedestrian.GetComponent<PedestrianAI>().isWalkingRight = generateRight;
        pedestrian.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX=!generateRight;
        Instantiate(pedestrian, new Vector3(transform.position.x, pedestrian.transform.position.y, pedestrian.transform.position.z), transform.rotation);
        generateRight = !generateRight;
    }
}
