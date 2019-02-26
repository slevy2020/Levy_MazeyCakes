using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

  //public variables
  public Vector3 speed; //how fast and on what axis to move on, 0 means don't move

  //private variables
  private int direction; //what direction to move along axis

  void Start () {
    direction = 1; //start in the + direction
  }

  void Update () {
    //move the block
    transform.position += speed * direction * Time.deltaTime;
  }

  void OnCollisionEnter (Collision collision) {
    Debug.Log("Block hit");
    if (collision.gameObject.name == "Walls" ||
        collision.gameObject.name.Contains("Ramp") ||
        collision.gameObject.name.Contains("Block")) {
    //flip the direction
    direction *= -1;
    } else if (collision.gameObject.name == "CameraNode") {
      //tell the game controller to damage the player
      GameObject.Find("GameController").SendMessage("Hit", "block");
      //tell the player rig to move back a bit for player feedback
      GameObject.Find("CameraNode").SendMessage("BlockShove", speed*direction);
    }
  }
}
