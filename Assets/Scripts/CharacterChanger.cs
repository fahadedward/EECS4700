using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    int index = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal1"))
        {
            gameObject.transform.GetChild(index).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (other.CompareTag("Portal2"))
        {
            gameObject.transform.GetChild(index).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (other.CompareTag("Portal3"))
        {
            gameObject.transform.GetChild(index).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (other.CompareTag("BPortal"))
        {
            gameObject.transform.GetChild(index).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            index++;
        }

    }
}
