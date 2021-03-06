using UnityEngine;

//Script for spinning the camera in menu
public class CameraSpin : MonoBehaviour
{
    //Variables
    public float speed = 10f;
    public GameObject cam;

    void Update()
    {
        //Spin camera in spot
        transform.RotateAround(cam.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
