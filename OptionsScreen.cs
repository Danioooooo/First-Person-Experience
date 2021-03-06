using UnityEngine;
using UnityEngine.UI;

//Script managing changes to options
public class OptionsScreen : MonoBehaviour
{
    //References
    public Slider FOV_Slider;
    public PauseScreen pause;
    private OptionsManager options;

    //Variables
    public float fovValue;

    void Awake()
    {
        options = GameObject.FindGameObjectWithTag("OptionsManager").GetComponent<OptionsManager>();

        //Sets boundaries
        FOV_Slider.minValue = options.FOV_Min;
        FOV_Slider.maxValue = options.FOV_Max;

        //Prevent slider from defaulting to 0
        FOV_Slider.value = options.FOV_setting;
    }

    void Update()
    {
        options.FOV_setting = fovValue;
    }

    public void UpdateFOV(float fov)
    {
        fovValue = fov;
    }

    public void UpdateVolume(float vol)
    {

    }

    public void ExitOptions()
    {

    }
}
