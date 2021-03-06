using System.Collections;
using UnityEngine.UI;
using UnityEngine;

//Script used for printing text on UI
//character by character with a delay
public class TextPrinter : MonoBehaviour
{
    //Variables
    public float delay = 0.05f;
    public string fullText;
    private string currentText = "";

    //References
    public GameObject nextLine;

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

            //Play next text if present
            if (i == fullText.Length && nextLine != null)
            {
                nextLine.SetActive(true);
            }
        }
    }
}
