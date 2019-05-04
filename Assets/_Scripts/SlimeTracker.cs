using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SlimeScience;

public class SlimeTracker : MonoBehaviour, IPointerClickHandler {

    public bool isLocked = false;
    public int slimeMultiplier, initialMultiplier = 1;
    public int blueValue, greenValue, redValue;
    //public string TextCounter;
    public enum SlimeType { Blue, Green, Red };
    public SlimeType thisSlime;
    
    SlimeBalance SB = new SlimeBalance();

    private void Start()
    {
        GameObject lockedImage = GameObject.Find("" + gameObject.name + "/TheLock");
        if (isLocked) { lockedImage.SetActive(true); }
        else { lockedImage.SetActive(false);  }
        slimeMultiplier = initialMultiplier;
        UpdateText();
    }

    public void SlimeIncrement()
    {
        if (!isLocked)
        {
            if (slimeMultiplier < SB.maxSlimes) { slimeMultiplier++; UpdateText(); }
            else { } // play error sound TODO
        }
        else
        {
            // play error sound TODO
        }

    }

    public void SlimeReassemble()
    {
        if (!isLocked)
        {
            slimeMultiplier = 1;
            UpdateText();
        }
        else
        {
            // play error sound TODO
        }
    }

    public void UpdateText()
    {
        Text textSlimeTracker = GetComponentInChildren<Text>();
        if (slimeMultiplier == 1) { textSlimeTracker.text = ""; }
        else { textSlimeTracker.text = "" + slimeMultiplier; }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) { SlimeIncrement(); }
        else if (eventData.button == PointerEventData.InputButton.Right) { SlimeReassemble(); }
    }
}
