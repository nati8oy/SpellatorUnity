using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile Bag", menuName = "Bag")]

public class TileBagSO : ScriptableObject
{
    //set up a dictionary of the letters
    public Dictionary<string, int> letterDictionary = new Dictionary<string, int>();

    //set up a bag list. These are added manually via the inspector.
    public List<string> bag = new List<string>();


    //removes the letters that has been used in the word
public void RemoveLetterUsed(string letterToRemove)
    {

        if (letterDictionary.ContainsKey(letterToRemove))
        {
            letterDictionary.Remove(letterToRemove);
            //Debug.Log(letterDictionary.Count + " tile was removed from bag");
            //Debug.Log("Letter removed from bag!" + "bag has" + bag.Count + " tiles remaining" );

            if (letterDictionary.Count < 10)
            {
                Debug.Log("Bag only has 10 tiles left");
            }
        }



    }


}
