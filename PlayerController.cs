using UnityEngine;

//Script for controlling the movements of the player

public class PlayerController : MonoBehaviour
{
    //Unity references
    public CharacterController controller;
    private OptionsManager options;
    public Camera cam;
    public Camera weaponCam;
    
    //Character values
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Ground variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    //FOV variables
    public float speedModifier;
    private float playerFOV;
    private float weaponFOV = 60f;
    public float sprintFOVModifier = 1.25f;

    void Awake()
    {
        //Get reference to options manager
        options = GameObject.FindGameObjectWithTag("OptionsManager").GetComponent<OptionsManager>();
    }

    void Start()
    {
        //Set default FOV
        playerFOV = cam.fieldOfView;
    }

    void FixedUpdate()
    {
        //Apply FOV from settings
        playerFOV = options.FOV_setting;

        //Check if player is on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Reset momentum if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Sprinting variables and input
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        bool isSprinting = sprint && moveVertical > 0;

        float speed = baseSpeed;
        if (isSprinting)
        {
            speed *= speedModifier;
        }

        //Calculate movement vector
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        //Move player character
        controller.Move(move * speed * Time.deltaTime);

        //Check if player can jump
        if (isGrounded == true)
        {
            //Jump mechanic
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        //Add gravity to player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //FOV change when sprinting
        if (isSprinting)
        {
            //FOV up
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, playerFOV * sprintFOVModifier, Time.deltaTime * 8f); //Player main camera
            weaponCam.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, weaponFOV * sprintFOVModifier, Time.deltaTime * 8f); //Weapon camera
        }

        else
        {
            //FOV down
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, playerFOV, Time.deltaTime * 8f); //Player main camera
            weaponCam.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, weaponFOV, Time.deltaTime * 8f); //Weapon camera
        }
    }
}
