using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public int _doorId;
    public bool OpeningDoor = false;
    void Start()
    {
        DoorSystem.m_instance.doorOpenTriggerAction += OpenDoor;
    }

    // Update is called once per frame
    void OpenDoor(int doorId)
    {
        if(doorId == this._doorId)
        {
            Debug.Log("DOOR IS OPENED");
        }

        if (OpeningDoor)
        {
            _doorId = doorId;
        }
    } 
}
