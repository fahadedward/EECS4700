using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField]
    AudioSource audioWarp, audioDoor;
  public void PlayWarp()
    {
        audioWarp.Play();
    }

    public void OpenDoorSound()
    {
        audioDoor.Play();
    }
}
