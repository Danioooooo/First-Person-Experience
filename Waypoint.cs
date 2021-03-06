using UnityEngine;
using UnityEngine.UI;

//Script for displaying waypoints for objectives
public class Waypoint : MonoBehaviour
{
    //References
    public Image indicatorImg;
    public Transform targetLocation;
    public Text distanceMeter;
    private Camera cam;
    private Vector2 pos;
    public Vector3 offset;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Ensures indicator displays within UI space
        float minX = indicatorImg.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = indicatorImg.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        //Prevent missing ref exceptions
        if (targetLocation != null)
        {
            pos = cam.WorldToScreenPoint(targetLocation.position + offset);

            if (Vector3.Dot((targetLocation.position - transform.position), transform.forward) < 0)
            {
                //Target is behind player
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }

                else
                {
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            indicatorImg.transform.position = pos;

            //Display distance to target
            distanceMeter.text = ((int)Vector3.Distance(targetLocation.position, transform.position)).ToString() + "m";
        }
    }
}
