using System.Collections.Generic;
using UnityEngine;

public class TileBag
{
    private string lettersToSplit;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();

    public static List<string> bag = new List<string>() { "A", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "C", "C", "D", "D", "D", "D", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "F", "F", "G", "G", "G", "H", "H", "I", "I", "I", "I", "I", "I", "I", "I", "I", "J", "K", "L", "L", "L", "L", "N", "N", "N", "N", "N", "N", "O", "O", "O", "O", "O", "O", "O", "O", "P", "P", "Q", "R", "R", "R", "R", "R", "R", "S", "S", "S", " S", "T", "T", "T", "T", "T", "T", "U", "U", "U", "U", "V", "V", "W", "W", "X", "Y", "Y", "Z" };

    public static Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();


    public void AddLettersToDictonary() { 
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

    }

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

    }
}
