using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingItems : MonoBehaviour
{
    [SerializeField]
    Transform player;
    Vector3 distance;
    float distanceNumber;
    [SerializeField]
    Transform destination;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position);
        distanceNumber = distance.magnitude;
        if (Input.GetKey(KeyCode.E) && distanceNumber <= 1.7f)
        {
            transform.position = destination.transform.position;
            transform.parent = GameObject.Find("MugDestination").transform;
        }
    }
}
