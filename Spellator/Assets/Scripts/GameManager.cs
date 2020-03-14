using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;


    //this manages the game skins
    public enum TileSkinType { original, dark, wood };
    public TileSkinType tileSkinType;



    //[SerializeField] private AudioClip bgMusic;
    //public float audioTrackSelection;
    private AudioSource gameManagerAudioSource;


    [Header("Scriptable objects")]
    public TileBagSO currentBag;
    public LevelManagerSO levelDetails;
    public Sprite[] gameBackgrounds;
    public Image mainBackground;

    [Space]

    public GameObject cameraObject;

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
    public bool toggle;
    private Transitions fadeManager;


    [Header("Game Setup")]
    //new Transform tiePlayedPositions;

    [SerializeField] private ParticleSystem levelCompleteParticles;

    // used to count unique words for each level
    public int newWordCounter;

   // public GameObject woodPanel;


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

        //set the game background randomly from the array
       // mainBackground.sprite = gameBackgrounds[Random.Range(0, gameBackgrounds.Length)];

        //reset all the game levels before the game starts


        //resets the current game level via the scriptable object 
        ///levelDetails.currentLevel = 0;


        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();

        //set the new word counter to 0 at the start of each level
        newWordCounter = 0;

        levelCompleteParticles.Stop();

        //toggle = true;
        //Auto load the data from the Game State file when the game manager loads


        if(GameObject.Find("GameState"))
        {
            GameObject.Find("GameState").GetComponent<GameState>().LoadGameData();
        }
        


        //start the game with the level description object active
        //GameObject.Find("Level Description Screen").SetActive(true);

        ruleDetailPanel.gameObject.SetActive(true);
        
     

        gameManagerAudioSource = GetComponent<AudioSource>();

        gameManagerAudioSource.loop = true;


        //set scores to blank
        liveScoreText.text = "";

        //make the send button inactive on start up
        DictionaryManager.Instance.sendButton.interactable = false;
    }

    public void GameOverMethod()
    {
        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

        gameOverPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[5]);

    }

    public void ResetGame()
    {
        

        TileBag.pointsDictionary.Clear();
        CountDown.timeLeft = 75;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Points.liveScore = 0;
        Points.totalScore = 0;

        //reset the overall game level
      //  gameConfig.ResetLevels();
        

        //randomly reset the level
        //LevelManager.Instance.ConstructLevelParams(LevelManager.Instance.randomLevelSelection);

    }


    public void MainMenu()
    {
        //save before the game goes back to the main menu.
        //GetComponent<GameState>().SaveGameData();

        GameObject.Find("GameState").GetComponent<GameState>().SaveGameData();


        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void PauseGame()
    {

        pauseMenu.gameObject.SetActive(true);
    }

    public void LevelComplete()
    {
        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);



        //update the total stars in your kitty.
        DictionaryManager.Instance.starsTotal += 2;
        //levelCompleteParticles.Play();


        //save the game data
        //        GetComponent<GameState>().SaveGameData();

        GameObject.Find("GameState").GetComponent<GameState>().SaveGameData();

        levelDetails.levelComplete = true;
        //display the level complete panel
        levelCompleteMenu.gameObject.SetActive(true);
//        Debug.Log("Level complete = " + levelDetails.levelComplete);
       

    }

    public void BeginGame()
    {
        //Debug.Log("button working");
        GameObject.Find("Level Description Screen").SetActive(false);
        //ruleDetailPanel.gameObject.SetActive(false);
        

    }

    public void ResumeGame()
    {
        GameObject.Find("Pause Menu").SetActive(false);

    }

    public void ShakeCamera(int shakeX, int shakeY, float duration)
    {
        iTween.PunchPosition(cameraObject, new Vector3(Random.Range(shakeX, shakeX + 10), shakeY, 0), duration);

        //iTween.PunchRotation(cameraObject, new Vector3(0, 0, 10), duration);


        //PunchRotation(GameObject target, Vector3 amount, float time)

    }


    public void StartSetup()
    {

        //add the letters to the bag List within the TileBag class
       // TileBag lettersBag = new TileBag();
        
    }

    public void CheckBagLevels()
    {
        // if there's only 20 tiles left, add 179 more from the SO
        if (TileBag.bag.Count <= 20)
        {

           //Camera.main.GetComponent<CreateNewBag>().FillBag();
            
            //grab all of the letters in the SO for the bag and put them into the bag
            foreach (string letter in currentBag.bag)
            {
                TileBag.bag.Add(letter);
               // Debug.Log("Tiles have been refilled: " + TileBag.bag.Count + " remaining");
            }
        }
       
    }




    public void ToggleSound()
    {
        toggle = !toggle;

        Debug.Log("toggle is now " + toggle);
        if (toggle)
        {
            AudioListener.volume = 1f;

        }

        else
        {
            AudioListener.volume = 0f;
        }
    }

    public void AddNewWord()
    {
        newWordCounter += 1;
    }




}
