using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

public class DictionaryManager : MonoBehaviour
{

    [Header("Save Data Items")]
    // public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
    public List<string> playerWordsMade = new List<string>();

    public static DictionaryManager Instance;
    [Header("Scriptable Objects")]
    public ConfigSO wordData;
    public LevelManagerSO levelManager;


    [Space()]
    [Header("Word Related Variables")]
    //    private WordData listOfWordsMade;


    [Space()]
    [Header("Managers")]

    //uses a scritable object to hold the array for on screen messages
    [SerializeField] private MessagingSO encouragementMessages;

    //a list to store all of the values from the dictionary text file in
    private List<string> dictionaryList = new List<string>();

    private Text tileText;


    public int starsTotal;
    public TextMeshProUGUI starTotalText;

    //this sets up the field for which to add the external dictionary txt file
    [SerializeField]
    private TextAsset dictionaryTxtFile;

    //a list to store all of the values from the bag text file in

    private List<string> bagList = new List<string>();


    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();


    private Transitions fadeManager;

    [Space()]
    [Header("Particle Systems")]
    private ParticleSystem starParticles;
    [SerializeField] private ParticleSystem correctWordParticles;
    private ParticleSystem heartParticles;
    [SerializeField] private ParticleSystem healthUpParticles;


    [Space()]
    [Header("Sprites")]
    [SerializeField] private GameObject correctIcon;

    [Space()]
    [Header("Audio")]

    //store all of the audio clips in this array
    public AudioClip[] allAudioClips;

    [Space()]
    [Header("UI Elements")]

    private GameObject healthBar;

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

    [SerializeField] private GameObject PrimaryTile;
    private float primaryPosX;
    private float primaryPosY;

    private GameObject startTile;

    private GameObject pointsHolder;
    private GameObject[] agingArray;


    [SerializeField] private Text scoreText;


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
    }


    private IEnumerator TileCompleteSequence() {

        //create a local var from the tile TAGGED with "PrimaryTile"
        var currentPrimary = GameObject.FindGameObjectWithTag("PrimaryTile");

        //if the current primary tile exists then remove it.
        if (currentPrimary)
        {
            iTween.MoveBy(currentPrimary, iTween.Hash("y", 125, "easetype", "EaseInQuad", "time", 0.3f, "oncomplete", "RemoveTileOnComplete"));

        }

       
        //move the last tile of the word to the primary tile spot
        iTween.MoveTo(selectedTilesArray[selectedTilesArray.Length - 1], iTween.Hash("x", primaryPosX, "easetype", "EaseInOutCirc", "delay", 0.1*wordBeingMade.Length, "time", 0.4f, "onComplete", "SetPrimaryTile"));
        
        selectedTilesArray[selectedTilesArray.Length - 1].tag = "Tile";

        //for each of the tiles set a delay and remove them from the screen

        
            for (int i = 0; i < selectedTilesArray.Length - 1; i++)
            {
                var randomY = Random.Range(100, 135);

                //for each tile in the selectedTilesArray set the animator bool to be "true"
                //selectedTilesArray[i].GetComponent<Tile>().animator.SetBool("clearTile", true);


                iTween.MoveBy(selectedTilesArray[i], iTween.Hash("y", randomY, "easetype", "spring", "time", 0.5f, "delay", (0.1f) * (i + 1), "oncomplete", "RemoveTileOnComplete"));


                
                //  iTween.RotateBy(selectedTilesArray[i], new Vector3(10, 10), 1);

        }

        

        yield return null;

    }



    // Start is called before the first frame update
    void Start()
    {

        //levelManager.levelComplete = false;

        //level class constructor
 //       levelData = new LevelClass();

        //set the list of playerWordsMade to be that of the Scriptable object's uniqueWordList
        playerWordsMade = wordData.uniqueWordsList;

        //set the scriptable object find the longest word in the list of unique words
        wordData.FindLongestWord();
      //  musicOn = wordData.musicOn;
       // sfxOn = wordData.sfxOn;

        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();

        correctWordParticles.Stop();
        healthUpParticles.Stop();
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
        starTotalText.text = starsTotal.ToString();



    }


    public void CheckAndDeleteTiles()
    {
      
        Debug.Log("Premium currency total: " + starsTotal);


        //access the level data function
        //RANDOM VERSION
        LevelManager.Instance.LevelGoalCheck(WordBeingMade, LevelManager.Instance.randomLevelSelection);

        //SET VERSION
       // levelData.LevelGoalCheck(WordBeingMade, "starting");


        //play the particle effects for a correct word
        correctWordParticles.Play();

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
            //play "ding" sound
            // AudioManager.Instance.PlayAudio(allAudioClips[3]);

            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[3]);

            //add the word to the overall list of words being made

            //check if the multiplier is going to be broken with a 3 letter word. If so, play the sound.
            if ((multiplier >= 3) && (WordBeingMade.Length <= 3))
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);
            }

            //add to the multiplier
            if (WordBeingMade.Length >= 4)
            {
                Points.multiplier += 1;
            }


			//if the word doesn't exist in the current list, add it to the playerWordsMade list

			if (!playerWordsMade.Contains(WordBeingMade))
			{
				playerWordsMade.Add(WordBeingMade);

                //add the word to the scriptable object as well so that it can be referenced elsewhere e.g. the main menu scene
                //wordData.uniqueWordsList.Add(WordBeingMade);

                Debug.Log("Word added to list! " + "(" + playerWordsMade.Count + " words)");

                //add the new word to the unique words per level 
                GameManager.Instance.AddNewWord();



			}
            /*

			if (!playerWordsMade.ContainsKey(WordBeingMade))
            {
                playerWordsMade.Add(WordBeingMade,1);
                Debug.Log("Word added! ");

            }*/



                else if (WordBeingMade.Length <= 3)
            {
                Points.multiplier = 1;
                multiplierText.text = "";
            }


            //add on screen encouragement for words above 5 letters
            if ((WordBeingMade.Length >= 5) || (Points.liveScore>=50))
            {
                ShowMessage("encouragement");
                //this chooses the kind of cross fade or screen flash to use
                fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

            }



            //loop through the array and delete each of the gameObjects in it
            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");


            foreach (GameObject tile in selectedTilesArray)
            {

                //access the script on each of the tile creators/spawners and refill the tiles
               tile.transform.parent.GetComponent<TileCreator>().RefillTiles();

                //checks the tile type and adds whatever the special tile bonus is
                
                if (tile.GetComponent<Tile>().spawnedTile.specialAttribute == "heart")
                {
                    //update the player health based on the tile points amount
                    healthBar.GetComponent<PlayerHealth>().Heal(tile.GetComponent<Tile>().spawnedTile.points);
                    healthUpParticles.Play();
                   
                }
                

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

//            Debug.Log("Live score is: " + Points.liveScore);
            Points.AddPoints(Points.liveScore);

            scoreText.text = Points.totalScore.ToString();


            //Clear the WordBeingMade first before setting it to be the startLetter of the next word
            WordBeingMade = "";
            WordBeingMade = startLetter;


            //sets the start letter of the next word
            //SetStartTile();

            sendButton.interactable = false;

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


        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            sendButton.interactable = true;
            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[2]);

            //show the icon that indicates that a word is correct
            correctIcon.SetActive(true);

           ///Debug.Log("colour set to red");
           /*
            foreach (GameObject selectedTile in selectedTilesArray)
            {
                selectedTile.GetComponent<Tile>().tileBGImage.color = Color.red;
                Debug.Log("colour set to red");
            }*/
        }
        else
        {
            sendButton.interactable = false;


            //hide the icon that indicates that a word is correct
            correctIcon.SetActive(false);

        }


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



    }

    //this handles the incoming letter from the tile which is concatenated to the current "wordBeingMade"
    public void CreateWord(string theLetter)
    {
        WordBeingMade = string.Concat(WordBeingMade, theLetter);
    }



    public void ClearWord()
    {
        //move the primary tile back to its starting position
        iTween.MoveTo(PrimaryTile, iTween.Hash("x", primaryPosX, "easetype", "EaseInOutCirc", "delay", 0.1, "time", 0.4f));

        //reset the scores
        Points.resetScores();
        sendButton.interactable = false;

        //hide the icon that indicates that a word is correct
        correctIcon.SetActive(false);


        TileManager.Instance.SelectedTiles.Clear();
        //check if the reset bool is true. If it is, delete all the tiles in the rack

        if (wordBeingMade == startLetter)
        {
            resetBool = true;
        }
        else resetBool = false;


        if (resetBool == true)
        {


            //reduce the age of the tiles that are on the rack currently instead of deleting them all
            ReduceAge();

            

            //remove multiplier
            if (Points.multiplier >= 3)
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);
            }

            Points.multiplier = 1;
            multiplierText.text = "";





        }

        else if (resetBool == false)
        {

            //add all the tiles with the tag "Selected" to an array

            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

            //for each of the tile objects in the selected tiles array,
            //go through and get the parent transform (which is the position game object)
            //then reset the position to that 

            foreach (GameObject tile in selectedTilesArray)

            {
                //set the animator of each tile to revert to the idle animation when the word is cleared
                //tile.GetComponent<Tile>().animator.SetBool("clearTile", false);

                //set getStartPos so that it can be used in the coroutine below

                
                if (tile.GetComponent<Tile>().animator.GetBool("correctWord"))
                {
                    tile.GetComponent<Tile>().animator.SetBool("correctWord", false);
                }
                


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

        if (startLetter!=null)
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


    public void ShowMessage(string messageType)
    {


        //if it's inactive, set it to active
        if (messageParentObject.active != true)
        {
            messageParentObject.SetActive(true);
        }

        //show different messages for different types

        switch (messageType)
        {
            case "encouragement":
                //set the message text to be a random one from the EncouragementMessage list
                message = encouragementMessages.OnScreenMessages[Random.Range(0, encouragementMessages.OnScreenMessages.Length)];

                messageObject.text = message;
                //messageObject.color = Color.red;


                //tween the parent object so that it moves up when spawned.
                iTween.FadeTo(messageParentObject, iTween.Hash("alpha", 1, "amount",1, "easeType", "easeInOutExpo", "oncomplete", "DeactivateMessage"));;

                break;

            case "time":
                //set the message text to be a random one from the EncouragementMessage list
                message = "Time++";

                messageObject.text = message;
                //messageObject.color = Color.red;

                //tween the parent object so that it moves up when spawned.
                iTween.MoveBy(messageParentObject, iTween.Hash("y", 60, "easeType", "easeInOutExpo", "oncomplete", "DeactivateMessage"));
                break;


        }


    }
    

    public void ReduceAge()
    {

        //fill the array with all of the tiles that need to be aged i.e. the letters in the rack not included in the word.
        agingArray = GameObject.FindGameObjectsWithTag("Tile");

        AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[6]);
        //check which tiles aren't in the selected tiles array and age them accordingly
        foreach (GameObject tile in agingArray)
        {
           

            if (tile.GetComponent<Tile>().spawnedTile.age > 0)
            {
                //reduce tile age
                tile.GetComponent<Tile>().spawnedTile.age -= 1;

                var randomTime = Random.Range(0.5f, 1f);

                switch (tile.GetComponent<Tile>().spawnedTile.age){

                    //if the tile's age is 3, 2 or 1 then shake it accordingly
                    case 3:
                        iTween.ShakePosition(tile, iTween.Hash("x", 2, "y", 2, "time", randomTime, "easetype", "easeOutQuint"));
                        break;
                    case 2:
                        iTween.ShakePosition(tile, iTween.Hash("x", 4, "y", 4, "time", randomTime, "easetype", "easeOutQuint"));
                        break;
                    case 1:
                        iTween.ShakePosition(tile, iTween.Hash("x", 8, "y", 8, "time", randomTime, "easetype", "easeOutQuint"));
                        break;

                }
                 



            }  if (tile.GetComponent<Tile>().spawnedTile.age == 0)
            {
                //if the tile age == 0 then run the DropTile function on the tile

                tile.GetComponent<Tile>().DropTile();
               


            }

        }
    }

}
