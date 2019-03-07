using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

  //public variables
  public Texture wheelTex; //wheel texture applied when unlocked
  public GameObject gemObj; //what gem does this wheel control
  public int symbolPos; //position of the symbol that activates the gem - 1-5

  //private variables
  private bool locked; //is this wheel locked
  private bool spin; //should the wheel rotate
  private float speed; //how fast the wheel should rotate
  private float rot; //store the current rotation before stopping
  private float deltaRot; //how far to spin before stopping

  void Start() {
    //init the Wheel
    locked = true; //start with the wheel locked
    spin = false; //don't spin
    speed = 9.0f; //set how fast to spin
    rot = transform.eulerAngles.z; //store the current rotation
    deltaRot = 60.0f; //store how many degrees to spin
  }

  void Update() {
    //rotate the wheel
    if (spin) {
      transform.Rotate(0, 0, speed * Time.deltaTime);
      Debug.Log(transform.eulerAngles.z);
    }
    //have we spun far enough
    if (transform.eulerAngles.z >= (rot + deltaRot) % 360.0f &&
        transform.eulerAngles.z < (rot + deltaRot + 10) % 360.0f) {
      spin = false; //stop spinning
      rot = transform.eulerAngles.z; //store the new current rotation
      Debug.Log("stop");
    }
    //check to see if this is the correct position to activate the gem
    if ((rot >= deltaRot * symbolPos) && (rot < (deltaRot * symbolPos) + 10)) {
      //send the activate message to the gem
      gemObj.SendMessage("Activate");
    }
    else {
      //send the deactivate message to the gem
      gemObj.SendMessage("Deactivate");
    }
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
