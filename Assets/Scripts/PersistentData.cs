using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {

  //private variables
  private bool win;
  private int time;

  void Start () {
    Reset();
    //make this object persistent
    DontDestroyOnLoad(transform.gameObject);
  }

  void Reset () {
    win = false;
    time = 0;
  }

  public void SetWin (bool state) {
    //record provided win state
    win = state;
  }
}
