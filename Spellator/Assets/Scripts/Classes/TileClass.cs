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

        specialChance = 20;

        //add special types on initialisaton
        specialTypes.Add("triangle");
        specialTypes.Add("circle");
        specialTypes.Add("square");
        specialTypes.Add("star");

        //choose a random number for special probability
        randomSelector = Random.Range(1,20);

        if (randomSelector >= (specialChance-1))
        {
            tileType = "special";
            specialAttribute = specialTypes[Random.Range(0, 3)];
        }

        else if (randomSelector < (specialChance - 1))
        {
            tileType = "default";
            specialAttribute = "none";
        }

        //Debug.Log("Tile type is: " + tileType + " Special type: " + specialAttribute);
    }

    



    /*
    interface ITile
    {
       string TileType { get; set; }
       string Letter { get; set; }
       int Points { get; set; }
       bool Selected { get; set; }
       Transform StartPositon { get; set; }
    }


    class DefaultTile : ITile
    {
        public string TileType { get; set; }
        public string Letter { get; set; }
        public int Points { get; set; }
        public bool Selected { get; set; }
        public Transform StartPositon { get; set; }

        public DefaultTile(Transform _startPositon)
        {
            TileType = "default";
            Letter = TileBag.bag[Random.Range(0, 95)];
            Points = TileBag.pointsDictionary[Letter];
            Selected = false;
            StartPositon = _startPositon;
        }
    }


    class StarterTile : ITile
    {
        public string TileType { get; set; }
        public string Letter { get; set; }
        public int Points { get; set; }
        public bool Selected { get; set; }
        public Transform StartPositon { get; set; }

        public StarterTile(Transform _startPositon)
        {
            TileType = "starter";
            Letter = DictionaryManager.Instance.StartLetter;
            Points = TileBag.pointsDictionary[Letter];
            Selected = false;
            StartPositon = _startPositon;
        }
    }*/

}
