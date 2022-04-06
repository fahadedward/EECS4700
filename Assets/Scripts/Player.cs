using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;

    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    Transform cam;
    
    [SerializeField]
    float speed = 4.3f;
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
    bool moving;
    bool pickingUp;

   // ChangingLocations changingLoc;
    //Portals portals;
    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }

    public bool PickingUp
    {
        get { return pickingUp; }
        set { pickingUp = value; }
    }
    public int ToyCounter
    {
        get { return toyCounter; }
        set { toyCounter = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
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
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        if (!pickingUp)
        { 
            // making the player face towards the button we press, use x, z grid to visualize + top of + is 0(direction player is facing) right of + is 90, etc..
        float targetAngle = Mathf.Atan2(playerMovement.x, playerMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        // to turn the player smoothly, we use smoothdampangle and pass variables created so the player can smoothly turn
        float smoothingAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothing);
        // we do the following to have the player always face in the direction of the camera
        completeMoveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        // using transform.rotation with the angle so we can rotate the player towards the direction we want
        transform.rotation = Quaternion.Euler(0, smoothingAngle, 0);
        }
       
        if (playerMovement.magnitude >= 0.001f && !pickingUp)
        {
            controller.Move(completeMoveDirection.normalized * speed * Time.deltaTime);
            moving = true;
        }
        else
        {
            moving = false;
        }
        if(transform.position.y > 1)
        {
            transform.position = new Vector3(transform.position.x, 1.38f, transform.position.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Toy") && Input.GetKey(KeyCode.E)) 
        {
            toyCounter++;
            pickingUp = true;
            StartCoroutine(Toy());
            Destroy(other.gameObject);
        }
    }

    IEnumerator Toy()
    {
        yield return new WaitForSeconds(1.25f);
    }
}
