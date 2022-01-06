using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMug : MonoBehaviour
{
    [SerializeField]
    Transform mugDestination;
    [SerializeField]
    Transform player;
    Vector3 distance;
    float distanceNumber;

    [SerializeField]
    GameObject key;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position);
        distanceNumber = distance.magnitude;
        if (Input.GetKey(KeyCode.E) && distanceNumber <= 1.7f)
        {
          //  gameObject.SetActive(false);
            transform.position = mugDestination.transform.position;
            transform.parent = GameObject.Find("MugDestination").transform;
           // gameObject.SetActive(true);
            key.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
