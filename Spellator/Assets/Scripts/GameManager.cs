using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;

    private bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set { GameOver = value; }
    }

    [SerializeField] private Canvas tileUI;
    [SerializeField] private GameObject tile;


    private int liveScore;
    public int LiveScore
    {
        get { return liveScore; }
        set
        {
            liveScore = value;
        }
    }


    [SerializeField] private Text liveScoreText;

    public Text LiveScoreText
    {
        get { return liveScoreText; }
        set
        {
            liveScoreText = value;
        }
    }

    private int totalScore;

    public int TotalScore
    {
        get { return totalScore; }
        set { TotalScore = value; }
    }

    [SerializeField] private Text scoreText;
  


    //this is the singleton code to ensure there's not more than one instance running
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        //set scores to blank
        liveScoreText.text = "";
        scoreText.text = "";

        //make the send button inactive on start up
        DictionaryManager.Instance.sendButton.interactable = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Debug.Log("Game over man! Game over!");
        }
    }


    public void ResetScores()
    {
        //reset the score and live score
        LiveScoreText.text = "";
        liveScore = 0;
    }

    public void CalculateScores()
    {
        totalScore = totalScore + liveScore;
        scoreText.text = totalScore.ToString();
    }


}
