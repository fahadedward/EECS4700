using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScoring : MonoBehaviour
{
    bool isNetOn;
    Basketball basketball;
        void Start()
    {
        isNetOn = true;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(TurnOn());
        }
    }

    IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
