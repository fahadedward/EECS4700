using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField]
    GameObject player, oldMan, endTab;
    [SerializeField]
    Camera mainCamera, winCamera;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winCamera.gameObject.SetActive(true);
            oldMan.gameObject.SetActive(true);
            player.SetActive(false);
            mainCamera.enabled = false;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.5f);
        endTab.gameObject.SetActive(true);

    }
}
