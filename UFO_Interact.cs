using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Script managing interactions with UFOs
public class UFO_Interact : MonoBehaviour
{
    //Interaction variables
    public Text interactMessage;
    public bool hasInteracted = false;
    public Transform transformPos;

    //C4 variables
    public GameObject c4;
    public float timer = 5f;
    public AudioSource c4Sound;

    void Awake()
    {
        transformPos = GetComponent<Transform>();
    }

    //UFO interaction functionality
    public void Interact()
    {
        hasInteracted = true;
        c4.SetActive(true);
        c4Sound.Play();
        StartCoroutine(C4Countdown());
    }

    public void UpdateInteractionMessage()
    {
        interactMessage.text = ("Press 'F' to plant C4").ToString();
    }


    //Explosion
    IEnumerator C4Countdown()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
