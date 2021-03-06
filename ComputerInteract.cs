using UnityEngine;
using UnityEngine.UI;

//Script managing interactions with the security computer
public class ComputerInteract : MonoBehaviour
{
    //Interaction variables
    public Text interactMessage;
    public bool hasInteracted = false;
    public Transform transformPos;

    //Reference to the animation for gate movement
    public Animator anim;
    public AudioSource gate;
    public AudioSource typing;

    void Awake()
    {
        transformPos = GetComponent<Transform>();
    }

    public void Interact()
    {
        hasInteracted = true;
        gate.Play();
        typing.Play();
        anim.SetBool("gateInteracted",true);
    }

    public void UpdateInteractionMessage()
    {
        interactMessage.text = ("Press 'F' to activate security measures").ToString();
    }
}
