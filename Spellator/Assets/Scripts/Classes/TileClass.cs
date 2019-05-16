using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass
{

    public string tileType;
    public string letter;
    public int points;
    public bool selected;
    public Vector3 startPosition;
    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();


    public TileClass (Vector3 _startPosition) {

        tileType = "default";
        letter = TileBag.bag[Random.Range(0, 95)];
        points = TileBag.pointsDictionary[letter];
        selected = false;
        startPosition = _startPosition;


    }

    public void Scramble()
    {
        letter = TileBag.bag[Random.Range(0, 95)];
        points = TileBag.pointsDictionary[letter];
    }

    //this is a test function only to print things out that are getting passed in
        public void PrintBase(string _tileType, string _letter, int _points)
        {

            tileType = _tileType;
            letter = _letter;
            points = _points;

            Debug.Log("Tile Type: " + tileType);
            Debug.Log("Letter: " + letter);
            Debug.Log("Points: " + points);
           
    }
        
}
