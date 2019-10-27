using UnityEngine;

/// <summary>
/// Checks all the slimes in the scene and declares if the puzzle has been solved or not.
/// </summary>
public class PuzzleCheck : MonoBehaviour
{
	public int redSum, blueSum, greenSum;
	public GameObject victoryScreen;

	/// <summary>
	/// Checks the puzzle state and judges accordingly.
	/// </summary>
	public void SumSlimes()
	{
		redSum = 0;
		blueSum = 0;
		greenSum = 0;

		foreach (SlimeTracker tracker in FindObjectsOfType<SlimeTracker>())
		{
			//TODO: Avoid using tags for this.
			if (tracker.tag == "SlimeLeft")
			{
				blueSum += tracker.blueValue * tracker.slimeMultiplier;
				redSum += tracker.redValue * tracker.slimeMultiplier;
				greenSum += tracker.greenValue * tracker.slimeMultiplier;
			}
			else if (tracker.tag == "SlimeRight")
			{
				blueSum -= tracker.blueValue * tracker.slimeMultiplier;
				redSum -= tracker.redValue * tracker.slimeMultiplier;
				greenSum -= tracker.greenValue * tracker.slimeMultiplier;
			}
		}

		bool balanced = redSum == 0 && blueSum == 0 && greenSum == 0;
		if (balanced)
		{
			LevelComplete();
		}
		else
		{
			//TODO: Failed logic.
		}
	}

	/// <summary>
	/// Runs the progression effects for a level being solved.
	/// </summary>
	void LevelComplete()
	{
		if (GameData.control)
		{
			GameData.control.currentLevel++;
		}

		Instantiate(victoryScreen);
	}
}
