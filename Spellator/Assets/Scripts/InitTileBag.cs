using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTileBag : MonoBehaviour
{

    public TileBagSO tileBagData;
    public Dictionary<string, int> tiles = new Dictionary<string, int>();
    public List<string> bagLetters = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //add the letters to the bag
        bagLetters = tileBagData.bag;

        //add the letters to the dictionary
        tiles = tileBagData.letterDictionary;

        tiles.Add("A", 1);
        tiles.Add("B", 3);
        tiles.Add("C", 3);
        tiles.Add("D", 2);
        tiles.Add("E", 1);
        tiles.Add("F", 4);
        tiles.Add("G", 2);
        tiles.Add("H", 4);
        tiles.Add("I", 1);
        tiles.Add("J", 8);
        tiles.Add("K", 5);
        tiles.Add("L", 1);
        tiles.Add("M", 3);
        tiles.Add("N", 1);
        tiles.Add("O", 1);
        tiles.Add("P", 3);
        tiles.Add("Q", 10);
        tiles.Add("R", 1);
        tiles.Add("S", 1);
        tiles.Add("T", 1);
        tiles.Add("U", 1);
        tiles.Add("V", 4);
        tiles.Add("W", 4);
        tiles.Add("X", 8);
        tiles.Add("Y", 4);
        tiles.Add("Z", 10);
        //Debug.Log(tiles.Count);
        

    }

    // Update is called once per frame
    void Update()
    {
        tiles = tileBagData.letterDictionary;

    }

    public void RemoveLetterUsed(string letterToRemove)
    {


        if (bagLetters.Contains(letterToRemove))
        {
            bagLetters.Remove(letterToRemove);
            Debug.Log(letterToRemove + " tile was removed from bag. " + "There are " + bagLetters.Count + " remaining" );

        }


        
    }

}
