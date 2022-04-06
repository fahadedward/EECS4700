using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManAnimations : MonoBehaviour
{
    [SerializeField]
    Animator oldManAnimator;
    [SerializeField]
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.Moving)
        {
            oldManAnimator.SetBool("isWalking", true);
        }
        else
        {
            oldManAnimator.SetBool("isWalking", false);
        }
    }
}
