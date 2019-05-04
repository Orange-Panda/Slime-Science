using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData : MonoBehaviour {

    public static GameData control;

    public int currentLevel = 1;

	// Use this for initialization
	void Awake () {
        if (control == null) { DontDestroyOnLoad(gameObject); control = this; }
        else if(control != this) { Destroy(gameObject); }
	}
	
    public void SaveGame()
    {
        //Creates a binary formater
        BinaryFormatter bf = new BinaryFormatter();
        //Creates and defines a file
        FileStream file = File.Create(Application.persistentDataPath + "/slimeScience.dat");

        //Creates data to write.
        SavedData data = new SavedData();
        data.currentLevel = currentLevel;

        //Writes data to file.
        bf.Serialize(file, data);
        file.Close();
    }

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