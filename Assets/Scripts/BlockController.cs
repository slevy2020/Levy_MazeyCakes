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

  void OnCollisionEnter () {
    Debug.Log("Block hit");
    //flip the direction
    direction *= -1;
  }
}
