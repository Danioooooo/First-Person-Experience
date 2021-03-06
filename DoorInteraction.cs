using UnityEngine;
using UnityEngine.UI;

//Script for door movement and interactions
public class DoorInteraction : MonoBehaviour
{
    //Variables
    public Text interactMessage;
    public bool doorOpen = false;

    //References
    public Animator anim;
    public AudioSource doorSound;

    public void Interact()
    {
        if (doorOpen == false)
        {
            doorOpen = true;
            anim.SetBool("doorOpen", true);
            doorSound.Play();
        }

        else
        {
            doorOpen = false;
            anim.SetBool("doorOpen", false);
            doorSound.Play();
        }
    }

    public void UpdateInteractionMessage()
    {
        if (doorOpen == false)
        {
            interactMessage.text = ("Press 'F' to open door");
        }

        else
        {
            interactMessage.text = ("Press 'F' to close door");
        }
    }
}
