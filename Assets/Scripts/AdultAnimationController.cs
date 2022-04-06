using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator adultAnimator;
    [SerializeField]
    bool walking;
    Player player;
    [SerializeField]
    GameObject wife;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        player.PickingUp = true;
    }

    private void Start()
    {
        StartCoroutine(TypingAndStanding());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Moving)
        {
            adultAnimator.SetBool("isWalking", true);
        }
        else
        {
            adultAnimator.SetBool("isWalking", false);
        }
    }

    IEnumerator TypingAndStanding()
    {
        yield return new WaitForSeconds(20f);
        player.PickingUp = false;
        wife.SetActive(true);
    }
}
