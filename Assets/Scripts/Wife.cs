using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Wife : MonoBehaviour
{

    [SerializeField]
    Animator wifeAnimation;
    [SerializeField]
    bool walking;
    Player player;

    GameObject playerTransform;
    Vector3 lookPosition;

    [SerializeField]
    Dialogue dialogue;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerTransform = GameObject.Find("Player");
     //   dialogue = GetComponent<Dialogue>();
     
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookPosition = playerTransform.transform.position - transform.position;
        lookPosition.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3f);
       
        //  Debug.Log("LENGTH" + kidAnimator.GetCurrentAnimatorStateInfo(0).length);
        if (player.Moving)
        {
            wifeAnimation.SetBool("isWalking", true);
        }
        else
        {
            wifeAnimation.SetBool("isWalking", false);
        }

        if (lookPosition.magnitude <= 8 && lookPosition.magnitude >= 5)
        {
            dialogue.WifeMeeting();
        }

    }
    private void FixedUpdate()
    {
        if (lookPosition.magnitude >= 5)
        {
            transform.position += (lookPosition * Time.deltaTime);
        }
    }
}  
