using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : MonoBehaviour {

  //public variables
  public GameObject gemBlue;
  public GameObject gemGreen;
  public GameObject gemOrange;
  public GameObject gemRed;

  void OnTriggerEnter() {
    gemBlue.SendMessage("Activate");
    gemGreen.SendMessage("Activate");
    gemOrange.SendMessage("Activate");
    gemRed.SendMessage("Activate");
  }
}
