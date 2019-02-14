using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  //public variables
  public Text pelletsUI; //give the player feedback
  public GameObject mazeObj;
  public GameObject pelletPrefab;

  //private variables
  private int pelletsCollected;

  void Start () {
    //start with no pellets collected
    pelletsCollected = 0;
    //lay out the game elements in the maze
    LayoutMaze();
  }

  void Update () {
    //refresh the UI - give the player feedback
    pelletsUI.text = "Pellets: " + pelletsCollected.ToString();
  }

  void Hit (string key) {
    //a collider was hit - do something based on the provided key
    switch (key) {
      case "pellet":
        //hit a pellet - add to the timer
        pelletsCollected += 1;
        break;
    }
  }

  void LayoutMaze () {
    //find locator objects in maze and replace them with the appropriate prefab objects
    foreach(Transform child in mazeObj.transform) {
      if (child.gameObject.name.Contains("Pellet")) {
        //switch out the locator for a pellet prefab
        Instantiate(pelletPrefab, child.position, child.rotation);
        Destroy(child.gameObject);
      }
    }
  }
}
