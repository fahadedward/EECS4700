using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActionInvoker : MonoBehaviour
{
    public int doorId;
    int keyId = 5;
    void OnTriggerEnter(Collider other)
    {
        doorId = keyId;
        DoorSystem.m_instance.DoorOpeningTriggerEnter(doorId);
    }
}
