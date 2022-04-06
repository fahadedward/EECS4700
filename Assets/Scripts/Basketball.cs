using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball : MonoBehaviour
{
   
    [SerializeField]
    Transform destination;
    Rigidbody rb;
    [SerializeField]
    Transform player;
    public bool canShoot;
    Vector3 distance;
    float distanceNumber;

    float ballTimer;
    Player playerScript;
    int score;
    [SerializeField]
    Text scoreText;

    public bool holdingBall;

    TeenAnimationController teenController;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

   
    private void Awake()
    {
        playerScript = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        distance = (player.transform.position - transform.position);
        distanceNumber = distance.magnitude;
        if (Input.GetKey(KeyCode.E) && distanceNumber <= 1.7f)
        {
            rb.useGravity = false;
            transform.position = destination.transform.position;
            transform.parent = GameObject.Find("BallDestination").transform;
            canShoot = true; 
            rb.velocity = Vector3.zero;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
    private void FixedUpdate()
    {  
        if (playerScript.Charging && canShoot)
        {
            ballTimer += Time.fixedDeltaTime;
            if (playerScript.Releasing && ballTimer <= 0.25f)
            {
                rb.useGravity = true;
                rb.AddForce((player.transform.forward * 300)  + (player.transform.up * 450), ForceMode.Acceleration);
                transform.parent = null;
                canShoot = false;
                playerScript.Charging = false;
                playerScript.Releasing = false;
                ballTimer = 0f;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;

            }
            else if (playerScript.Releasing && ballTimer <= 0.5f)
            {
                Debug.Log("TIMER" + ballTimer);
                rb.useGravity = true;
                rb.AddForce((player.transform.forward * 350) + (player.transform.up * 470), ForceMode.Acceleration);
                transform.parent = null;
                canShoot = false;
                playerScript.Charging = false;
                playerScript.Releasing = false;
                ballTimer = 0f;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
            else if (playerScript.Releasing && ballTimer <= 1f)
            {
                Debug.Log("TIMER" + ballTimer);
                rb.useGravity = true;
                rb.AddForce((player.transform.forward * 400) + (player.transform.up * 500), ForceMode.Acceleration);
                transform.parent = null;
                canShoot = false;
                playerScript.Charging = false;
                playerScript.Releasing = false;
                ballTimer = 0f;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
            else if (playerScript.Releasing && ballTimer <= 1.5f)
            {
                Debug.Log("TIMER" + ballTimer);
                rb.useGravity = true;
                rb.AddForce((player.transform.forward * 500) + (player.transform.up * 525), ForceMode.Acceleration);
                transform.parent = null;
                canShoot = false;
                playerScript.Charging = false;
                playerScript.Releasing = false;
                ballTimer = 0f;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
            else if (playerScript.Releasing && ballTimer >= 1.5f)
            {
                Debug.Log("TIMER" + ballTimer);
                rb.useGravity = true;
                rb.AddForce((player.transform.forward * 570) + (player.transform.up * 550), ForceMode.Acceleration);
                transform.parent = null;
                canShoot = false;
                playerScript.Charging = false;
                playerScript.Releasing = false;
                ballTimer = 0f;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Net"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("SCORE");
        }
    }
}
