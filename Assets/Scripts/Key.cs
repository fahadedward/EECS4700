using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField]
    private KeyType keyType;
    public enum KeyType
    {
        keyOne,
        keyTwo
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}

/*  DoorSystem doorSystem;

    private bool key1, key2;

    public bool Key1
    {
        get { return key1; }
    }
    public bool Key2
    {
        get { return key2; }
    }
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            key1 = true;     
        }
    }
*/