using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;

    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    Transform cam;

    float speed = 6f;

    Vector3 playerMovement = Vector3.zero;

    Vector2 mover;
    private readonly float smoothing = 0.1f;
    float smoothVelocity;
    Basketball ball;
    Vector3 completeMoveDirection;
    [SerializeField]
    GameObject mainGround;

    int toyCounter;

    float jumpSpeed;
    bool charging;
    bool releasing;

    // ChangingLocations changingLoc;
    //Portals portals;
    public int ToyCounter
    {
        get { return toyCounter; }
        set { toyCounter = value; }
    }
    public bool Charging
    {
        get { return charging; }
        set { charging = value; }
    }
    public bool Releasing
    {
        get { return releasing; }
        set { releasing = value; }
    }
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        ball = FindObjectOfType<Basketball>();
        //changingLoc = FindObjectOfType<ChangingLocations>();
        // portals = FindObjectOfType<Portals>();
        // using the code below is instead of having the player input componenet attached to the player;
        /* Movements movement = new Movements();
         movement.PlayerMovement.Movement.performed += OnMovement;
         movement.PlayerMovement.Enable(); 
         movement.PlayerMovement.Throwing.performed += OnThrowing; */
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        mover = value.ReadValue<Vector2>();
        playerMovement = new Vector3(mover.x, 0, mover.y);
    }


    public void OnThrowing(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            charging = true;
        }
        else if (value.canceled)
        {
            releasing = true;
        }
    }
    void FixedUpdate()
    {
        // making the player face towards the button we press, use x, z grid to visualize + top of + is 0(direction player is facing) right of + is 90, etc..
        float targetAngle = Mathf.Atan2(playerMovement.x, playerMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        // to turn the player smoothly, we use smoothdampangle and pass variables created so the player can smoothly turn
        float smoothingAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothing);
        // we do the following to have the player always face in the direction of the camera
        completeMoveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        // using transform.rotation with the angle so we can rotate the player towards the direction we want
        transform.rotation = Quaternion.Euler(0, smoothingAngle, 0);
        if (playerMovement.magnitude >= 0.001f)
        {
            controller.Move(completeMoveDirection.normalized * speed * Time.deltaTime);

        }
        if (transform.position.y > 1)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Toy"))
        {
            Destroy(other.gameObject);
            toyCounter++;
        }
    }
}

/*
// making the player face towards the button we press, use x, z grid to visualize + top of + is 0(direction player is facing) right of + is 90, etc..
float targetAngle = Mathf.Atan2(playerMovement.x, playerMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
// to turn the player smoothly, we use smoothdampangle and pass variables created so the player can smoothly turn
float smoothingAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothing);
// we do the following to have the player always face in the direction of the camera
completeMoveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
// using transform.rotation with the angle so we can rotate the player towards the direction we want
transform.rotation = Quaternion.Euler(0, smoothingAngle, 0); */
