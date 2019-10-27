using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Tracks an instance of a slime in the scene.
/// </summary>
public class SlimeTracker : MonoBehaviour, IPointerClickHandler
{
	public bool isLocked = false;
	public int slimeMultiplier, initialMultiplier = 1;
	public int blueValue, greenValue, redValue;
	public SlimeType thisSlime;
	public Image lockImage;

	private void Start()
	{
		lockImage.enabled = isLocked;
		slimeMultiplier = initialMultiplier;
		UpdateText();
	}

	/// <summary>
	/// Increases the slime value by one.
	/// </summary>
	public void SlimeIncrement()
	{
		if (!isLocked && slimeMultiplier < 5)
		{
			slimeMultiplier++;
			UpdateText();
		}
		else
		{
			//TODO: Play error feedback.
		}
	}

	/// <summary>
	/// Resets the slime value back to one.
	/// </summary>
	public void SlimeReassemble()
	{
		if (!isLocked)
		{
			slimeMultiplier = 1;
			UpdateText();
		}
		else
		{
			//TODO: Play error feedback.
		}
	}

	public void UpdateText()
	{
		Text textSlimeTracker = GetComponentInChildren<Text>();
		textSlimeTracker.text = slimeMultiplier == 1 ? "" : slimeMultiplier.ToString();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			SlimeIncrement();
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			SlimeReassemble();
		}
	}
}

public enum SlimeType
{
	Blue, Green, Red
};