using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;

    Dialogue dialogue;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
        dialogue = gameObject.GetComponent<Dialogue>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log(keyType);
        keyList.Add(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerStay(Collider other)
    { 
        Key key = other.GetComponent<Key>();      
        if(key != null && Input.GetKeyDown(KeyCode.E))
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject); 
        }

        DoorSystem doorSystem = other.GetComponent<DoorSystem>();
        if(doorSystem != null)
        {
            if (ContainsKey(doorSystem.GetKeyType()) && doorSystem.gameObject == other.gameObject)
            {
                Debug.Log(other.gameObject);
                doorSystem.OpenDoor();
            } else
            {
                dialogue.LockedDoor();
            }
        }
    }
}
