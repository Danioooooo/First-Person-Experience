using UnityEngine;

//Script managing player interactions in the level
public class Interaction : MonoBehaviour
{
    //Unity references
    public Camera cam;
    public LayerMask storyLayer;
    public GameObject interactText;
    public int interactRange = 5;

    void Update()
    {
        CheckForInteraction();
    }

    void CheckForInteraction()
    {
        //Check if player found interactable object
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange, storyLayer))
        {
            //Make reference to script on the object
            KeycardScannerInteract keycardScript = hit.transform.GetComponent<KeycardScannerInteract>();
            if (keycardScript != null)
            {
                if (keycardScript.hasInteracted == false)
                {
                    //Update interact message with what the player is looking at
                    interactText.SetActive(true);
                    keycardScript.UpdateInteractionMessage();

                    //Interaction button
                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        keycardScript.Interact();
                        interactText.SetActive(false);
                    }
                }
            }

            KeycardPickup keycard = hit.transform.GetComponent<KeycardPickup>();
            if (keycard != null)
            {
                if (keycard.hasInteracted == false)
                {
                    interactText.SetActive(true);
                    keycard.UpdateInteractionMessage();

                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        keycard.Interact();
                        interactText.SetActive(false);
                    }
                }
            }

            ComputerInteract computerScript = hit.transform.GetComponent<ComputerInteract>();
            if (computerScript != null)
            {
                if (computerScript.hasInteracted == false)
                {
                    interactText.SetActive(true);
                    computerScript.UpdateInteractionMessage();

                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        computerScript.Interact();
                        interactText.SetActive(false);
                    }
                }
            }

            UFO_Interact UFO_Script = hit.transform.GetComponent<UFO_Interact>();
            if (UFO_Script != null)
            {
                if (UFO_Script.hasInteracted == false)
                {
                    interactText.SetActive(true);
                    UFO_Script.UpdateInteractionMessage();

                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        UFO_Script.Interact();
                        interactText.SetActive(false);
                    }
                }
            }

            DoorInteraction doorScript = hit.transform.GetComponent<DoorInteraction>();
            if (doorScript != null)
            {
                interactText.SetActive(true);
                doorScript.UpdateInteractionMessage();

                if (Input.GetKeyUp(KeyCode.F))
                {
                    doorScript.Interact();
                    interactText.SetActive(false);
                }
            }

            Store storeScript = hit.transform.GetComponent<Store>();
            if (storeScript != null)
            {
                interactText.SetActive(true);
                storeScript.UpdateInteractionMessage();

                if (Input.GetKeyUp(KeyCode.F))
                {
                    storeScript.OpenStore();
                    interactText.SetActive(false);
                }
            }
        }

        //If ray finds no interactable object
        else
        {
            interactText.SetActive(false);
        }
    }
}
