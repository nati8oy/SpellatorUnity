using System.Collections.Generic;
using UnityEngine;

public class InitDictionary : MonoBehaviour
{

    public static InitDictionary Instance;

    private string lettersToSplit;
   // [SerializeField] private TextAsset externalTextFile;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();



    public List<string> bag = new List<string>() { "A", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "C", "C", "D", "D", "D", "D", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "F", "F", "G", "G", "G", "H", "H", "I", "I", "I", "I", "I", "I", "I", "I", "I", "J", "K", "L", "L", "L", "L", "N", "N", "N", "N", "N", "N", "O", "O", "O", "O", "O", "O", "O", "O", "P", "P", "Q", "R", "R", "R", "R", "R", "R", "S", "S", "S", " S", "T", "T", "T", "T", "T", "T", "U", "U", "U", "U", "V", "V", "W", "W", "X", "Y", "Y", "Z" };
    //public List<string> bag = new List<string>();

    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();

    void Start()
    {

        pointsDictionary.Add("A", 1);
        pointsDictionary.Add("B", 3);
        pointsDictionary.Add("C", 3);
        pointsDictionary.Add("D", 2);
        pointsDictionary.Add("E", 1);
        pointsDictionary.Add("F", 4);
        pointsDictionary.Add("G", 2);
        pointsDictionary.Add("H", 4);
        pointsDictionary.Add("I", 1);
        pointsDictionary.Add("J", 8);
        pointsDictionary.Add("K", 5);
        pointsDictionary.Add("L", 1);
        pointsDictionary.Add("M", 3);
        pointsDictionary.Add("N", 1);
        pointsDictionary.Add("O", 1);
        pointsDictionary.Add("P", 3);
        pointsDictionary.Add("Q", 10);
        pointsDictionary.Add("R", 1);
        pointsDictionary.Add("S", 1);
        pointsDictionary.Add("T", 1);
        pointsDictionary.Add("U", 1);
        pointsDictionary.Add("V", 4);
        pointsDictionary.Add("W", 4);
        pointsDictionary.Add("X", 8);
        pointsDictionary.Add("Y", 4);
        pointsDictionary.Add("Z", 10);

        /*
        //add the list of words from an external txt file via the inspector
        lettersToSplit = externalTextFile.text;

        //get the dictionary list of words and split them on every comma
        bag = new List<string>(lettersToSplit.Split(','));

        //add each of the words within dictionaryList to the actual dictionary itself
        for (int i = 0; i < bag.Count; i++)
        {
            dictionary.Add(bag[i], 1);
        }

        */
        /*
        //sets the letter and point text of each tile
        letter.text = InitDictionary.Instance.bag[Random.Range(0, 95)];
        points.text = InitDictionary.Instance.pointsDictionary[letter.text].ToString();

        tilePointValue = InitDictionary.Instance.pointsDictionary[letter.text];
        */


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


    void Update()
    {
        
    }
}
