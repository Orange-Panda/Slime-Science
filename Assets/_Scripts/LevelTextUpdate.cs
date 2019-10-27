using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets the text to reflect the current level.
/// </summary>
public class LevelTextUpdate : MonoBehaviour
{
	void Start ()
	{
        if (GameData.control)
        {
            Text levelText = GetComponentInChildren<Text>();
            levelText.text = string.Format("LEVEL {0}", GameData.control.currentLevel);
        }
		else
		{
			Text levelText = GetComponentInChildren<Text>();
			levelText.text = "LEVEL UNKNOWN";
		}
    }
}
