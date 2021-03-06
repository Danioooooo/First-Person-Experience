using UnityEngine;
using UnityEngine.UI;

//Script managing the interaction with the keycard
public class KeycardPickup : MonoBehaviour
{
    //Variables
    public Text interactMessage;
    public bool hasInteracted = false;
    public Transform transformPos;

    void Awake()
    {
        transformPos = GetComponent<Transform>();
    }

    public void Interact()
    {
        hasInteracted = true;
        Destroy(gameObject);
    }

    public void UpdateInteractionMessage()
    {
        interactMessage.text = ("Press 'F' to pick up keycard");
    }
}
