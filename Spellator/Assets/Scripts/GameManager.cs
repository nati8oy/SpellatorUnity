﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;

    //[SerializeField] private AudioClip bgMusic;
    //public float audioTrackSelection;
    private AudioSource gameManagerAudioSource;


    [Header("Scriptable objects")]
    public TileBagSO currentBag;
    [Space]


    [SerializeField] private AudioClip gameOverAudio;
    [SerializeField] private AudioClip bigScore;


    [Header("UI Panels")]
    [SerializeField] private RectTransform pauseMenu;
    [SerializeField] private RectTransform ruleDetailPanel;
    [SerializeField] private RectTransform gameOverPanel;
    [SerializeField] private RectTransform levelCompleteMenu;


    [Space]
    //  public string allLetters;
    [SerializeField] public TextAsset externalBagTXT;



  
    private SpecialMeterClass specialMeter = new SpecialMeterClass();

    public ConfigSO configData;


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



        //Auto load the data from the Game State file when the game manager loads
        GetComponent<GameState>().LoadGameData();
        //SaveSystem.LoadGameData();



        //allLetters = externalBagTXT.text;

        //add the letters to the bag List within the TileBag class
        //TileBag lettersBag = new TileBag();
        //lettersBag.AddLettersToDictonary();


      


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


    public void MainMenu()
    {
        //save before the game goes back to the main menu.
        GetComponent<GameState>().SaveGameData();

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void PauseGame()
    {

        pauseMenu.gameObject.SetActive(true);
    }

    public void LevelComplete()
    {
        levelCompleteMenu.gameObject.SetActive(true);

    }

    public void BeginGame()
    {

        ruleDetailPanel.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        GameObject.Find("Pause Menu").SetActive(false);

    }

    public void StartSetup()
    {

        //add the letters to the bag List within the TileBag class
       // TileBag lettersBag = new TileBag();
        
    }




}
