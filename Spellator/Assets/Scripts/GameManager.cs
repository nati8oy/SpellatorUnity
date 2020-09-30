using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;


    public TutorialSO tutorial;
    public GameObject tutorialSlider;


    //this manages the game skins
    public enum TileSkinType { original, dark, wood };
    public TileSkinType tileSkinType;


    //public GameObject purchaseConfirm;

    public GameObject explosionClip;
    public GameObject levelCompleteClip;
    public RectTransform mainCanvas;


    public int tileSkinSelection;

    
    //[SerializeField] private AudioClip bgMusic;
    //public float audioTrackSelection;
    public AudioSource gameManagerAudioSource;
    public GameObject bgPattern1;
    public GameObject bgPattern2;

    public Vector2 mousePos;
    public Vector2 touchPos;

    public AnimationCurve mainAnimationCurve;

    //public TileBag tileBag;

    public GameObject[] remainingTiles;


    [Header("Scriptable objects")]
    public TileBagSO currentBag;
    public LevelManagerSO levelDetails;
    public Sprite[] gameBackgrounds;
    public Image mainBackground;

    public DifficultyGradientSO difficulty;

    [Space]

    public Camera mainCamera;
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


    public AudioClip bgMusic;
    public AudioSO audioObject;


    [Header("Game Setup")]
    //new Transform tiePlayedPositions;

    //[SerializeField] private ParticleSystem levelCompleteParticles;

    // used to count unique words for each level
    public int newWordCounter;

    // public GameObject woodPanel;


    private SpecialMeterClass specialMeter = new SpecialMeterClass();

    public ConfigSO configData;

    public string ruleLetter = "P";

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
    //[SerializeField] private Text liveScoreText;
    [SerializeField] private TextMeshProUGUI liveScoreText;

    public TextMeshProUGUI LiveScoreText
    {
        get { return liveScoreText; }
        set { LiveScoreText = value; }
    }


    //this is the probability for the amount of special tiles that are appearing
    public int specialTileProbability = 5;


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

     

        //AdController.Instance.RunInterstitial();
        //turn tutorial on/off
        if (tutorial.tutorialOn)
        {
            //  TutorialActions.OnTutorialItemInitiated("initial instructions");
        }


        //set up the tile bag with all the consonants and vowels 
        //tileBag = new TileBag(55, 40);

        gameManagerAudioSource.Play();

        gameManagerAudioSource.loop = true;

        //iTween.MoveBy(bgPattern1, iTween.Hash("x", 500, "easetype", "linear", "time", 30f, "loopType", "pingPong"));
        //iTween.MoveBy(bgPattern2, iTween.Hash("x", -32, "easetype", "linear", "time", 40f, "loopType", "pingPong"));



        mainCamera = Camera.main;


        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();

        //set the new word counter to 0 at the start of each level
        newWordCounter = 0;

        //show the rules detail object
        ruleDetailPanel.gameObject.SetActive(true);

        

        //set scores to blank
        liveScoreText.text = "";



     

        //make the send button inactive on start up
        DictionaryManager.Instance.sendButton.interactable = false;
    }


    private void Update()
    {


        if (tutorial.tutorialOn)
        {
            tutorialSlider.SetActive(true);
        }


        /*

        //get the ID of the touch (first touch)
        Touch touch = Input.GetTouch(0);

        touchPos = mainCamera.WorldToScreenPoint(new Vector3(touch.position.x, touch.position.y, 0));
        
        //touch controls to add click animation
        if((touch.phase == TouchPhase.Began))
        {
            Debug.Log("touch" + touchPos);


            //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
            explosionClip = ObjectPooler.SharedInstance.GetPooledObject("Default Click");

            if (explosionClip != null)a
            {
                explosionClip.transform.position = new Vector3(touchPos.x, touchPos.y);
                explosionClip.transform.SetParent(mainCanvas.transform);
                explosionClip.SetActive(true);

            }
        }
        */



        //mouse controls to add click animation
        //mousePos = mainCamera.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));

        /*
        if (Input.GetMouseButtonUp(0))
        {
            
            Debug.Log("mouse position" + mousePos);


            //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
            explosionClip = ObjectPooler.SharedInstance.GetPooledObject("Default Click");

            if (explosionClip != null)
            {
                explosionClip.transform.position = new Vector3(mousePos.x, mousePos.y);
                explosionClip.transform.SetParent(mainCanvas.transform);
                explosionClip.SetActive(true);

            }
        }     */
    }

    //function for setting the game mode
    public void SetGameMode(string gameMode)
    {
        configData.gameMode = gameMode;
        Debug.Log("game mode set to " + gameMode);
    }


    public void GameOverMethod()
    {
        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

        gameOverPanel.gameObject.SetActive(true);
        //
        AdController.Instance.RunInterstitial();
        AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);

    }

    public void ResetGame()
    {
        //remove the listener for the DictionaryManager.Instance.MoveToPoint() function
        GameEvents.WordLengthCheckInitiated -= DictionaryManager.Instance.MoveWordToPoint;

        currentBag.letterDictionary.Clear();
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

        //GameObject.Find("GameState").GetComponent<GameState>().SaveGameData();

        //remove the listener for the DictionaryManager.Instance.MoveToPoint() function
        GameEvents.WordLengthCheckInitiated -= DictionaryManager.Instance.MoveWordToPoint;

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void PauseGame()
    {

        pauseMenu.gameObject.SetActive(true);
    }

    public IEnumerator LevelComplete()
    {


        //choose the music from the audio object scriptable object
        bgMusic = audioObject.musicBackgroundMusic[3];
        //set the audio source audio clip
        mainCamera.GetComponent<AudioSource>().clip = bgMusic;
        //play the audio clip via the source
        mainCamera.GetComponent<AudioSource>().Play();
        //loop the music
        //mainCamera.GetComponent<AudioSource>().loop = true;


        //add the level complete title
        levelCompleteClip = ObjectPooler.SharedInstance.GetPooledObject("Level Complete");

        if (levelCompleteClip != null)
        {
            levelCompleteClip.transform.position = new Vector3(320, 700);
            levelCompleteClip.transform.SetParent(mainCanvas.transform);
            levelCompleteClip.SetActive(true);
            //available = false;
        }



        //play level complete audio
        AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[16]);


        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);
        yield return new WaitForSeconds(1f);


        //update the total stars in your kitty.
        configData.totalGoldAmount += 10;
 
        GameEvents.OnSaveInitiated();
        levelDetails.levelComplete = true;

        //remove the listener for the DictionaryManager.Instance.MoveToPoint() function
        GameEvents.WordLengthCheckInitiated -= DictionaryManager.Instance.MoveWordToPoint;


        remainingTiles = GameObject.FindGameObjectsWithTag("Tile");


        //remove each of the remaining tiles on the screen one by one 
        for (int i = 0; i < remainingTiles.Length; i++)
        {
            Points.totalScore += remainingTiles[i].GetComponent<Tile>().spawnedTile.points;
            remainingTiles[i].SetActive(false);


            //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
            explosionClip = ObjectPooler.SharedInstance.GetPooledObject("Explosion");

            if (explosionClip != null)
            {
                explosionClip.transform.position = new Vector3(remainingTiles[i].transform.position.x, remainingTiles[i].transform.position.y);
                //explosionClip.transform.SetParent(GameManager.Instance.mainCanvas.transform);
                explosionClip.SetActive(true);
                //available = false;

                if (AudioManager.Instance)
                {
                    AudioManager.Instance.PlayAudioWithSource(AudioManager.Instance.sfxTilePops[Random.Range(0, 6)], gameObject.GetComponent<AudioSource>(), Random.Range(0.4f, 1f));

                }
            }
            yield return new WaitForSeconds(0.1f);

        }

        yield return new WaitForSeconds(0.8f);

        ShakeCamera(0, Random.Range(30, 40), 0.75f);

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

    /*
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
    */

   

    public void ToggleSound()
    {
       // gameManagerAudioSource.volume = 0;



        if (gameManagerAudioSource.volume == 0.5f)
        {
            gameManagerAudioSource.volume = 0;
            Debug.Log("the volume is set to " + gameManagerAudioSource.volume);

        }
        else if (gameManagerAudioSource.volume == 0)
        {
            gameManagerAudioSource.volume = 0.5f;
            Debug.Log("the volume is set to " + gameManagerAudioSource.volume);

        }

        //gameManagerAudioSource.volume = 0 !gameManagerAudioSource.volume =1;

        //gameManagerAudioSource.mute = !gameManagerAudioSource.mute;

        /*

        if (gameManagerAudioSource.volume > 0)
        {
            gameManagerAudioSource.volume = 0;
            Debug.Log(" audio off");

        }
        else {
            gameManagerAudioSource.volume = 1;
            Debug.Log(" audio on");
        }*/


        /*
        toggle = !toggle;

        Debug.Log("toggle is now " + toggle);
        if (toggle)
        {
            AudioListener.volume = 1f;

        }

        else
        {
            AudioListener.volume = 0f;
        }*/
    }

    public void AddNewWord()
    {
        newWordCounter += 1;
    }
    

}
