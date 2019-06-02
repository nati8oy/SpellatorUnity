using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DictionaryManager : MonoBehaviour
{


    public static DictionaryManager Instance;

    [SerializeField] private GameObject BoardHolder;

    [SerializeField] private AudioClip correctWord;
    [SerializeField] private AudioClip clearWordSound;
    [SerializeField] private AudioClip loseMultiplier;

    //this section is for the on screen messages
    [SerializeField] private GameObject messageParentObject;
    [SerializeField] private TextMeshProUGUI messageObject;

    private List<string> EncouragementMessages;
    private string message;

    [SerializeField] public TextMeshProUGUI multiplierText;

    private PointsClass scores = new PointsClass();

    //add class for the on screen messages to reference later.
    //private Messages onScreenMessage = new Messages();


    private TileClass NewPrimaryTile;
    [SerializeField] private GameObject primaryTile;

    public GameObject PrimaryTile
    {
        get {return primaryTile; }
    }

    private SpecialMeterClass specialMeter = new SpecialMeterClass();

    private GameObject startTile;

    private GameObject pointsHolder;
    [SerializeField] private GameObject pointsText;

    //[SerializeField] private GameObject message;

    private bool initialBoardMove;

    public bool firstLetterOfWord;

    public bool chainFlag;

    private string mostRecentWord;
    private string startLetter;

    public string StartLetter
    {
        get { return startLetter; }
    }

    [SerializeField] private Text scoreText;

    private float smoothing;
    private Vector3 target;


    private int multiplier;
    public int Multiplier
    {
        get { return multiplier; }
    }

    //a list to store all of the values from the dictionary text file in
    private List<string> dictionaryList = new List<string>();



    private Text tileText;

    //this sets up the field for which to add the external dictionary txt file
    [SerializeField]
    private TextAsset dictionaryTxtFile;

    //a list to store all of the values from the bag text file in

    private List<string> bagList = new List<string>();

    public GameObject[] selectedTilesArray;

    public GameObject[] allTilesArray;

    //bool to check if all tiles can be replaced
    private bool resetBool;


    //reference to the delete button 
    [SerializeField] public Button deleteButton;
    [SerializeField] public Button sendButton;


    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();

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


    // Start is called before the first frame update
    void Start()
    {

        EncouragementMessages = new List<string>();
        EncouragementMessages.Add("Marvellous!");
        EncouragementMessages.Add("Amazing!");
        EncouragementMessages.Add("Wow!");
        EncouragementMessages.Add("Nice word!");
        EncouragementMessages.Add("Smashing it!");
        EncouragementMessages.Add("Holy Heck!");
        EncouragementMessages.Add("For real?!");
        EncouragementMessages.Add("Love!");




        //create a new primary tile class so that it's avaiable for later on.
        NewPrimaryTile = new TileClass(primaryTile.transform.position);


        //run the function in the Messages class that makes the message object active
        ShowMessage();




        // Instantiate(BoardHolder, new Vector3(200, 200), Quaternion.identity);


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


        if (PointsClass.multiplier >= 3)
        {
            //set the multiplier text 
            multiplierText.text = "x" + PointsClass.multiplier.ToString();
            PointsClass.multiplierActive = true;

        }


    }


    public void CheckAndDeleteTiles()
    {
    
        if (dictionary.ContainsKey(WordBeingMade))
        {

            //check if the multiplier is going to be broken with a 3 letter word. If so, play the sound.
            if ((multiplier >= 3) && (WordBeingMade.Length <= 3))
            {
                AudioManager.Instance.PlayAudio(loseMultiplier);
            }

            //add to the multiplier
            if (WordBeingMade.Length >= 4)
            {
               PointsClass.multiplier += 1;
            }

            else if (WordBeingMade.Length <= 3)
            {
                PointsClass.multiplier = 0;
                multiplierText.text = "";
            }


            //add on screen encouragement for words above 5 letters
            if (WordBeingMade.Length >= 3)
            {
                ShowMessage();
            }



            //loop through the array and delete each of the gameObjects in it
            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

            foreach (GameObject tile in selectedTilesArray)
            {


                //access the script on each of the tile creators/spawners
                //var tileStatusUpdate = tile.transform.parent.GetComponent<TileCreator>();
               var getStartPos = tile.transform.parent.GetComponent<TileCreator>();
               getStartPos.RefillTiles();


                tile.tag = "Tile";
                //

                var randomYPos = Random.Range(75, 125);
                var randomTimeFrame = Random.Range(0.2f,0.5f);

               iTween.MoveBy(tile, iTween.Hash("y", randomYPos, "easetype", "EaseOutQuad", "time", randomTimeFrame, "oncomplete", "RemoveTileOnComplete"));
              

            }


            //add the to total words made
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

            //reset the scores
            scoreText.text = PointsClass.totalScore.ToString();

            scores.addPoints(PointsClass.liveScore);

            specialMeter.IncreaseMeter(PointsClass.liveScore);
            //Debug.Log("The most recent score was :" + PointsClass.mostRecentScore);

            scores.resetScores();

            //Clear the WordBeingMade first before setting it to be the startLetter of the next word
            WordBeingMade = "";
            WordBeingMade = startLetter;


            //sets the start letter of the next word
            SetStartTile();

            sendButton.interactable = false;

            //add the scores to the screen after adding the ints together
            //GameManager.Instance.CalculateScores();




            //GameManager.Instance.LiveScoreText = "";

            //clear the selectedTiles list so that it puts the new tiles in the right positions
            TileManager.Instance.ResetWordStartPoint();

            
            //set the chain flag to true so that chain mode can continue
            chainFlag = true;

            scores.resetScores();

        }

    }

    public void CheckWord()
    {


        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            sendButton.interactable = true;
            AudioManager.Instance.PlayAudio(correctWord);


        }
        else
        {
            sendButton.interactable = false;
        }


    }

    //this handles the incoming letter from the tile which is concatenated to the current "wordBeingMade"
    public void CreateWord(string theLetter)
    {
        WordBeingMade = string.Concat(WordBeingMade, theLetter);
    }



    public void ClearWord()
    {
        scores.resetScores();
        sendButton.interactable = false;
        AudioManager.Instance.PlayAudio(clearWordSound);


        TileManager.Instance.SelectedTiles.Clear();
        //check if the reset bool is true. If it is, delete all the tiles in the rack

        if (wordBeingMade == startLetter)
        {
            resetBool = true;
        }
        else resetBool = false;


        if (resetBool == true)
        {


            //loop through the array and delete each of the gameObjects in it
            allTilesArray = GameObject.FindGameObjectsWithTag("Tile");

            foreach (GameObject tile in allTilesArray)
            {


                //access the tile's scripts and make them "Available"

                var setTileStatus = tile.transform.parent.GetComponent<TileCreator>();
                setTileStatus.RefillTiles();

                //destroy the tiles
                tile.SetActive(false);



            }


            //remove multiplier
            if (PointsClass.multiplier >= 3)
            {
                AudioManager.Instance.PlayAudio(loseMultiplier);
            }
            PointsClass.multiplier = 1;
            PointsClass.multiplierActive = false;
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


                //connect to the tile script component
                //var connectToTileScript = tile.GetComponent<Tile>();
                //reset the parent to the original
                //connectToTileScript.SetToOriginalParent();

                //set getStartPos so that it can be used in the coroutine below


                var getStartPos = tile.transform.parent.GetComponent<TileCreator>();
                //connect to the script of each tile, get the startPos from there (which is the starting transform of each Pos holder)
                //then run the Coroutine from the tile game object. Phew!
                iTween.MoveTo(tile, new Vector3(getStartPos.startPos.position.x, getStartPos.startPos.position.y, 0), 0.5f);
                //iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time",0.5f, "easeType", "EaseOutQuint"));

                //connectToTileScript.StartCoroutine(connectToTileScript.ReturnTile(getStartPos.startPos));

                //reset the tile tage to "Tile" so it's not "Selected" anymore.
                tile.tag = "Tile";

            }


        }

        //reset the word being made
        //WordBeingMade = "";

        //reset the word being made to be the startLetter

        if (startLetter!=null)
        { 
            WordBeingMade = startLetter; 
        } else
        { 
            WordBeingMade = ""; 
        }

       



        //reset the score and live score
        //GameManager.Instance.ResetScores();


        //reset the tile start positions when spelling a word
        TileManager.Instance.ResetWordStartPoint();

    }
   

    //spawns the points text so that they display when a word is made
    private void PointsSpawner()
    {

       //Messages scoreMessage = new Messages();

       pointsHolder = Instantiate(pointsText, new Vector3(Screen.width/2, Screen.height/2), Quaternion.identity);

       
       
        // pointsHolder.transform.parent = GameObject.Find("Word Being Spelled").transform;
    }

    public void SetStartTile()
    {

       // NewPrimaryTile.letter = startLetter;
       // NewPrimaryTile.points = TileBag.pointsDictionary[NewPrimaryTile.letter];

        if (!primaryTile.activeSelf)
        {
            primaryTile.SetActive(true);
        } else if (primaryTile.activeSelf)
        {
            primaryTile.SetActive(false);
            primaryTile.SetActive(true);

        }


    }

    public void ShowMessage()
    {

        //set the message text to be a random one from the EncouragementMessage list
        message = EncouragementMessages[Random.Range(0, EncouragementMessages.Count)];

        //find the TMPro component that is going to hold the string from above
        //messageObject = GameObject.Find("Message Text").GetComponent<TextMeshProUGUI>();

        messageObject.text = message;

        if (messageParentObject.active != true)
        {
            messageParentObject.SetActive(true);
        }

        //tween the parent object so that it moves up when spawned.
        iTween.MoveBy(messageParentObject, iTween.Hash("y", 60, "easeType", "easeInOutExpo", "oncomplete", "DeactivateMessage"));
    }


}
