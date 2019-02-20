using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

  //public variables
  public Texture wheelTex; //wheel texture applied when unlocked

  //private variables
  private bool locked; //is this wheel locked
  private bool spin; //should the wheel rotate

  void Start() {
    //init the Wheel
    locked = true; //start with the wheel locked
    spin = false; //don't spin
  }

  void OnTriggerEnter(Collider other) {
    //handle collision
    if (!locked) {
      spin = true;
    }
  }

  void UnlockWheel() {
    //unlock the wheel and set the appropriate texture - called by GameController
    locked = false;
    GetComponent<Renderer>().material.mainTexture = wheelTex;
  }
}
