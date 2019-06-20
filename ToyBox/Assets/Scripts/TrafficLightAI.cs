using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightAI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trafficLight");
    }

    // Update is called once per frame
        void Update()
    {
        
    }
}
