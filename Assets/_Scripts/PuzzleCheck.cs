using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SlimeScience;

public class PuzzleCheck : MonoBehaviour {

    public int redSum, blueSum, greenSum;
    private bool checkConfirmed = false;
    public GameObject victoryScreen;
    //public GameObject sumView;
    //SlimeBalance SB = new SlimeBalance();

    public void Start()
    {
        //victoryScreen = GameObject.Find("VictoryMenu");
        //victoryScreen.SetActive(false);
    }

    public void SumSlimes()
    {
        var sceneObjects = FindObjectsOfType<GameObject>();     //Searches the scene for game objects and assigns them to sceneObjects
        ResetSums(0);                                           // Resets the value of the sums to 0

        foreach (GameObject element in sceneObjects) //Searches each gameObject in the scene for slimes.
        {
            if (element.tag == "SlimeLeft") // Executes when a slime in the left is found
            {
                var tracker = (SlimeTracker)element.GetComponent("SlimeTracker");
                LeftAdditive(element, tracker);
            }
            else if(element.tag == "SlimeRight") // Executes when a slime in the right is found
            {
                var tracker = (SlimeTracker)element.GetComponent("SlimeTracker");
                RightSubtractive(element, tracker);
            }
            else
            {
                Debug.Log("Game object rejected!");
            }
        }

        if (checkConfirmed) 
        {
            if (redSum == 0 && blueSum == 0 && greenSum == 0) // Executes if all slimes equal each other out.
            {
                LevelComplete();
            }
            else // If the slimes do not equal out than the puzzle has no been solved.
            {
                Debug.Log("The slimes are not balanced!");
            }
        }
        else { Debug.Log("Unable to find any slimes! This is probably the fault of the level generation. Otherwise Luke forgot to tag the slimes."); }

        checkConfirmed = false; //Since the check has now finished the game no longer need to know if it worked and sets it to blank for a later run.
    }

    void LeftAdditive(GameObject element, SlimeTracker tracker)
    {
        blueSum += (tracker.blueValue * tracker.slimeMultiplier);
        redSum += (tracker.redValue * tracker.slimeMultiplier);
        greenSum += (tracker.greenValue * tracker.slimeMultiplier);
        Debug.Log("Left slime '" + element.name + "' is valued at RGB (" + (tracker.redValue * tracker.slimeMultiplier) + "," + (tracker.greenValue * tracker.slimeMultiplier) + "," + (tracker.blueValue * tracker.slimeMultiplier) + ")");
        checkConfirmed = true;
    }

    void RightSubtractive(GameObject element, SlimeTracker tracker)
    {
        blueSum -= (tracker.blueValue * tracker.slimeMultiplier);
        redSum -= (tracker.redValue * tracker.slimeMultiplier);
        greenSum -= (tracker.greenValue * tracker.slimeMultiplier);
        Debug.Log("Right slime '" + element.name + "' is valued at RGB (" + (tracker.redValue * tracker.slimeMultiplier) + "," + (tracker.greenValue * tracker.slimeMultiplier) + "," + (tracker.blueValue * tracker.slimeMultiplier) + ")");
        checkConfirmed = true;
    }

    void LevelComplete()
    {
        //LUKE FIX THIS SHIT
        Debug.Log("The level is now complete!");
        if (GameData.control)
        {
            Debug.Log("" + GameData.control.currentLevel);
            GameData.control.currentLevel = ++GameData.control.currentLevel;
        }
        Instantiate(victoryScreen);
    }

    void ResetSums(int number) // Resets the value of the sums to number
    {
        redSum = number; blueSum = number; greenSum = number; return;
    }

}
