using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass
{

    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();

    public Vector3 startPosition;
    public string tileType;
    public bool selected;
    public string letter;
    public int points;


    public TileClass (Vector3 _startPosition, string _tileType) {
        tileType = _tileType;
        selected = false;
        startPosition = _startPosition;

        if(tileType == "default")
        {
            letter = TileBag.bag[Random.Range(0, 95)];
            points = TileBag.pointsDictionary[letter];


            //points = TileBag.pointsDictionary[letter];
        } else if (tileType == "primary")
        {
            letter = DictionaryManager.Instance.StartLetter;
            points = TileBag.pointsDictionary[letter];
        }
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
