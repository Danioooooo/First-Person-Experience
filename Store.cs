using UnityEngine;
using UnityEngine.UI;

//Script for enabling the player to use in-game stores
public class Store : MonoBehaviour
{
    //UI references
    public Text interactMessage;
    public GameObject storeUI;
    public GameObject playerUI;

    //Script references
    public PlayerController playerScript;
    public PlayerLook playerLookScript;
    public Interaction interactScript;
    public WeaponManager wpnScript;

    //Page references
    public GameObject[] pages = new GameObject[0];
    private int pagePointer;

    void Awake()
    {
        storeUI.SetActive(false);
    }

    public void OpenStore()
    {
        PageSet(0);
        storeUI.SetActive(true);
        playerUI.SetActive(false);
        DisablePlayerFunctionality();
    }

    public void CloseStore()
    {
        storeUI.SetActive(false);
        playerUI.SetActive(true);
        EnablePlayerFunctionality();
    }

    public void UpdateInteractionMessage()
    {
        interactMessage.text = ("Press 'F' to open store").ToString();
    }

    //Re-enables player input
    void EnablePlayerFunctionality()
    {
        playerScript.enabled = true;
        playerLookScript.enabled = true;
        interactScript.enabled = true;
        wpnScript.wpnManagerInput = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Limits player interaction to just the store UI
    void DisablePlayerFunctionality()
    {
        playerScript.enabled = false;
        playerLookScript.enabled = false;
        interactScript.enabled = false;
        wpnScript.wpnManagerInput = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PageSwitchLeft()
    {
        if (pagePointer > 0)
        {
            PageSet(pagePointer - 1);
        }
    }

    public void PageSwitchRight()
    {
        if (pagePointer < pages.Length - 1)
        {
            PageSet(pagePointer + 1);
        }
    }

    //Sets the page to display
    void PageSet(int pageToSet)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }

        pages[pageToSet].SetActive(true);
        pagePointer = pageToSet;
    }

}
