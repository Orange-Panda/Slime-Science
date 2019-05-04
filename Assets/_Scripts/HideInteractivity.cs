using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideInteractivity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (gameObject.name == "ResumeGame" && GameData.control.currentLevel <2)
        {
            Selectable button = gameObject.GetComponent<Selectable>();
            button.interactable = false;
        }
        else
        {
            Selectable button = gameObject.GetComponent<Selectable>();
            button.interactable = true;
        }
    }
	

}
