using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogue : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI displayedText;
    [SerializeField]
    string playerDialogue;

    private string dialogueHolder = "";
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag("Player"))
        {      
             displayedText.text = playerDialogue;
             StartCoroutine(SentenceDelay());
        }
    }

    IEnumerator SentenceDelay()
    {
        yield return new WaitForSeconds(2f);
        displayedText.text = dialogueHolder;
    }
}
