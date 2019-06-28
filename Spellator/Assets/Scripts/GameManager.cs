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

    [SerializeField] private Text blueTotalScore;
    [SerializeField] private Text redTotalScore;

    [SerializeField] private RectTransform pauseMenu;

    public string allLetters;
    [SerializeField] public TextAsset externalBagTXT;




    [SerializeField] private RectTransform gameOverPanel;

    //public List<GameObject> pooledObjects = new List<GameObject>();
    //public GameObject objectToPool;
   // public int amountToPool;
   // public GameObject obj;

    [SerializeField] private GameObject messageObject;

    [SerializeField] private GameObject lifeMeter;


    public GameObject MessageObject
    {
        get { return messageObject; }
        set { MessageObject = value; }
    }


    //instance of the Points Class to handle points
    private PointsClass scoreClass;

    private int blueTotal;
    private int redTotal;

    public int BlueTotal
    {
        get { return blueTotal; }
        set { BlueTotal = value; }
    }

    public int RedTotal
    {
        get { return redTotal; }
        set { RedTotal = value; }
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


        //create an instance of the points class
        scoreClass = new PointsClass();

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
     

    }


    public void PauseGame()
    {

        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        GameObject.Find("Pause Menu").SetActive(false);

    }

    public void StartSetup()
    {

        //add the letters to the bag List within the TileBag class
        TileBag lettersBag = new TileBag();


        /*
        //instantiate all the objects to pool
        for (int i = 0; i < amountToPool; i++)
        {
            obj = Instantiate(objectToPool);

            //set object to inactive
            obj.SetActive(false);
            pooledObjects.Add(obj);


        }*/
    }


    public void CheckLifeMeter()
    {
        if (lifeMeter.transform.localScale.x <= 0)
        {
            GameOverMethod();
        }
    }

}
