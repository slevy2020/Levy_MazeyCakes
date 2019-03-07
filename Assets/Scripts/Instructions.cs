using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

  //public variables
  public bool instructionsShown;

  void Start () {
    gameObject.GetComponent<Text>().text = "Press 'I' To Show Instructions!";
    instructionsShown = false;
  }

  void Update () {
    if (Input.GetKeyDown("i")) {
      ToggleInstructions();
    }
  }

  void ToggleInstructions () {
    if (!instructionsShown) {
      gameObject.GetComponent<Text>().text = "The Mad Baker has trapped you in his maze of cake and candy! Use WASD to move, collect keys, spin the wheels, and get to the exit before time runs out! Collect strawberries to get more time! Don't get crushed by the blocks or fall into the void: bad things will happen!";
      gameObject.GetComponent<Text>().enabled = true;
      instructionsShown = true;
    } else {
      gameObject.GetComponent<Text>().enabled = false;
      instructionsShown = false;
    }
  }
}
