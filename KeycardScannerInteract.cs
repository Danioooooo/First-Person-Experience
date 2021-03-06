using UnityEngine;
using UnityEngine.UI;

//Script managing interactions with the keycard scanner
public class KeycardScannerInteract : MonoBehaviour
{
    //Interaction variables
    public Text interactMessage;
    public bool hasInteracted = false;
    public Transform transformPos;

    //Reference to the animation for gate movement
    public Animator anim;
    public AudioSource sound;

    void Awake()
    {
        transformPos = GetComponent<Transform>();
    }

    public void Interact()
    {
        hasInteracted = true;
        sound.Play();
        anim.SetBool("gateInteracted", true);
    }

    public void UpdateInteractionMessage()
    {
        interactMessage.text = ("Press 'F' to scan keycard").ToString();
    }
}
