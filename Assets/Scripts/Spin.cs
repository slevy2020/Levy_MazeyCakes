using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

  //public variables
  public Vector3 axis; //which axis to spin on - mark the axis with a 1
  public float speed = 1.0f; //speed multiplier

  void Update () {
    //rotate the object
    float amount = speed * Time.deltaTime; //mult * time since last Update
    transform.Rotate(axis.x * amount, axis.y * amount, axis.z * amount);
  }
}
