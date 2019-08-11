using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    [SerializeField] private RectTransform pauseMenu;
    [SerializeField] private RectTransform wordList;

    public string allLetters;
    [SerializeField] public TextAsset externalBagTXT;

    //the list for all the words currently that have been made
    public WordData currentWordList;


    [SerializeField] private RectTransform gameOverPanel;


    [SerializeField] private GameObject messageObject;



    public GameObject MessageObject
    {
        get { return messageObject; }
        set { MessageObject = value; }
    }


  
    private SpecialMeterClass specialMeter = new SpecialMeterClass();



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

    private int totalScore;

    public int TotalScore
    {
        get { return totalScore; }
        set { TotalScore = value; }
    }

//    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveScoreText;

    public Text LiveScoreText
    {
        get { return liveScoreText; }
        set { LiveScoreText = value; }
    }



  //  public GameObject[] rackSpots;


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


    // rackSpots =  GameObject.FindGameObjectsWithTag("TileHolder");


    // var specialButton = GameObject.Find("SpecialButton").GetComponent<Button>();
    //  specialButton.interactable = false;


    allLetters = externalBagTXT.text;

        //add the letters to the bag List within the TileBag class
        TileBag lettersBag = new TileBag();
        lettersBag.AddLettersToDictonary();




        gameManagerAudioSource = GetComponent<AudioSource>();

        gameManagerAudioSource.loop = true;


            //set scores to blank
        liveScoreText.text = "";

        //make the send button inactive on start up
        DictionaryManager.Instance.sendButton.interactable = false;
    }

    public void GameOverMethod()
    {

        
       gameOverPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlayAudio(gameOverAudio);

    }

    public void ResetGame()
    {
        TileBag.pointsDictionary.Clear();
        CountDown.timeLeft = 75;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Points.liveScore = 0;
        Points.totalScore = 0;

    }


    public void PauseGame()
    {

        pauseMenu.gameObject.SetActive(true);
    }


    public void ResumeGame()
    {
        GameObject.Find("Pause Menu").SetActive(false);

    }

    public void ShowWordList()
    {
        wordList.gameObject.SetActive(true);
    }

    public void CloseWordList()
    {
        GameObject.Find("Word List").SetActive(false);
    }

    public void StartSetup()
    {

        //add the letters to the bag List within the TileBag class
        TileBag lettersBag = new TileBag();

    }

}
