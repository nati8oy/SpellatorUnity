using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile Bag", menuName = "Bag")]

public class TileBagSO : ScriptableObject
{
    public Dictionary<string, int> letterDictionary = new Dictionary<string, int>();
    public List<string> bag = new List<string>();


public void RemoveLetterUsed(string letterToRemove)
    {


        if (letterDictionary.ContainsKey(letterToRemove))
        {
            letterDictionary.Remove(letterToRemove);
            //Debug.Log(letterDictionary.Count + " tile was removed from bag");

            if (letterDictionary.Count < 10)
            {
                Debug.Log("Bag only has 10 tiles left");
            }
        }



    }


}
