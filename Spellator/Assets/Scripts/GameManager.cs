using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    //sets up an instance of the GameManager - a singleton
    public static GameManager instance = new GameManager();
    
    //a list to store all of the values from the text file in
    private List<string> dictionaryList = new List<string>();

    //the object type needed to remove everything once the 
    [SerializeField] private GameObject tile;


    //this sets up the field for which to add the external dictionary file
    [SerializeField] private TextAsset dictionaryTxtFile;

    //this is the string to which the full dictionary is assigned before being split up by the Split method
    private string fullDictionary; 

    //this is the textbox that displays the current word being made
    [SerializeField] private Text inputText;

    //this is the word being made as the letter tiles are clicked
    private string wordBeingMade = "A";

    //this is the array for the selected tiles.
    public GameObject[] selectedTiles;
    //this array is for the tiles to untag once the "clear" button is pressed.
    public GameObject[] tilesToUntag;


    [SerializeField] Transform[] positionArray;


    Dictionary<string, int> dictionary = new Dictionary<string, int>();



    // Start is called before the first frame update
    void Start()
    {
        //wordBeingMade = "FUCK";
        fullDictionary = dictionaryTxtFile.ToString();

        

        //get the dictionary list of words and split them on every space

       dictionaryList = new List<string>(fullDictionary.Split(','));
        //dictionaryArray = fullDictionary.Split(',');
       
        //Debug.Log("Dictionary Array length: " + dictionaryArray.Length);



        //add each of the split words into an array 
        for (int i = 0; i < dictionaryList.Count; i++)
        {

            dictionary.Add(dictionaryList[i], 1);
            //Debug.Log("Dictionary Array content: " + dictionaryArray[i]);


            //Debug.Log(dictionaryArray[i]);
            // Debug.Log(dictionary.Count);

        }

        Debug.Log("Check for specific dictionary key: " + dictionary.ContainsKey("FUCK"));

        // Debug.Log(dictionaryArray.Length);
        Debug.Log("Dictionary size: "+dictionary.Count);
        Debug.Log("Dictionary List length: " + dictionaryList.Count);





    }

     void Update()
    {

        //inputText.text = wordBeingMade;

    }


    public void CheckWord()
    {
        // Debug.Log("wordBeingMade from CheckWord Method: " + wordBeingMade.Length);




        //check to see if the word is in the dictionary. If it is then clear the word being makde and add points, etc. 
        if (dictionary.ContainsKey(wordBeingMade))
        {

            //add all the tiles with the tag "Selected" to an array
            selectedTiles = GameObject.FindGameObjectsWithTag("Selected");


            //loop through the array and delete each of the gameObjects in it
            foreach (GameObject tile in selectedTiles)
            {

                Destroy(tile.gameObject);
            }

            Debug.Log(wordBeingMade +  " is a word");


        }
        else
        {
            Debug.Log(wordBeingMade + " isn't a word");

        }

        if (wordBeingMade == "A")
        {
            Debug.Log("working A");
        }

        if (wordBeingMade == "AA")
        {
            Debug.Log("working AA");
        }


    }




    public void CreateWord(string theLetter, string thePoints)
    {
        wordBeingMade = string.Concat(wordBeingMade, theLetter);
        Debug.Log("word being made is: " + wordBeingMade);

        //inputText.text = wordBeingMade;


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

    }
}

