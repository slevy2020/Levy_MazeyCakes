using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

  //public variables
  public string sendToName; //the name of what game object to send a message to
  public string call; //the name of the function to call
  public string key; //key value to send to the function
  public bool delete; //should this object be destroyed

  void OnTriggerEnter () {
    //handle collision - collide this game object
  //  Debug.Log(other.gameObject.name + "hit" + this.gameObject.name);
    GameObject.Find(sendToName).SendMessage(call, key); //send a message
    if (delete) {
      Destroy(this.gameObject);
    }
  }
}
