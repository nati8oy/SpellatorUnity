using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;

    //[SerializeField] private AudioClip bgMusic;
    //public float audioTrackSelection;
    private AudioSource gameManagerAudioSource;

    [SerializeField] private AudioClip gameOverAudio;
    [SerializeField] private AudioClip bigScore;

    [SerializeField] private RectTransform gameOverPanel;

    //[SerializeField] private GameObject ActiveWordPosition;

    public RectTransform GameOverPanel
    {
        get { return gameOverPanel; }
        set { GameOverPanel = value; }
    }

    private bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set { GameOver = value; }
    }


    private int liveScore;
    public int LiveScore
    {
        get { return liveScore; }
        set
        {
            liveScore = value;
        }
    }

    //holds the data for the most recent score the points text can access it
    public int mostRecentScore;

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
  


    //content for game over variables
    [SerializeField] private Text finalScore;
    [SerializeField] private Text finalWordTally;

    private int setTimerTo = 60;

    public int SetTimerTo
    {
        get { return setTimerTo; }
    }


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

       
        //Debug.Log(messageHolder.transform.position);
        

        gameManagerAudioSource = GetComponent<AudioSource>();

        gameManagerAudioSource.loop = true;


            //setTimerTo = 20;
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
          //  Debug.Log("Game over man! Game over!");
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

        //check to see if there's a multiplier
        if( DictionaryManager.Instance.Multiplier >= 3)
        {
            totalScore = totalScore + (liveScore* DictionaryManager.Instance.Multiplier);
            mostRecentScore = liveScore * DictionaryManager.Instance.Multiplier;
        }

        //otherwise just do the standard score adding.
        else
        {
            totalScore = totalScore + liveScore;
            mostRecentScore = LiveScore;
        }


        //add audio if the score of the last word was bigger than 50 points
        if (mostRecentScore >= 50)
        {
            AudioManager.Instance.PlayAudio(bigScore);
        }


        scoreText.text = totalScore.ToString();
    }




    public void GameOverMethod()
    {

       gameOverPanel.gameObject.SetActive(true);
       finalScore.text = totalScore.ToString();
        finalWordTally.text = DictionaryManager.Instance.TotalWordsMade.ToString();
        AudioManager.Instance.PlayAudio(gameOverAudio);

    }

    public void ResetGame()
    {
        ResetScores();
        setTimerTo = 60;
        totalScore = 0;
        //DictionaryManager.Instance.TotalWordsMade = 0;
        gameOverPanel.gameObject.SetActive(false);
        DictionaryManager.Instance.ClearWord();
        DictionaryManager.Instance.WordBeingMade = "";

    }
}
