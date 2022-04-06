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

    GameObject wife, adult, theEnd;

    bool startDialogue;
    private void Start()
    {
        wife = GameObject.Find("Wife");
        adult = GameObject.Find("Player");
        startDialogue = true;
    }
    private void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag("Player"))
        {      
             displayedText.text = playerDialogue;
             other.gameObject.GetComponent<BoxCollider>().enabled = false;
             StartCoroutine(SentenceDelay());
        }
    }
    IEnumerator SentenceDelay()
    {
        yield return new WaitForSeconds(3f);
        displayedText.text = dialogueHolder;
        gameObject.SetActive(false);
    }

    public void LockedDoor()
    {
        displayedText.text = "Maybe I should find the proper key to open this door";
        StartCoroutine(EraseText());
    }

    public void OpeningDoor()
    {
        displayedText.text = "The name seems to be wrong, I should walk around more to remember my wife's name.";
        StartCoroutine(EraseText());
    }
    public void WifeMeeting()
    {
        if (startDialogue)
        {
            displayedText.text = "Honey... is that you?!";
            StartCoroutine(NextWife());
        }
       
    }

    IEnumerator NextWife()
    {
        yield return new WaitForSeconds(3.5f);
        startDialogue = false;
        displayedText.text = "Why did I call my wife honey... What's her name?";
        StartCoroutine(NextWifeTwo());
    }

    IEnumerator NextWifeTwo()
    {
        yield return new WaitForSeconds(3.5f);
        displayedText.text = "I need to remember my wife's name, let me walk around.";
        StartCoroutine(NextWifeThree());
    }
    IEnumerator NextWifeThree()
    {
        yield return new WaitForSeconds(3.5f);
        displayedText.text = "This is killing me... WHAT IS MY WIFE'S NAME?";
        StartCoroutine(EraseText());
    }

    IEnumerator EraseText()
    {
        yield return new WaitForSeconds(3.5f);
        displayedText.text = " ";
    }

    public void WinText()
    {
        displayedText.text = "Wow... my life really flashed before my eyes, I'm glad I remember everything & I'm okay.";
        StartCoroutine(WinText2());
    }

    IEnumerator WinText2()
    {
        yield return new WaitForSeconds(4f);
        displayedText.text = "I really shouldn't take life for granted and enjoy every second I'm on this earth";
        StartCoroutine(EraseText());
    }

    public void EndGame()
    {
        displayedText.text = "Is this a maze...? Let's find my way out.";
        StartCoroutine(EndGame2());
    }

    IEnumerator EndGame2()
    {
        yield return new WaitForSeconds(4f);
        displayedText.text = "Why is all of this happening to me?";
        StartCoroutine(EndGame3());
    }
    IEnumerator EndGame3()
    {
        yield return new WaitForSeconds(4f);
        displayedText.text = "Why is all of this happening to me?";
        StartCoroutine(EraseText());
    }
}
