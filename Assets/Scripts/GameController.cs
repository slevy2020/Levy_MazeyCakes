using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

  //public variables
//  public Text pelletsUI; //give the player feedback
  public GameObject mazeObj; //need to access the maze models
  public GameObject pelletPrefab; //a pointer to the prefab model
  public int maxHealth = 100; //max amount of health
  public Image healthUI; //pointer to the UI element to change the source image
  public Sprite[] healthImg; //images for 0, 25, 50, 75, 100  - in that order
  public int healthHit = 10; //how much health to lose when hit by a block
  public int maxTime = 300; //in seconds, how long to play
  public Text timerUI; //pointer to timer ui
  public int pelletTime = 10; //in seconds, how much time to add for each pellet
  public Texture gemOffTex; //the gem off texture
  public GameObject[] gemObjs; //array of pointers to the game objects
  public GameObject endObj; //pointer to the End object

  //private variables
//  private int pelletsCollected;
  private Dictionary<string, GameObject> keyUI = new Dictionary<string, GameObject>();
  private int health;
  private int timer;
  private PersistentData persistentScript;

  void Start () {
    //start with no pellets collected
//    pelletsCollected = 0;
    //hide the end object
    endObj.SetActive(false);
    //init health
    health = maxHealth;
    //lay out the game elements in the maze
    LayoutMaze();
    //build UI key Dictionary
    keyUI["red"] = GameObject.Find("UI Image - keyRed");
    keyUI["green"] = GameObject.Find("UI Image - keyGreen");
    keyUI["blue"] = GameObject.Find("UI Image - keyBlue");
    keyUI["orange"] = GameObject.Find("UI Image - keyOrange");
    foreach (KeyValuePair<string, GameObject> entry in keyUI) {
      entry.Value.GetComponent<Image>().enabled = false; //make them invisible
    }
    //init and start the timer
    timer = maxTime;
    InvokeRepeating("CountDown", 1, 1); //function to call, in n1 sec, repeat every n2 sec
    //get control of persistent data
    persistentScript = GameObject.Find("PersistentObject").GetComponent<PersistentData>();
  }

  void Update () {
    //refresh the UI - give the player feedback
//    pelletsUI.text = "Pellets: " + pelletsCollected.ToString();
    healthUI.sprite = healthImg[health / (maxHealth / 4)];
    timerUI.text = string.Format("{0:0}:{1:00}", timer / 60, timer % 60);
    //should the end object be made available
    TestGems();
  }

  void Hit (string key) {
    //a collider was hit - do something based on the provided key
    switch (key) {
      case "end":
        //hit end -- win!
        Debug.Log("Win!");
        //set win state in persistent data
        persistentScript.SetWin(true);
        //go to end screen
        SceneManager.LoadScene("end");
        break;
      case "pellet":
        //hit a pellet - add to the timer
//        pelletsCollected += 1;
        timer += pelletTime;
        break;
      case "red":
      case "green":
      case "blue":
      case "orange":
        //hit a key -> update ui, unlock wheel
        keyUI[key].GetComponent<Image>().enabled = true;//make it visible
        //tell the wheel to unlock
        GameObject.Find("WheelObj_" + key).SendMessage("UnlockWheel");
        break;
      case "block":
        //hit by a block - lose health
        health -= healthHit;
        if (health <= 0) {
          Debug.Log("you died, press f to pay respects");
          //set win state in persistent data
          persistentScript.SetWin(false);
          //go to end screen
          SceneManager.LoadScene("end");
        }
        break;
      case "fall":
        Debug.Log("it actually takes skill to lose by falling");
        //set win state in persistent data
        persistentScript.SetWin(false);
        //go to end screen
        SceneManager.LoadScene("end");
        break;
    }
  }

  void LayoutMaze () {
    //find locator objects in maze and replace them with the appropriate prefab objects
    foreach(Transform child in mazeObj.transform) {
      if (child.gameObject.name.Contains("Pellet")) {
        //switch out the locator for a pellet prefab
        Instantiate(pelletPrefab, child.position, child.rotation);
        Destroy(child.gameObject);
      }
    }
  }

  void CountDown () {
    //reduce the timer by 1 sec
    timer -= 1;
    if (timer <= 0) {
      Debug.Log("you're too slow!");
      //set win state in persistent data
      persistentScript.SetWin(false);
      //go to end screen
      SceneManager.LoadScene("end");
    }
  }

  void TestGems () {
    //if all four gems are activated then unhide the end object
    bool open = true; //temp var - start as if true
    //are all four gems activated?
    for (int i = 0; i < gemObjs.Length; i += 1) {
      if (gemObjs[i].GetComponent<Renderer>().material.mainTexture == gemOffTex) {
        open = false;
        break; //no sense checking any of the others
      }
    }
    if (open) { //all were open
      endObj.SetActive(true);
    } else {
      endObj.SetActive(false);
    }
  }

  public int GetTimer() {
    return timer;
  }
}
