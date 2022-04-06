using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator kidAnimator;
    [SerializeField]
    bool walking;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("LENGTH" + kidAnimator.GetCurrentAnimatorStateInfo(0).length);
        if (player.Moving)
        {
            kidAnimator.SetBool("isWalking", true);
        }
        else
        {
            kidAnimator.SetBool("isWalking", false);
        }

        if (player.PickingUp)
        {
            kidAnimator.SetBool("isPickingUp", true);

        }
        if (kidAnimator.GetCurrentAnimatorStateInfo(0).IsName("PickUpEyeLevel"))
        {
            kidAnimator.SetBool("isPickingUp", false);
            
            StartCoroutine(TurningAnimFalse());
            StartCoroutine(AnimationFinish());
            
          //  Debug.Log("ENTERED HERE");
        }
    }

    IEnumerator AnimationFinish()
    {
        
        yield return new WaitForSeconds(2f);
        player.PickingUp = false;

    }
    IEnumerator TurningAnimFalse()
    {
        yield return new WaitForSeconds(0.1f);
        
    }
}
