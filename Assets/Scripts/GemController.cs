using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

  //public variables
  public Texture activeTex; //gem texture when active
  public Texture inactiveTex; //gem texture when inactive

  //private variables


  void Start() {
    //make sure the gem starts deactivated
    Deactivate();
  }





  void Activate () {
    //activate the gem by changing the Texture - called by WheelController
    GetComponent<Renderer>().material.mainTexture = activeTex;
  }

  void Deactivate() {
    //deactivate the gem by changing the Texture - called by WheelController
    GetComponent<Renderer>().material.mainTexture = inactiveTex;
  }

  public void ActivateAll() {
    //just for testing purposes
    Activate();
  }

}
