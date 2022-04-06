using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DoorSystem : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    [SerializeField]
    Animation openDoor;

    [SerializeField]
    private DoorType doorType;

    [SerializeField]
    Sounds openDoorSound;
    private void Awake()
    {
        
    }
    public enum DoorType
    {
        Sidedoor,
        Frontdoor
    }
    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    private void Update()
    {
        if(this.gameObject.name == "Door 1")
        {
            Debug.Log("DOOR 1");
        }
    }
    public void OpenDoor()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            this.openDoor.Play();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            openDoorSound.OpenDoorSound();
        }       
      //  openDoor.enabled = false;
    }
}

