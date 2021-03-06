using UnityEngine;

//Script for controlling player camera movements
public class PlayerLook : MonoBehaviour
{
    //Camera movement values
    public Transform playerBody;
    private float xRotation = 0f;

    //References
    private OptionsManager options;

    void Awake()
    {
        options = GameObject.FindGameObjectWithTag("OptionsManager").GetComponent<OptionsManager>();
    }

    void Start()
    {
        //Remove cursor from screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get mouse movement values multiplied by sensitivity and time
        float mouseX = Input.GetAxis("Mouse X") * options.mouseSensSetting * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * options.mouseSensSetting * Time.deltaTime;

        //Camera movement calculations
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Camera movement execution
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}