using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (GameData.control)
        {
            Text levelText = GetComponentInChildren<Text>();
            levelText.text = "LEVEL " + GameData.control.currentLevel;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
