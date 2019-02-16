using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;

    //this sets up the field for which to add the external dictionary txt file
    [SerializeField]
    private TextAsset dictionaryTxtFile;


    //for the coroutine
    private float smoothing = 10f;
    private Transform target;

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
            //Debug.LogFormat("WordBeingMade will change to '{0}'", value);
            //scoreText = value;
            liveScoreText = value;
        }
    }


    private int totalScore;

    [SerializeField] private Text scoreText;


    //this is the textbox that displays the current word being made
    [SerializeField] private Text messageText;

    //a list to store all of the values from the dictionary text file in
    private List<string> dictionaryList = new List<string>();


    //a list to store all of the values from the bag text file in

    private List<string> bagList = new List<string>();

    public GameObject[] selectedTilesArray;
    public GameObject[] allTilesArray;

    //bool to check if all tiles can be replaced
    private bool resetBool;


    //reference to the delete button 
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button sendButton;

    /*
    public Button DeleteButton
    {
        get { return DeleteButton; }
        //set { DeleteButton = value; }
    }

    */

    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();

    private GameObject tileHolder;


    private string wordBeingMade;

    public string WordBeingMade
    {
        get { return wordBeingMade; }
        set
        {
            //Debug.LogFormat("WordBeingMade will change to '{0}'", value);
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

    void Start()
    {

        liveScoreText.text = "";
        scoreText.text = "";
        sendButton.interactable = false;

        //add the list of words from an external txt file via the inspector
        fullDictionary = dictionaryTxtFile.text;

        //get the dictionary list of words and split them on every comma
        dictionaryList = new List<string>(fullDictionary.Split(','));

        //add each of the words within dictionaryList to the actual dictionary itself
        for (int i = 0; i < dictionaryList.Count; i++)
        {
            // Debug.Log(dictionaryList[i]);
            dictionary.Add(dictionaryList[i], 1);
        }


    }

    private void Update()
    {
    }



    public void CheckAndDeleteTiles()
    {

        if (dictionary.ContainsKey(WordBeingMade))
        {
            //loop through the array and delete each of the gameObjects in it
            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

            foreach (GameObject tile in selectedTilesArray)
            {
                //destroy the tiles
                Destroy(tile.gameObject);

                //Debug.Log(tile.transform.parent.name);

            }

            TileManager.Instance.ReplenishTiles();

            WordBeingMade = "";

            sendButton.interactable = false;
            // Debug.Log("the next play slot is: " + TileManager.Instance.NextFreeSlot);

            //add the scores to the screen after adding the ints together
            totalScore = totalScore + liveScore;
            scoreText.text = totalScore.ToString();

            //reset the scores
            ResetScores();
        }

      

    }

    public void CheckWord()
    {


        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            Debug.Log(WordBeingMade + " is a word");
            //inputText.text = "Word! :)";
            sendButton.interactable = true;

        }
        else
        {
            //inputText.text = "Not a word :(";
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

        TileManager.Instance.SelectedTiles.Clear();
        //check if the reset bool is true. If it is, delete all the tiles in the rack
        if (wordBeingMade == "")
        {
            resetBool = true;
        }
        else resetBool = false;

       // Debug.Log("Reset Bool is: " + resetBool);

        if (resetBool == true)
        {


            //loop through the array and delete each of the gameObjects in it
            allTilesArray = GameObject.FindGameObjectsWithTag("Tile");

            foreach (GameObject tile in allTilesArray)
            {
                //destroy the tiles
                Destroy(tile.gameObject);

            }

            //set the tiles ups again from the TileSpawner code

            TileSpawner.Instance.TileSetup();
          


        }

        else if (resetBool == false)
        {
            //selectedTilesArray = null;

            //add all the tiles with the tag "Selected" to an array

            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

            //for each of the tile objects in the selected tiles array,
            //go through and get the parent transform (which is the position game object)
            //then reset the position to that 

            foreach (GameObject tile in selectedTilesArray)

            {
                tile.transform.position = tile.transform.parent.position;
                tile.tag = "Tile";

            }

            //StartCoroutine(TileManager.Instance.ReturnTiles());

        }

        //reset the word being made
        WordBeingMade = "";

        //reset the score and live score
       ResetScores();

        //reset the positions of the slots
        TileManager.Instance.ResetSlots();

        //set the next free slot on the playing board
        //nextFreeSlot = 0;

    }


    private void ResetScores()
    {
        //reset the score and live score
        LiveScoreText.text = "";
        liveScore = 0;
    }



}
