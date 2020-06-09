using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass
{

    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();

    public Vector3 startPosition;
    public string tileType;
    public string letter;
    public int points;
    public Color correctWord;
    public int randomSelector;
    public int age;

    //this list holds the different special types
    public List<string> specialTypes;

    //this defines the kind of special that the tile will be. Circle, square, etc.
    public string specialAttribute;

    //the chance of a special tile showing up
    public static int specialChance;



    public TileClass (Vector3 _startPosition) {

        age = 4;
        startPosition = _startPosition;

        specialTypes = new List<string>();

        specialChance = 5;

        //add special types on initialisaton
        specialTypes.Add("heart");
        specialTypes.Add("double");
        specialTypes.Add("triple");

        AllocateSpecialType();



        //Debug.Log("Tile type is: " + tileType + " Special type: " + specialAttribute);
    }

    public void AllocateSpecialType()
    {


        //choose a random number for special probability
        randomSelector = Random.Range(0, 6);
        //  Debug.Log("Random Selector is: " + randomSelector);

        if (randomSelector == specialChance)
        {
            tileType = "special";

            //choose a random special tile type
            specialAttribute = specialTypes[Random.Range(0, specialTypes.Count)];
            //  Debug.Log("Special attribute is: " + specialAttribute);

        }


        else if (randomSelector != specialChance)
        {
            tileType = "default";
            specialAttribute = "none";
        }



    }


}
