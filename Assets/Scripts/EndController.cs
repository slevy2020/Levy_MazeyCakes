using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour {

  //public variables
  public Texture loseBackground;
  public Texture winBackground;

  //private variables
  private PersistentData persistentScript;
  private Text timeRemaining;
  private Texture endScreen;

  void Start() {
    //get control of the persistent data
    persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
    //get control of the time remaining text object
    timeRemaining = GameObject.Find("UI Text - Time Remaining").GetComponent<Text>();
    //get control of the endscreen background
    endScreen = GameObject.Find("UI Image - End Screen").GetComponent<Texture>();
    //check the win state
    if (persistentScript.win) {
      timeRemaining.enabled = true;
      endScreen = winBackground;
      timeRemaining.text = "Time Remaining: " + string.Format("{0:0}:{1:00}", persistentScript.time / 60, persistentScript.time % 60);
    } else {
      timeRemaining.enabled = false;
      endScreen = loseBackground;
    }
  }
}
