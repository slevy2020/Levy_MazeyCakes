﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  //public variables
//  public Text pelletsUI; //give the player feedback
  public GameObject mazeObj; //need to access the maze models
  public GameObject pelletPrefab; //a pointer to the prefab model
  public int maxHealth = 100; //max amount of health
  public Image healthUI; //pointer to the UI element to change the source image
  public Sprite[] healthImg; //images for 0, 25, 50, 75, 100  - in that order
  public int healthHit = 10; //how much health to lose when hit by a block
  public int maxTime = 300; //in seconds, how long to play
  public Text timerUI; //pointer to timer ui
  public int pelletTime = 10; //in seconds, how much time to add for each pellet

  //private variables
//  private int pelletsCollected;
  private Dictionary<string, GameObject> keyUI = new Dictionary<string, GameObject>();
  private int health;
  private int timer;

  void Start () {
    //start with no pellets collected
//    pelletsCollected = 0;
    //init health
    health = maxHealth;
    //lay out the game elements in the maze
    LayoutMaze();
    //build UI key Dictionary
    keyUI["red"] = GameObject.Find("UI Image - keyRed");
    keyUI["green"] = GameObject.Find("UI Image - keyGreen");
    keyUI["blue"] = GameObject.Find("UI Image - keyBlue");
    keyUI["orange"] = GameObject.Find("UI Image - keyOrange");
    foreach (KeyValuePair<string, GameObject> entry in keyUI) {
      entry.Value.GetComponent<Image>().enabled = false; //make them invisible
    }
    //init and start the timer
    timer = maxTime;
    InvokeRepeating("CountDown", 1, 1); //function to call, in n1 sec, repeat every n2 sec
  }

  void Update () {
    //refresh the UI - give the player feedback
//    pelletsUI.text = "Pellets: " + pelletsCollected.ToString();
    healthUI.sprite = healthImg[health / (maxHealth / 4)];
    timerUI.text = string.Format("{0:0}:{1:00}", timer / 60, timer % 60);
  }

  void Hit (string key) {
    //a collider was hit - do something based on the provided key
    switch (key) {
      case "pellet":
        //hit a pellet - add to the timer
//        pelletsCollected += 1;
        timer += pelletTime;
        break;
      case "red":
      case "green":
      case "blue":
      case "orange":
        //hit a key -> update ui, unlock wheel
        keyUI[key].GetComponent<Image>().enabled = true;//make it visible
        //tell the wheel to unlock
        GameObject.Find("WheelObj_" + key).SendMessage("UnlockWheel");
        break;
      case "block":
        //hit by a block - lose health
        health -= healthHit;
        Debug.Log(health);
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

  void CountDown () {
    //reduce the timer by 1 sec
    timer -= 1;
  }
}
