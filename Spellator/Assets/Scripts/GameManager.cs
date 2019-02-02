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

    //this is the textbox that displays the current word being made
    [SerializeField]
    private Text inputText;

    //a list to store all of the values from the text file in
    private List<string> dictionaryList = new List<string>();
   
     private GameObject[] selectedTiles;
    private GameObject[] tilesToUntag;


    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();

    private string wordBeingMade;

    public string WordBeingMade
    {
        get { return wordBeingMade; }
        set
        {
            Debug.LogFormat("WordBeingMade will change to '{0}'", value);
            wordBeingMade = value;
            inputText.text = wordBeingMade;
        }
    }

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

    public void CheckAndDeleteTiles()
    {

        if (dictionary.ContainsKey(WordBeingMade))
        {
            //loop through the array and delete each of the gameObjects in it
            selectedTiles = GameObject.FindGameObjectsWithTag("Selected");
            foreach (GameObject tile in selectedTiles)
            {

                Destroy(tile.gameObject);
            }

            Debug.Log("------Deleting Tiles------");
            WordBeingMade = "";
        }
       
    }

    public void CheckWord()
    {
        //check to see if the word is in the dictionary. If it is then clear the word being made and add points, etc. 
        if (dictionary.ContainsKey(WordBeingMade))
        {
            Debug.Log(WordBeingMade + " is a word");
        }
        else
        {
            Debug.Log(WordBeingMade + " isn't a word");
        }
    }

    //this handles the incoming letter from the tile which is concatenated to the current "wordBeingMade"
    public void CreateWord(string theLetter)
    {
        WordBeingMade = string.Concat(WordBeingMade, theLetter);
    }



    public void ClearWord()
    {


        //add all the tiles with the tag "Selected" to an array
        tilesToUntag = GameObject.FindGameObjectsWithTag("Selected");


        //loop through the array and delete each of the gameObjects in it
        foreach (GameObject tile in tilesToUntag)
        {
            tile.tag = "Untagged";
        }

        WordBeingMade = "";

    }

}








