using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDialogue : MonoBehaviour
{
    Dialogue dialogue = new Dialogue();
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogue.EndGame();
        }
    }
}
