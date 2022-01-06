using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFromPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject[] camAndPlayer;

    [SerializeField]
    GameObject doorCode;
    Vector3 distance;
    float distanceNumber;
    int ePressed;
    public string playerInput;
    [SerializeField]
    Text incorrectAnswer;

    [SerializeField]
    Animation[] doorOpening;

    Portals portal;
    public string PlayerInput
    {
        get { return playerInput; }
        set { playerInput = value; }
    }
    void Start()
    {
        portal = FindObjectOfType<Portals>();
        //doorCode.DeactivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = (camAndPlayer[0].transform.position - transform.position);
        distanceNumber = distance.magnitude;
       // Debug.Log(distanceNumber);
        if (Input.GetKeyDown(KeyCode.E) && distanceNumber <= 1.7f)
        {
            ePressed += 1;
            if(ePressed == 1)
            {
                camAndPlayer[0].SetActive(false);
                camAndPlayer[1].SetActive(false);
                camAndPlayer[2].SetActive(true);
                doorCode.SetActive(true);
            } else
            {
                camAndPlayer[0].SetActive(true);
                camAndPlayer[1].SetActive(true);
                camAndPlayer[2].SetActive(false);
                doorCode.SetActive(false);
                ePressed = 0;
            }
           
        }
    }

    public void ReadInput(string input)
    {   
        playerInput = input.ToLower();
        if(playerInput == "sarah")
        {
            Debug.Log("Open Door");
            portal.PortalEnum = Portals.Portal.BPortal;
            doorOpening[0].Play();
            doorOpening[1].Play();
        }
        else
        {
            
        }
    }
}
