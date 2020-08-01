using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using EZCameraShake;

public class DictionaryManager : MonoBehaviour
{

    [Header("Save Data Items")]
    // public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
    public List<string> playerWordsMade = new List<string>();

    public static DictionaryManager Instance;
    [Header("Scriptable Objects")]
    public ConfigSO wordData;
    public LevelManagerSO levelManager;

    public ParticleSystem lightbulbParticles;

    public TutorialSO tutorial;
    public Transform HUD;


    [Space()]
    [Header("Word Related Variables")]
    //    private WordData listOfWordsMade;

    public int totalWordsPlayed;
    public string longestWord;

    public GameObject multiplierClip;


    [Space()]
    [Header("Managers")]

    //uses a scritable object to hold the array for on screen messages
    [SerializeField] private MessagingSO encouragementMessages;

    //a list to store all of the values from the dictionary text file in
    private List<string> dictionaryList = new List<string>();

    private Text tileText;


    public TextMeshProUGUI starTotalText;

   // public GameObject healthParticles;

    //this sets up the field for which to add the external dictionary txt file
    [SerializeField] private TextAsset dictionaryTxtFile;

    //a list to store all of the values from the bag text file in

    private List<string> bagList = new List<string>();


    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();


    private Transitions fadeManager;

    [Space()]
    [Header("Particle Systems")]

    public GameObject newCorrectWordParticle;

    private ParticleSystem starParticles;
    //[SerializeField] private ParticleSystem correctWordParticles;
    //private ParticleSystem heartParticles;
    //[SerializeField] private ParticleSystem healthUpParticles;

    public ParticleSystem pointParticles;
    public int maximumParticles;
    public int particleSizes;
    public int particleLifetime;

    [Space()]
    [Header("Sprites")]
    [SerializeField] private GameObject correctIcon;

    [Space()]
    [Header("Audio")]

    //store all of the audio clips in this array
    public AudioClip[] allAudioClips;

    [Space()]
    [Header("UI Elements")]

    public GameObject healthBar;

    //private TextMeshProUGUI currentLevel;

    //this section is for the on screen messages
    [SerializeField] private GameObject messageParentObject;
    [SerializeField] private TextMeshProUGUI messageObject;

    private string message;

    [SerializeField] public TextMeshProUGUI multiplierText;

    [SerializeField] private GameObject pointsText;


    //reference to the send button 
    [SerializeField] public Button sendButton;



    [Space()]
    [Header("Tile Elements")]

    private GameObject PrimaryTile;
    private float primaryPosX;
    private float primaryPosY;

    private GameObject startTile;

    private GameObject pointsHolder;
    private GameObject[] agingArray;


   //[SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI scoreText;


    public GameObject[] selectedTilesArray;

    //public List<GameObject> selectedTilesArray = new List<GameObject>();

    public GameObject[] allTilesArray;


    [Space()]
    [Header("Level Data")]
    //set up the level class so it is accessible
   // public LevelClass levelData;


    //bool to check if all tiles can be replaced
    private bool resetBool;


    public bool chainFlag;

    private string mostRecentWord;
    private string startLetter;

    public string StartLetter
    {
        get { return startLetter; }
    }


    private int multiplier;
    public int Multiplier
    {
        get { return multiplier; }
    }


    //used for resetting the game
    private int totalWordsMade;

    public int TotalWordsMade
    {
        get { return totalWordsMade; }
        set { TotalWordsMade = value; }
    }


    private string wordBeingMade;

    public string WordBeingMade
    {
        get { return wordBeingMade; }
        set
        {
            wordBeingMade = value;
            //inputText.text = wordBeingMade;
        }
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

        //set total words played to that in the SO
        totalWordsPlayed = wordData.totalWordsMade;
        

//        Debug.Log("total words made " + totalWordsPlayed);
    }

    


    private IEnumerator TileCompleteSequence() {

        //create a local var from the tile TAGGED with "PrimaryTile"
        var currentPrimary = GameObject.FindGameObjectWithTag("PrimaryTile");
        GameObject scoreObject = GameObject.Find("Score");


        //if the current primary tile exists then remove it.
        if (currentPrimary)
        {
            // iTween.MoveBy(currentPrimary, iTween.Hash("y", 125, "easetype", "EaseInQuad", "time", 0.3f, "oncomplete", "RemoveTileOnComplete"));
            iTween.MoveTo(currentPrimary, iTween.Hash("y", scoreObject.transform.position.y, "x", scoreObject.transform.position.x, "easetype", "EaseInQuad", "time", 0.3f, "oncomplete", "RemoveTileOnComplete"));



        }

        //move the last tile of the word to the primary tile spot
        iTween.MoveTo(selectedTilesArray[selectedTilesArray.Length - 1], iTween.Hash("x", primaryPosX, "y", primaryPosY, "easetype", "EaseInOutCirc", "delay", 0.1*wordBeingMade.Length, "time", 0.4f, "onComplete", "SetPrimaryTile"));



        selectedTilesArray[selectedTilesArray.Length - 1].tag = "Tile";

        //for each of the tiles set a delay and remove them from the screen



            for (int i = 0; i < selectedTilesArray.Length - 1; i++)
            {
                var randomY = Random.Range(150, 340);

            //for each tile in the selectedTilesArray set the animator bool to be "true"
            //selectedTilesArray[i].GetComponent<Tile>().animator.SetBool("clearTile", true);

             

                //iTween.MoveBy(selectedTilesArray[i], iTween.Hash("y", randomY, "easetype", "easeOutSine", "time", 0.5f, "delay", (0.1f) * (i + 1), "oncomplete", "RemoveTileOnComplete"));
            iTween.MoveTo(selectedTilesArray[i], iTween.Hash("y", scoreObject.transform.position.y, "x", scoreObject.transform.position.x, "easetype", "easeOutSine", "time", 0.5f, "delay", (0.1f) * (i + 1), "oncomplete", "RemoveTileOnComplete"));;

            

            //  iTween.RotateBy(selectedTilesArray[i], new Vector3(10, 10), 1);

        }



        yield return null;

    }



    // Start is called before the first frame update
    void Start()
    {

        //find the primary tile object. This is set here so that the object doesn't get cleared away when the level/game is reset
        PrimaryTile = GameObject.Find("Primary Tile");

        //stop the lightbulb particles on load
        lightbulbParticles.Stop();

        //add MoveWordToPoint to the listener
        GameEvents.WordLengthCheckInitiated += MoveWordToPoint;

        longestWord = wordData.longestWord;

        //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
        //healthParticles = ObjectPooler.SharedInstance.GetPooledObject("Heart Particles");

        //set the list of playerWordsMade to be that of the Scriptable object's uniqueWordList
        playerWordsMade = wordData.uniqueWordsList;

        //set the scriptable object find the longest word in the list of unique words
        wordData.FindLongestWord();
      //  musicOn = wordData.musicOn;
       // sfxOn = wordData.sfxOn;

        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();

       // correctWordParticles.Stop();
       // healthUpParticles.Stop();
        //display the level which is the number of unique words made
        //currentLevel = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();

        //find the current primary tile and add its x and y positions to these vars
        primaryPosX = GameObject.Find("Primary Tile").transform.position.x;
        primaryPosY = GameObject.Find("Primary Tile").transform.position.y;


        healthBar = GameObject.Find("HealthBar");



        multiplierText.text = "";

        //add the list of words from an external txt file via the inspector
        fullDictionary = dictionaryTxtFile.text;

        //get the dictionary list of words and split them on every comma
        dictionaryList = new List<string>(fullDictionary.Split(','));

        //add each of the words within dictionaryList to the actual dictionary itself
        for (int i = 0; i < dictionaryList.Count; i++)
        {
            dictionary.Add(dictionaryList[i], 1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        

        if (Points.multiplier > 2)
        {
            //set the multiplier text 
            multiplierText.text = "x" + Points.multiplier.ToString();
        }

        else
        {
            multiplierText.text = "";
        }
        
        //set the current level (number of words) to be that of what is coming from the playerWordsMade var
        //currentLevel.text = playerWordsMade.Count.ToString();

        //set the text in the stars total text section to be the right amount.
        //starTotalText.text = goldTotal.ToString();

        //set up the primary tile particle system
       // var main = pointParticles.main;
        //set the max number of particles;
//        main.maxParticles = maximumParticles;
  //      main.startLifetime = particleLifetime;



    }


    public void CheckAndDeleteTiles()
    {

        if (tutorial.tutorialOn)
        {
            TutorialActions.OnTutorialItemInitiated("primary tile");

        }
        
        //ShowMessage();
        //update the number of words played overall - not the unique words
        wordData.totalWordsMade += 1;


        //check the word length and apply the correct amount of camera shake


        switch (WordBeingMade.Length)
        {
            case 3:
                GameManager.Instance.ShakeCamera(0, Random.Range(30, 40), 0.75f);
                break;
            case 4:
                GameManager.Instance.ShakeCamera(0, Random.Range(30, 40) * 2, 0.75f);
                break;
            case 5:
                GameManager.Instance.ShakeCamera(Random.Range(10, 15), Random.Range(30, 40) * WordBeingMade.Length, 0.75f);

                break;
            case 6:
                GameManager.Instance.ShakeCamera(Random.Range(10, 15), Random.Range(30, 40) * WordBeingMade.Length, 0.75f);
                break;
            case 7:
                GameManager.Instance.ShakeCamera(Random.Range(10, 15), Random.Range(30, 40) * WordBeingMade.Length, 0.75f);
                break;
            case 8:
                GameManager.Instance.ShakeCamera(Random.Range(10, 15), Random.Range(30, 40) * WordBeingMade.Length, 0.75f);
                break;
            case 9:
                GameManager.Instance.ShakeCamera(Random.Range(120, 140), Random.Range(100, 120), 1.8f);
                break;
            case 10:
                GameManager.Instance.ShakeCamera(Random.Range(140, 180), Random.Range(160, 180), 2f);
                break;
            case 11:
                GameManager.Instance.ShakeCamera(Random.Range(180, 200), Random.Range(200, 220), 2.2f);
                break;
        }
       

        //SET VERSION
        LevelManager.Instance.LevelGoalCheck(WordBeingMade, LevelManager.Instance.levelRuleType.ToString());


        //play the particle effects for a correct word

        //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
        newCorrectWordParticle = ObjectPooler.SharedInstance.GetPooledObject("CorrectWord");


        //set the particle effects to play for a correct word
        if (newCorrectWordParticle != null)
        {
            newCorrectWordParticle.transform.position = GameObject.Find("Primary Tile").transform.position;
            
            newCorrectWordParticle.transform.SetParent(gameObject.transform);
            newCorrectWordParticle.SetActive(true);

        }


        //reduce the age of all the remaining tiles on the board
        ReduceAge();

        //move the primary tile back to its starting position
        iTween.MoveTo(PrimaryTile, iTween.Hash("x", primaryPosX, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));

        //hide the icon that indicates that a word is correct
        correctIcon.SetActive(false);





        /////////////////////////////////////////////////////////////////////////////
        ////THIS IS WHERE THE WORDS ARE CHECKED TO SEE IF THEY ARE VALID OR NOT/////
        ////////////////////////////////////////////////////////////////////////////


        if (dictionary.ContainsKey(WordBeingMade))
        {
            //stop the lightbulb particles from playing
            lightbulbParticles.Stop();



            //play "ding" sound
            // AudioManager.Instance.PlayAudio(allAudioClips[3]);

            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[3]);

            }

            //add the word to the overall list of words being made

            //check if the multiplier is going to be broken with a 3 letter word. If so, play the sound.
            if ((multiplier >= 3) && (WordBeingMade.Length <= 3))
            {
                

                if (AudioManager.Instance)
                {
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);
                }

                Points.multiplier = 1;
            }

            //add to the multiplier
            if (WordBeingMade.Length >= 4)
            {
                Points.multiplier += 1;

                multiplierClip = ObjectPooler.SharedInstance.GetPooledObject("Multiplier");


                if (multiplierClip != null)
                {
                    multiplierClip.transform.SetParent(HUD);
                    multiplierClip.transform.position = new Vector3(106, 760);
                    multiplierClip.SetActive(true);
                    //available = false;

                }


                // particleLifetime = Random.Range(0.25 * Points.multiplier, 0.3 * Points.multiplier);
                particleSizes = Random.Range(10* Points.multiplier,15*Points.multiplier);



            }


			//if the word doesn't exist in the current list, add it to the playerWordsMade list

			if (!playerWordsMade.Contains(WordBeingMade))
			{
				playerWordsMade.Add(WordBeingMade);

                //add the word to the scriptable object as well so that it can be referenced elsewhere e.g. the main menu scene
                //wordData.uniqueWordsList.Add(WordBeingMade);

                //add the new word to the unique words per level 
                GameManager.Instance.AddNewWord();



			}

                else if (WordBeingMade.Length <= 3)
            {
                Points.multiplier = 1;
                maximumParticles = 5;
                multiplierText.text = "";
            }


            //add on screen encouragement for words above 5 letters
            if ((WordBeingMade.Length >= 5) || (Points.liveScore>=50))
            {
                //ShowMessage();

                //this chooses the kind of cross fade or screen flash to use
                fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

            }



            //loop through the array and delete each of the gameObjects in it
            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");


            foreach (GameObject tile in selectedTilesArray)
            {
               //the function that checks the animation status
                //CheckAnimationStatus(false);

                //access the script on each of the tile creators/spawners and refill the tiles
                tile.transform.parent.GetComponent<TileCreator>().RefillTiles();


                //set the tag back to "Tile"
                tile.tag = "Tile";
            }

            StartCoroutine(TileCompleteSequence());



            //add to total words made
            totalWordsMade += 1;


            //keep track of the most recently made word
            mostRecentWord = WordBeingMade;



            //split the lettters in the mostRecentWord string and grab the last one
            //
            string[] characters = new string[mostRecentWord.Length];
            for (int i = 0; i < mostRecentWord.Length; i++)
            {

                characters[i] = System.Convert.ToString(mostRecentWord[i]);

                //gets the start letter of the next word from the most recent word
                startLetter = characters[i];

            }


            //Debug.Log("Points for word: " + Points.pointsScored);
            Points.AddPoints(Points.liveScore);

            scoreText.text = Points.totalScore.ToString();



            //Clear the WordBeingMade first before setting it to be the startLetter of the next word
            WordBeingMade = "";
            WordBeingMade = startLetter;


            //sets the start letter of the next word
            //SetStartTile();

           // sendButton.interactable = false;
           
            //add the scores to the screen after adding the ints together
            //GameManager.Instance.CalculateScores();


            //clear the selectedTiles list so that it puts the new tiles in the right positions
            TileManager.Instance.ResetWordStartPoint();

            
            //set the chain flag to true so that chain mode can continue
            chainFlag = true;


        }


    }

    public void CheckWord()
    {

        var emission = lightbulbParticles.emission;

        switch (wordBeingMade.Length)
        {
            case 0:

                lightbulbParticles.Stop();
                emission.rateOverTime = 0;
                break;

            case 1:

                lightbulbParticles.Stop();
                emission.rateOverTime = 0;
                break;
            case 2:

                lightbulbParticles.Play();
                emission.rateOverTime = 10;
                break;
            case 3:

                lightbulbParticles.Play();
                emission.rateOverTime = 15;
                break;
            case 4:

                lightbulbParticles.Play();
                emission.rateOverTime = 20;
                break;
            case 5:

                lightbulbParticles.Play();
                emission.rateOverTime = 30;
                break;
            case 6:

                lightbulbParticles.Play();
                emission.rateOverTime = 40;
                break;
            case 7:

                lightbulbParticles.Play();
                emission.rateOverTime = 50;
                break;
        }


        //updates the selected tile array to be the right length
        selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");


        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            sendButton.interactable = true;

            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[2]);

            }

            if (tutorial.tutorialOn)
            {
                TutorialActions.OnTutorialItemInitiated("valid words");

            }



            //change tiles to be in the right animation state.
            //CheckAnimationStatus(true);


            //            Debug.Log("selected tile array length is: " + selectedTilesArray.Length);


            //show the icon that indicates that a word is correct
            correctIcon.SetActive(true);

        }
        else
        {
            sendButton.interactable = false;

            //change tiles to be in the right animation state.
            //CheckAnimationStatus(false);


            //hide the icon that indicates that a word is correct
            correctIcon.SetActive(false);

        }

        GameEvents.OnWordLengthCheckInitiated();

        /*
        //check the length of the word being makde and move the whole word to that point.

        switch (wordBeingMade.Length)
        {
            case 5:
                iTween.MoveTo(PrimaryTile, iTween.Hash("x", -150, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                iTween.MoveTo(PrimaryTile, iTween.Hash("x", -500, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
                break;
        }
        */





    }

    //this handles the incoming letter from the tile which is concatenated to the current "wordBeingMade"
    public void CreateWord(string theLetter)
    {
        WordBeingMade = string.Concat(WordBeingMade, theLetter);
    }



    public void ClearWord()
    {
        //stop the lightbulb particles
        lightbulbParticles.Stop();

        if (tutorial.tutorialOn)
        {
            TutorialActions.OnTutorialItemInitiated("delete button");

        }

        //shake screen
        //shake the camera
        GameManager.Instance.ShakeCamera(0, 40, 0.5f);

        //move the primary tile back to its starting position
        iTween.MoveTo(PrimaryTile, iTween.Hash("x", primaryPosX, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));

        //reset the scores
        Points.resetScores();
        sendButton.interactable = false;


        //hide the icon that indicates that a word is correct
        correctIcon.SetActive(false);


        TileManager.Instance.SelectedTiles.Clear();
        //check if the reset bool is true. If it is, delete all the tiles in the rack

        if (wordBeingMade == startLetter || wordBeingMade =="")
        {
            resetBool = true;
        }
        else resetBool = false;


        if (resetBool == true)
        {


            //reduce the age of the tiles that are on the rack currently instead of deleting them all
            ReduceAge();

            

            //remove multiplier
            if (Points.multiplier >= 3 && AudioManager.Instance)
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);
            }

            Points.multiplier = 1;
            maximumParticles = 5;
            multiplierText.text = "";

            sendButton.interactable = false;



        }

        else if (resetBool == false)
        {

            //add all the tiles with the tag "Selected" to an array

            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

            //for each of the tile objects in the selected tiles array,
            //go through and get the parent transform (which is the position game object)
            //then reset the position to that 

            //reset the animations
            //CheckAnimationStatus(false);

            foreach (GameObject tile in selectedTilesArray)

            {
         
                var getStartPos = tile.transform.parent.GetComponent<TileCreator>();
                //connect to the script of each tile, get the startPos from there (which is the starting transform of each Pos holder)
                //then run the Coroutine from the tile game object. Phew!

                iTween.MoveTo(tile, new Vector3(getStartPos.startPos.position.x, getStartPos.startPos.position.y, 0), 0.5f);
                //iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time",0.5f, "easeType", "EaseOutQuint"));


                //reset the tile tage to "Tile" so it's not "Selected" anymore.
                tile.tag = "Tile";
                //tile.GetComponent<Tile>().tileBGImage.color = Color.white;

            }


        }


        //reset the word being made to be the startLetter

        if (startLetter!=null&&chainFlag==true)
        { 
            WordBeingMade = startLetter; 
        } else
        { 
            WordBeingMade = ""; 
        }

 


        //reset the tile start positions when spelling a word
        TileManager.Instance.ResetWordStartPoint();

    }
   

    //spawns the points text so that they display when a word is made
    private void PointsSpawner()
    {

       //Messages scoreMessage = new Messages();

       pointsHolder = Instantiate(pointsText, new Vector3(Screen.width/2, Screen.height/2), Quaternion.identity);

              
    }


    public void ShowMessage()
    {


        //if it's inactive, set it to active
        if (messageParentObject.active != true)
        {
            messageParentObject.SetActive(true);
        }

        //set the message text to be a random one from the EncouragementMessage list
        message = encouragementMessages.OnScreenMessages[Random.Range(0, encouragementMessages.OnScreenMessages.Length)];

        messageObject.text = message;
        //messageObject.color = Color.red;

        //iTween.PunchScale(messageParentObject, iTween.Hash("amount", 1.1f,"time", 1, "oncomplete", "DeactivateMessage")); ;

        //tween the parent object so that it moves up when spawned.
        //iTween.FadeTo(messageParentObject, iTween.Hash("alpha", 1, "amount",1, "easeType", "easeInOutExpo", "oncomplete", "DeactivateMessage"));;
        StartCoroutine(removeMessages());
    }

    public IEnumerator removeMessages()
    {
        yield return new WaitForSeconds(2f);
        messageParentObject.SetActive(false);
    }
    

    public void ReduceAge()
    {


        //fill the array with all of the tiles that need to be aged i.e. the letters in the rack not included in the word.
        agingArray = GameObject.FindGameObjectsWithTag("Tile");

        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[6]);

        }
        //check which tiles aren't in the selected tiles array and age them accordingly
        foreach (GameObject tile in agingArray)
        {

            //check if the level is complete first before doing all of this.
            if ((tile.GetComponent<Tile>().spawnedTile.age > 0) && (levelManager.levelComplete != true) && (tile.GetComponent<Tile>().canAge==true))
            {
                var tileScale = tile.transform.localScale;

                //reduce tile age
                tile.GetComponent<Tile>().spawnedTile.age -= 1;

                var randomTime = Random.Range(0.5f, 1f);

                switch (tile.GetComponent<Tile>().spawnedTile.age)
                {

                    //if the tile's age is 3, 2 or 1 then shake it accordingly
                    case 3:
                        iTween.ShakePosition(tile, iTween.Hash("x", 2, "y", 2, "time", randomTime, "easetype", "easeOutQuint"));
                        //tile.GetComponentInParent<Transform>().transform.localScale = new Vector3(0.2f, 0, 0);
                        // iTween.ShakeScale(gameObject, , 0.5f);
                        break;
                    case 2:
                        iTween.ShakePosition(tile, iTween.Hash("x", 4, "y", 4, "time", randomTime, "easetype", "easeOutQuint"));

                        break;
                    case 1:
                        iTween.ShakePosition(tile, iTween.Hash("x", 8, "y", 8, "time", randomTime, "easetype", "easeOutQuint"));
                        break;

                }
                

                 



            }  if ((tile.GetComponent<Tile>().spawnedTile.age == 0) && (levelManager.levelComplete != true))
            {
                //if the tile age == 0 then run the DropTile function on the tile

                tile.GetComponent<Tile>().DropTile();
                if (AudioManager.Instance)
                {
                    AudioManager.Instance.PlayAudioWithSource(AudioManager.Instance.sfxTileCracks[Random.Range(0, 4)], gameObject.GetComponent<AudioSource>(), Random.Range(0.4f, 1f));

                }
                //Debug.Log("tile dropped");
               
            }

        }
    }


    //this function checks the animation status and sets it to be whatever is incoming in the "correctWord" bool
    /*
    private void CheckAnimationStatus (bool correctWord)
    {
        foreach (var tile in selectedTilesArray)
        {
            tile.GetComponent<Tile>().animator.SetBool("correctWord", correctWord);
        }           
        
    }
    */


    public void MoveWordToPoint()
    {
        if (wordBeingMade.Length == 5)
        {
            iTween.MoveTo(PrimaryTile, iTween.Hash("x", -150, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
        }

        if (wordBeingMade.Length == 6)
        {
            iTween.MoveTo(PrimaryTile, iTween.Hash("x", -200, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
        }

        if (wordBeingMade.Length == 8)
        {
            iTween.MoveTo(PrimaryTile, iTween.Hash("x", -450, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
        }

        if (wordBeingMade.Length == 10)
        {
            iTween.MoveTo(PrimaryTile, iTween.Hash("x", -600, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));
        }


    }

}
