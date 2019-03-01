using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{


    public static DictionaryManager Instance;

    [SerializeField] private AudioClip correctWord;
    [SerializeField] private AudioClip clearWordSound;
    [SerializeField] private AudioClip loseMultiplier;

    [SerializeField] private Text multiplierText;

    private GameObject pointsHolder;
    [SerializeField] private GameObject pointsText;

    [SerializeField] private GameObject message;


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


    // Start is called before the first frame update
    void Start()
    {

        multiplierText.text = "";

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

    // Update is called once per frame
    void Update()
    {


        if (multiplier >= 3)
        {
            //set the multiplier text 
            multiplierText.text = "x" + multiplier.ToString();

        }


    }


    public void CheckAndDeleteTiles()
    {

        if (dictionary.ContainsKey(WordBeingMade))
        {

            //check if the multiplier is gonig to be broken with a 3 letter word. If so, play the sound.
            if ((multiplier >= 3) && (WordBeingMade.Length <= 3))
            {
                AudioManager.Instance.PlayAudio(loseMultiplier);
            }

            //add to the multiplier
            if (WordBeingMade.Length >= 4)
            {
                multiplier += 1;
            }

            else if (WordBeingMade.Length <= 3)
            {
                multiplier =0;
                multiplierText.text = "";
            }


            //loop through the array and delete each of the gameObjects in it
            selectedTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");




            foreach (GameObject tile in selectedTilesArray)
            {
                // tile.tag = "DiscardedTile";
                //destroy the tiles

                Destroy(tile.gameObject, Random.Range(0.1f, 0.4f));


                //Debug.Log(tile.transform.parent.name);
            }

            TileManager.Instance.ReplenishTiles();

            WordBeingMade = "";

            sendButton.interactable = false;
            // Debug.Log("the next play slot is: " + TileManager.Instance.NextFreeSlot);

            //add the scores to the screen after adding the ints together
            GameManager.Instance.CalculateScores();

            //reset the scores
            GameManager.Instance.ResetScores();

            //clear the selectedTiles list so that it puts the new tiles in the right positions
            TileManager.Instance.ResetWordStartPoint();

        }

        //add to the total words number
        totalWordsMade += 1;


        //spawn the points to add
        PointsSpawner();


    }

    public void CheckWord()
    {


        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            Debug.Log(WordBeingMade + " is a word");
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
        AudioManager.Instance.PlayAudio(clearWordSound);


        TileManager.Instance.SelectedTiles.Clear();
        //check if the reset bool is true. If it is, delete all the tiles in the rack
        if (wordBeingMade == "")
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
                //destroy the tiles
                Destroy(tile.gameObject);

            }

            //set the tiles ups again from the TileSpawner code

            TileSpawner.Instance.TileSetup();

            //remove multiplier
            if (multiplier >=3)
            {
                AudioManager.Instance.PlayAudio(loseMultiplier);
            }
            multiplier = 0;
            multiplierText.text = multiplier.ToString();



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
                //Debug.Log("tile instance ID is: " + tile.GetInstanceID());
                tile.transform.position = tile.transform.parent.position;
                tile.tag = "Tile";
                //StartCoroutine(ReturnTiles(target, tile));

            }


        }

        //reset the word being made
        WordBeingMade = "";

        //reset the score and live score
        GameManager.Instance.ResetScores();

        //reset the tile start positions when spelling a word
        TileManager.Instance.ResetWordStartPoint();

    }
    /*

    IEnumerator ReturnTiles(Vector3 target, GameObject tile)
    {

        target = TileManager.Instance.playPositions[0].transform.position;

        while (Vector3.Distance(tile.transform.position, target) > 0.05f)
        {
            tile.transform.position = Vector3.Lerp(tile.transform.position, target, smoothing * Time.deltaTime);

            yield return null;
        }


    }*/

    private void PointsSpawner()
    {
        pointsHolder = Instantiate(pointsText, new Vector3(766, 1151, 1), Quaternion.identity);
        pointsHolder.transform.parent = GameObject.Find("Word Being Spelled").transform;
    }


}
