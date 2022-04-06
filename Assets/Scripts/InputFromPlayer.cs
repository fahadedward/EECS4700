using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputFromPlayer : MonoBehaviour
{

    [SerializeField]
    GameObject[] camAndPlayer;

    [SerializeField]
    Transform wife;
    [SerializeField]
    Player player;

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

    [SerializeField]
    Dialogue dialogue;
    public string PlayerInput
    {
        get { return playerInput; }
        set { playerInput = value; }
    }
    void Start()
    {
        portal = FindObjectOfType<Portals>();
        dialogue = gameObject.GetComponent<Dialogue>();
        player = GameObject.Find("Player").GetComponent<Player>();
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
                //  camAndPlayer[0].SetActive(false);
                //  camAndPlayer[1].SetActive(false);
                player.PickingUp = true;
                camAndPlayer[2].SetActive(true);
                doorCode.SetActive(true);
            } else
            {
                //  camAndPlayer[0].SetActive(true);
                //  camAndPlayer[1].SetActive(true);
                player.PickingUp = false;
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
            player.PickingUp = false;
            portal.PortalEnum = Portals.Portal.BPortal;
            doorOpening[0].Play();
            doorOpening[1].Play();
            camAndPlayer[2].SetActive(false);
            doorCode.SetActive(false);
            wife.gameObject.SetActive(false);
        }
        else
        {
            dialogue.OpeningDoor();
        }
    }
}
