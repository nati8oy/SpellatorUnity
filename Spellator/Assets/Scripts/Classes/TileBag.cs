using System.Collections.Generic;
using UnityEngine;

public class TileBag
{
    private string lettersToSplit;
    public int probabilityAmount;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();

    public static string allLettersFromBag;

    //public static List<string> bag = new List<string>();

    public static List<string> bag = new List<string>() { "A", "A", "A", "A", "A", "A", "A", "A", "A", "S", "S", "S", " S", "T", "T", "T", "T", "T", "T", "B", "B",  "D", "D", "D", "D", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "I", "I", "I", "I", "I", "I", "I", "I", "I", "O", "O", "O", "O", "O", "O", "O", "O", "R", "R", "R", "R", "R", "R", "N", "N", "N", "N", "N", "N", "G", "G", "G", "L", "L", "L", "L", "F", "F", "C", "C", "Y", "Y", "H", "H",  "P", "P","U", "U", "U", "U", "V", "V", "W", "W", "X", "Z", "Q","J", "K" };
    //public static List<string> bag = new List<string>() {"E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "I", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "N", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "R", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "L", "L", "L", "L", "L", "L", "L", "U", "U", "U", "U", "U", "U", "U", "D", "D", "D", "D", "D", "D", "D", "D", "G", "G", "G", "G", "G", "C", "C", "C", "C", "C", "C", "M", "M", "M", "M", "M", "M", "B", "B", "B", "B", "P", "P", "P", "P", "H", "H", "H", "H", "H", "F", "F", "F", "F", "W", "W", "W", "W", "Y", "Y", "Y", "Y", "V", "V", "V", "K", "K", "J", "J", "X", "X", "Q", "Q", "Q", "Z", "Z"};

   // public static List<string> bag = new List<string>();
  //  public static List<string> bag = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

   //public static List<string> consonantList = new List<string>() { "B","C","D","F","G","H","K","L","M", "N","P","R","S","T","W","Y"};
    //public static List<string> vowelList = new List<string>() { "A","E","I","O","U"};
    //public static List<string> rareConsonantList = new List<string>() { "J", "K", "Q", "X", "V", "Z"};

    public static Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();


    /*

    public void SetupExternalBag(string incomingTextString) 
    {
        allLettersFromBag = incomingTextString;

        //Debug.Log(allLettersFromBag.Length);
        bag = new List<string>(allLettersFromBag.Split(','));

        for(int i = 0; i<bag.Count; i++)
        {
            bag.Add(allLettersFromBag[i].ToString());
        }

    }*/

        /*
    public void RemoveLetterUsed(string letterToRemove)
    {
    
        for (int i = 0; i< bag.Count; i++)
        {
            if(bag[i] == letterToRemove)
            {
               bag.Remove(bag[i]);
                Debug.Log(bag.Count);
            }
        }

    }*/
}
