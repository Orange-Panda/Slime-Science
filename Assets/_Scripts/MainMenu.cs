using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains methods for use with main menu buttons.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
		GameData.control.currentLevel = 1;
		SceneManager.LoadScene("Level1");
    }

    public void LoadLevel()
    {
		if (Application.CanStreamedLevelBeLoaded("Level" + GameData.control.currentLevel))
		{
			SceneManager.LoadScene("Level" + GameData.control.currentLevel);
		}
		else
		{
			SceneManager.LoadScene("GameComplete");
		}
	}

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
