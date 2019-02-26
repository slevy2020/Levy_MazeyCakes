using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

  //public variables
  public float movementSpeed = 1.0f; //multiplier to adjust movement rate
  float mouseSensitivity = 5.0f; //multiplier to adjust mouse movement rate
  float rotUDrange = 45.0f; //range to look up and down in degrees
  public GameObject[] spawnLocs; //the portIn objects to transport to

  //private variables
  private CharacterController cc;
  private float forwardSpeed; //relative amount to move forward
  private Vector3 move; //the direction of magnitude to move forward
  private float sideSpeed; //relative amount to move sideways
  private float rotLR; //relative amount to turn left and right
  private float rotUD; //the current up/down orientation
  private bool hitPortal; //whether or not the player has stepped on a portal

  void Start () {
    //position the camera node at the start location
    PortOut("0");
    //gain access to the character controller component
    cc = GetComponent<CharacterController>();
    //keep track of the local rotation of the camera - b/c the 360 wrap
    rotUD = 0;
    //init portal state
    hitPortal = false;
  }

  void Update () {
    //rotation
    rotLR = Input.GetAxis("Mouse X") * mouseSensitivity;
    transform.Rotate(0, rotLR, 0); //rotate the camera node left and right
    rotUD -= Input.GetAxis("Mouse Y") * mouseSensitivity; //(-= to invert)
    rotUD = Mathf.Clamp(rotUD, -rotUDrange, rotUDrange); //keep it within range
    Camera.main.transform.localRotation = Quaternion.Euler(rotUD, 0, 0); //rotate the camera, not the node
    //movement
    forwardSpeed = Input.GetAxis("Vertical") * movementSpeed; //how far to move forwards or backwards
    sideSpeed = Input.GetAxis("Horizontal") * movementSpeed; //how far to move left or right
    move = new Vector3(sideSpeed, 0, forwardSpeed); //vector pointing in direction of desired movement
    move = transform.rotation * move; //adjust the vector from the mouse
    // only move if we haven't just stepped on a portal
    if (!hitPortal) {
	     cc.SimpleMove(move); // tell the character controller to move along the provided vector
     } else {
	      // that means we just hit the portal and teleported so we can reset hitPortal
	     hitPortal = false;
     }
  }

  void PortOut (string key) {
    //using a portal to change location - key is the string index to port to
    int index = int.Parse(key); //convert string key to int index
    //Debug.Log("In PortOut: " + key);
    transform.position = spawnLocs[index].transform.position;
    //reset portal state
    hitPortal = true;
  }

  void BlockShove (Vector3 shoveSpeed) {
    //called by BlockController - block hit player so push the player
    cc.SimpleMove(shoveSpeed*10); //add a bit more to the shove vector
  }
}
