using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

  void Start () {
    Button start = GetComponent<Button>();
    start.onClick.AddListener(StartGame);
  }

  void StartGame () {
    SceneManager.LoadScene("level");
  }
}
