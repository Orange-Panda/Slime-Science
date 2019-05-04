using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SlimeScience;


public class MainMenu : MonoBehaviour
{
    //SlimeBalance SB = new SlimeBalance();

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
        if (GameData.control) { GameData.control.currentLevel = 1; }
    }

    public void LoadLevel()
    {
        if (GameData.control)
        {
            Debug.Log("Attempting to load with puzzle set " + GameData.control.currentLevel);
            if (Application.CanStreamedLevelBeLoaded("Level" + GameData.control.currentLevel))
                SceneManager.LoadScene("Level" + GameData.control.currentLevel);
            else { SceneManager.LoadScene("GameComplete"); }
            
        }
        else { SceneManager.LoadScene("StartMenu"); }
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Attempting to quit the application");
    }

}
