using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeenAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator teenAnimator;
    [SerializeField]
    bool walking;
    Player player;
    Basketball basketball;

    bool holdingBall;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        basketball = FindObjectOfType<Basketball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Releasing)
        {
            teenAnimator.SetBool("isShooting", true);
        }
        if (player.Moving)
        {
            if (basketball.canShoot)
            {
                Debug.Log("WE ARE HERE");
                teenAnimator.SetBool("HoldingBall", true);
                holdingBall = teenAnimator.GetBool("HoldingBall");
                if (holdingBall)
                {
                    teenAnimator.SetFloat("BallWalk", 1f);
                }
            }
            else
            {
                teenAnimator.SetBool("HoldingBall", false);
                holdingBall = teenAnimator.GetBool("HoldingBall");
                if (!holdingBall)
                {
                    teenAnimator.SetFloat("NormWalk", 1f);
                }
            }
        }
        else
        {
            if (basketball.canShoot)
            {
                teenAnimator.SetBool("HoldingBall", true);
                holdingBall = teenAnimator.GetBool("HoldingBall");
                if (holdingBall)
                {
                    teenAnimator.SetFloat("BallWalk", 0f);
                }
            }
            else
            {
                teenAnimator.SetBool("HoldingBall", false);
                holdingBall = teenAnimator.GetBool("HoldingBall");
                if (!holdingBall)
                {
                    teenAnimator.SetFloat("NormWalk", 0f);
                    teenAnimator.SetBool("isShooting", false);
                }
            }
        }
    }
}

