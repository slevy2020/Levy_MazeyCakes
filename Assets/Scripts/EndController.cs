using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour {

  //public variables
  public Sprite loseBackground;
  public Sprite winBackground;

  //private variables
  private PersistentData persistentScript;
  private Text timeRemaining;
  private Image endScreen;

  void Start() {
    //get control of the persistent data
    persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
    //get control of the time remaining text object
    timeRemaining = GameObject.Find("UI Text - Time Remaining").GetComponent<Text>();
    //get control of the endscreen background
    endScreen = GameObject.Find("UI Image - End Screen").GetComponent<Image>();
    //check the win state
    if (persistentScript.win) {
      timeRemaining.enabled = true;
      endScreen.sprite = winBackground;
      timeRemaining.text = "Time Remaining: " + string.Format("{0:0}:{1:00}", persistentScript.time / 60, persistentScript.time % 60);
    } else {
      timeRemaining.enabled = false;
      endScreen.sprite = loseBackground;
    }
  }
}
