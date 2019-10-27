using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hides interactablility with the button when there is no game session to load.
/// </summary>
public class HideInteractivity : MonoBehaviour
{
	void Start ()
	{
		gameObject.GetComponent<Button>().interactable = GameData.control.currentLevel >= 2;
    }
}
