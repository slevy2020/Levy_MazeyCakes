using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour {

  void Start () {
    Button quit = GetComponent<Button>();
    quit.onClick.AddListener(QuitGame);
  }

  void QuitGame () {
    Debug.Log("Quit");
    Application.Quit();
  }
}
