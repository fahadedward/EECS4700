using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorSystem : MonoBehaviour
{
    private static DoorSystem _instance;
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    public static DoorSystem m_instance
    {
        get { return _instance; }
    }
    public event Action<int> doorOpenTriggerAction;  
    public void DoorOpeningTriggerEnter(int doorId)
    {      
           if(doorOpenTriggerAction != null)
        {
            doorOpenTriggerAction(doorId);
        }
    }
}
