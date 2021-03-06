using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//Script managing the main quest for the game
//(Slightly messy)
public class QuestManager : MonoBehaviour
{
    //Waypoint script references
    public Waypoint waypoint1;
    public Waypoint waypoint2;
    public Waypoint waypoint3;

    //Waypoint references
    public GameObject waypoint1obj;
    public GameObject waypoint2obj;
    public GameObject waypoint3obj;

    //Objective variables
    public Text objectiveText;
    private int objective;

    //References
    public KeycardPickup keycard;
    public KeycardScannerInteract scanner;
    public ComputerInteract computer;
    public AlienEggQuest eggQuest1;
    public AlienEggQuest eggQuest2;
    public AlienEggQuest eggQuest3;
    public UFO_Interact ufo1;
    public UFO_Interact ufo2;
    public UFO_Interact ufo3;

    void Start()
    {
        UpdateQuest(0);
    }

    void Update()
    {
        CurrentQuest();
    }

    //Checks the curent quest
    void CurrentQuest()
    {
        switch(objective)
        {
            case 0:
                PickupKeycard();
                break;

            case 1:
                InteractKeycardScanner();
                break;
            
            case 2:
                DestroyEggs();
                break;
            
            case 3:
                InteractComputer();
                break;

            case 4:
                DestroyUFOs();
                break;

            case 5:
                StartCoroutine(EndGame());
                break;

            case 6:
                BossDefeated();
                break;
        }
    }

    //Updates to the next quest
    void UpdateQuest(int questToSet)
    {
        objective = questToSet;
    }

    //Player picks up keycard
    void PickupKeycard()
    {
     waypoint1.targetLocation = keycard.transformPos;

        if (keycard.hasInteracted)
        {
            UpdateQuest(1);
        }
    }

    //PLayer enters area 51
    void InteractKeycardScanner()
    {
        waypoint1.targetLocation = scanner.transformPos;

        if (scanner.hasInteracted)
        {
            UpdateQuest(2);
        }
    }

    //Player destroys all alien eggs
    void DestroyEggs()
    {
        if (!eggQuest1.destroyed)
        {
            waypoint1.targetLocation = eggQuest1.transformPos;
            waypoint1obj.SetActive(true);
        }

        if (eggQuest1.destroyed)
        {
            waypoint1obj.SetActive(false);
        }

        if (!eggQuest2.destroyed)
        {
            waypoint2.targetLocation = eggQuest2.transformPos;
            waypoint2obj.SetActive(true);
        }

        if (eggQuest2.destroyed)
        {
            waypoint2obj.SetActive(false);
        }

        if (!eggQuest3.destroyed)
        {
            waypoint3.targetLocation = eggQuest3.transformPos;
            waypoint3obj.SetActive(true);
        }

        if (eggQuest3.destroyed)
        {
            waypoint3obj.SetActive(false);
        }

        if (eggQuest1.destroyed && eggQuest2.destroyed && eggQuest3.destroyed)
        {
            waypoint1obj.SetActive(true);
            UpdateQuest(3);
        }
    }

    //Player reactivates security measures
    void InteractComputer()
    {
        waypoint1.targetLocation = computer.transformPos;

        if (computer.hasInteracted)
        {
            UpdateQuest(4);
        }
    }

    //Player destroys UFOs
    void DestroyUFOs()
    {
        if (!ufo1.hasInteracted)
        {
            waypoint1.targetLocation = ufo1.transformPos;
            waypoint1obj.SetActive(true);
        }

        if (ufo1.hasInteracted)
        {
            waypoint1obj.SetActive(false);
        }

        if (!ufo2.hasInteracted)
        {
            waypoint2.targetLocation = ufo2.transformPos;
            waypoint2obj.SetActive(true);
        }

        if (ufo2.hasInteracted)
        {
            waypoint2obj.SetActive(false);
        }

        if (!ufo3.hasInteracted)
        {
            waypoint3.targetLocation = ufo3.transformPos;
            waypoint3obj.SetActive(true);
        }

        if (ufo3.hasInteracted)
        {
            waypoint3obj.SetActive(false);
        }

        if (ufo1.hasInteracted && ufo2.hasInteracted && ufo3.hasInteracted)
        {
            waypoint1obj.SetActive(true);
            UpdateQuest(5);
        }
    }

    //Finish game on credits screen
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        waypoint1obj.SetActive(false);
        waypoint2obj.SetActive(false);
        waypoint3obj.SetActive(false);
        SceneManager.LoadScene("Credits");
    }

    //Player finishes off aliens
    void KilledAliens()
    {

    }

    //Player defeats the alien boss
    void BossDefeated()
    {

    }
}
