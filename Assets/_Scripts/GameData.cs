using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Manages the persistent data related to the game.
/// </summary>
public class GameData : MonoBehaviour
{
	public static GameData control;
	public int currentLevel = 1;

	void Awake()
	{
		if (control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Saves data to the disk.
	/// </summary>
	public void SaveGame()
	{
		//Create instance of SavedData
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/slimeScience.dat");
		SavedData data = new SavedData();
		data.currentLevel = currentLevel;

		//Writes instance to file.
		bf.Serialize(file, data);
		file.Close();
	}

	/// <summary>
	/// Loads data from the disk.
	/// </summary>
	public void LoadGame()
	{
		if (File.Exists(Application.persistentDataPath + "/slimeScience.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/slimeScience.dat", FileMode.Open);
			SavedData data = (SavedData)bf.Deserialize(file);
			file.Close();
			currentLevel = data.currentLevel;
		}
	}
}

[Serializable]
class SavedData
{
	public int currentLevel;
}