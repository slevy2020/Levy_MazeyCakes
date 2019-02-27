using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour {

  //public variables
  public bool win;
  public int time;

  //private variables
  private GameController gameController;

  void Start() {
    Reset();
    //make this object persistent
    DontDestroyOnLoad(transform.gameObject);
    //get control of the game controller
    gameController = GameObject.Find("GameController").GetComponent<GameController>();
  }

  void Reset() {
    win = false;
    time = 0;
  }

  public void SetWin(bool state) {
    //record provided win state
    win = state;
    //record the time that the game was finished
    time = gameController.GetTimer();
  }
}
