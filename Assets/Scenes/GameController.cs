using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public int score = 0;
    public int highScore = 0;
    public bool inGame;

    public GameObject[] uiInGames;
    //for UI
    public Text currentScoreTxt;
    public Text highScoreTxt;
    public GameObject panelGameOver;
    Vector3 backupPos;
    Quaternion quaternion;


    private void Awake()
    {
        Instance = this;
        backupPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        quaternion = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }
    // Use this for initialization
    void Start () {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        //search all gameobject with task "inGame"
        //if (uiInGames == null)
        uiInGames = GameObject.FindGameObjectsWithTag("inGame");

        foreach (GameObject uiInGame in uiInGames)
        {
            uiInGame.SetActive(false);
        }

        panelGameOver.SetActive(false);
    }

    public void Play()
    {

        GameObject.FindGameObjectWithTag("Player").transform.position = backupPos;
        GameObject.FindGameObjectWithTag("Player").transform.rotation = quaternion;
        inGame = true;
        
        foreach (GameObject uiInGame in uiInGames)
        {
            uiInGame.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentScoreTxt.text = score.ToString();
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void GameOver()
    {
        inGame = false;
        Debug.Log("GAME OVER");
        panelGameOver.SetActive(true);
        // show your score
        panelGameOver.transform.GetChild(3).GetComponent<Text>().text = score.ToString();
        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore", score);
        }
        Restart();
    }

    public void Restart()
    {
        score = 0;
        //destroy all bullet and restart point of spaceship and canon, and coin
        var coins = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }
        foreach (GameObject uiInGame in uiInGames)
        {
            uiInGame.SetActive(false);
        }
    }
    //TODO
    public void Pause()
    {

    }
}
