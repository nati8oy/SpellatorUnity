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
    //    public int randomSelector;
    public float randomSelector;
    public float randomTilePowerSelector;

    public string tilePower;

    //public static float Range(float min, float max);

    public int age;

    public float randomTypeSelector;
    public int specialChanceSelector;

    //this list holds the different special types
    public List<string> specialTypes;

    //this defines the kind of special that the tile will be. Circle, square, etc.
    public string specialAttribute;

    //the chance of a special tile showing up
    public static int specialChance;



    public TileClass (Vector3 _startPosition) {


        //specialChanceSelector = 100;

        age = 4;
        startPosition = _startPosition;

        specialTypes = new List<string>();

       // specialChance = 5;

        //add special types on initialisaton
       // specialTypes.Add("heart");
        specialTypes.Add("double");
        specialTypes.Add("triple");
        specialTypes.Add("stubborn");
        AllocateSpecialType();



        //Debug.Log("Tile type is: " + tileType + " Special type: " + specialAttribute);
    }

    public void AllocateSpecialType()
    {
        //this is the chance of getting a special tile in the first place. 
        specialChance = 3;

        //select a random number
        randomSelector = Random.Range(0, specialChance+1);
        randomTilePowerSelector = Random.Range(0, specialChance + 1);

//        Debug.Log(randomSelector + randomTilePowerSelector);

        //        Debug.Log("random selector " + randomSelector);

        if (randomSelector == specialChance)
        {
            tileType = "special";
            // Debug.Log("match");

            specialAttribute = specialTypes[Random.Range(0, specialChance)];


        }
        else
        {
            tileType = "default";
            //Debug.Log("no match");
            specialAttribute = "none";

        }

            if(randomTilePowerSelector == specialChance)
        {
            tilePower = "heal";
        }

            /*
        switch (specialAttribute)
        {
            case "stubborn":
                TutorialActions.OnTutorialItemInitiated("stubborn tiles");
                break;

            case "heart":
                TutorialActions.OnTutorialItemInitiated("heart tiles");
                break;

            case "double":
                TutorialActions.OnTutorialItemInitiated("double tiles");
                break;

            case "triple":
                TutorialActions.OnTutorialItemInitiated("triple tiles");
                break;

        }

            */
        /*
        //choose a random number for special probability
        randomSelector = Random.Range(0, specialChance);
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

        */
        /*
        float CurveWeightedRandom(AnimationCurve curve)
        {
            //multiply the float that is returned by 100
            return curve.Evaluate(Random.value) * specialChanceSelector;
        }


        randomTypeSelector =  Mathf.CeilToInt(CurveWeightedRandom(GameManager.Instance.mainAnimationCurve));


        //CurveWeightedRandom(mainAnimationCurve);

    */
    }




}
