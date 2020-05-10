﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    public LevelClass levelSetup;
    public LevelManagerSO levelDetails;
    public TextMeshProUGUI levelDescriptionText;
    public string randomLevelSelection;

    public GameObject[] currentRack;

    public DifficultyGradientSO difficulty;

    public enum LevelRuleType
    {
        length, ending, containing, starting, points
    }

    public LevelRuleType levelRuleType; 

    public static int currentLevel;
    public List<int> allLevels = new List<int>();
    public List<string> _levelTypes = new List<string>();

    public static string levelDescription;

    public string lastLetter;
    public string firstLetter;


    ///Various subsets of letters for use with level rules below
    public List<string> _endingList = new List<string>();
    public List<string> _startingList = new List<string>();
    public List<string> _containingList = new List<string>();

    public bool _levelComplete;


    //sets the list for the int conditions below
    public List<int> conditionsList = new List<int>();

    //used for conditions containing ints (eg. word length)
    public static int firstCondition;
    public static int secondCondition;


    //used for conditions requiring strings (containg, etc.)
    public static string letterCondition;
    public static int pointsThreshold;


    public int numberOfConditions;


    //reward for complettion of the level
    public int reward;



    //set up singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;



        numberOfConditions = 4;

        //add the first condition to the rule
        for (int i = 0; i < numberOfConditions; i++)
        {
            conditionsList.Add(i);
        }

        //load data to choose the type of level from the SO
        _levelTypes = levelDetails.levelTypes;


        //set up lists to select from scriptable object
        _endingList = levelDetails.endingList;
        _startingList = levelDetails.startingList;
        _containingList = levelDetails.containingList;
        _levelComplete = levelDetails.levelComplete;


        //RANDOM VERSION
        randomLevelSelection = _levelTypes[Random.Range(0, _levelTypes.Count)];


    }

    // Start is called before the first frame update
    void Start()
    {
       

        //add 1 to the level each time it loads but only if it's less than 13
        //otherwise set it to 0
        if (levelDetails.currentLevel < 13)
        {
            levelDetails.currentLevel += 1;
        } else
        {
            levelDetails.currentLevel = 1;
        }

        Debug.Log("You are playing level " + levelDetails.currentLevel);

        switch (levelDetails.currentLevel)
        {
            case 1:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 3, 0);
                break;
            case 2:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 4, 3, 0);
                break;
            case 3:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 5, 3, 0);
                break;
            case 4:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 2, 4, 0);
                break;
            case 5:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 4, 0);
                break;
            case 6:
                levelRuleType = LevelRuleType.points;
                ConstructLevelParams("points", 3, 0, 20);
                break;
            case 7:
                levelRuleType = LevelRuleType.containing;
                ConstructLevelParams("containing", 3, 0, 0);
                break;
            case 8:
                levelRuleType = LevelRuleType.ending;
                ConstructLevelParams("ending", 2, 0, 0);
                break;
            case 9:
                levelRuleType = LevelRuleType.points;
                ConstructLevelParams("points", 3, 0, 50);
                break;
            case 10:
                levelRuleType = LevelRuleType.ending;
                ConstructLevelParams("ending", 3, 0, 0);
                break;
            case 11:
                levelRuleType = LevelRuleType.ending;
                ConstructLevelParams("starting", 3, 0, 0);
                break;
            case 12:
                levelRuleType = LevelRuleType.points;
                ConstructLevelParams("points", 4, 0, 40);
                break;
            case 13:
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 5, 0);
                break;

        }



        //set the letter in the difficulty SO so that it's available at the start of each level

        difficulty.focusLetter = letterCondition;
        Debug.Log("letter condition is: " + letterCondition);


        //SET VERSION
        //sets up the level parameters. eg. make 3 words that are 3 letters long.
        //ConstructLevelParams(randomLevelSelection);

            
    }


    //gets all the letter values of the tiles on the rack and puts them into "currentRack"
    public IEnumerator GetTilesOnRack(string levelType)
    {

        yield return new WaitForSeconds(2f);

        //set the currentRack array to be the tile 
        currentRack = GameObject.FindGameObjectsWithTag("Tile");

        Debug.Log("Coroutine started");
        //        Debug.Log("current rack contains " + currentRack.Length + " tiles");


        //check that the rack tile letter isn't "focus letter".
        //Also check the level type doesn't equal "points". The reason being that any other type of level rule will require a specific letter to be available

        //check if the rule is "points"
        if (levelType != "points")
        {

            //check if the letter is the one from the level rule
            if (currentRack[0].GetComponent<Tile>().letter.text != difficulty.focusLetter)
            {
                currentRack[0].GetComponent<Tile>().letter.text = difficulty.focusLetter;
                currentRack[0].GetComponent<Tile>().spawnedTile.points = TileBag.pointsDictionary[currentRack[0].GetComponent<Tile>().spawnedTile.letter];

            }
        }
         

        yield return null;

    }


    // Update is called once per frame
    void Update()
    {
        //this is the data from the level
        levelDescriptionText.text = levelDescription;
        levelDetails.levelRules = levelDescription;


    }



    //set up the rules for the level
    public void ConstructLevelParams(string levelType, int numberOfWords, int minWordLength, int pointsRequired)
    {
        //this sets the max number of letters in a word
        //secondCondition = conditionsList[Random.RandomRange(3, conditionsList.Count)]; ;
        secondCondition = minWordLength;


        //choose the second condition randomly from the list
        //Debug.Log("Second condition updated: " + secondCondition);

        //choose the first condition randomly from the list
        //firstCondition = conditionsList[Random.RandomRange(1, conditionsList.Count)];
        firstCondition = numberOfWords;

        //check if the letter is on the rack or not.
        StartCoroutine(GetTilesOnRack(levelType));


        if (levelType!="points")
        {
            difficulty.focusLetter = letterCondition;
        }

        switch (levelType)
        {

            case "length":
                levelDescription = "Make " + firstCondition.ToString() + " words using " + secondCondition.ToString() + " letters";

                break;

            case "ending":

                //choose the letter randomly
                letterCondition = _endingList[Random.Range(0, _endingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words ending in " + letterCondition;

                break;

            case "containing":

                //choose the letter randomly
                letterCondition = _containingList[Random.Range(0, _containingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words containing " + letterCondition;

                break;

            case "starting":

                //choose the letter randomly
                letterCondition = _startingList[Random.Range(0, _startingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words starting with " + letterCondition;

                break;
            case "points":

                //set the amount of points required to finish this level
                pointsThreshold = pointsRequired;
               // Debug.Log(levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsRequired + " points or more");

                levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsRequired + " points or more" ;

                break;

        }


        //set the level type for the Inumerator so that it can use the string and make sure there is a letter of that type on the rack
       // GetTilesOnRack(levelType);
        



    }

    public void LevelGoalCheck(string wordToCheck, string checkCriteria)
    {

        switch (checkCriteria)
        {


            case "length":
                  Debug.Log(firstCondition + " words remaining!");

                if (wordToCheck.Length == secondCondition)
                {
                    //reduce the first condition by one (track changes to quota essentially) 
                    //but only minus if the firstCondition is greater than 0
                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;

                    }
                    Debug.Log("length rule matched! " + firstCondition + " words remaining");
                }

                levelDescription = "Make " + firstCondition.ToString() + " words using " + secondCondition.ToString() + " letters";


                break;
            case "ending":

                //Debug.Log("letter condition: " + letterCondition);


                //split the lettters in the wordToCheck string and grab the last one
                //
                string[] endingCharacters = new string[wordToCheck.Length];
                for (int i = 0; i < wordToCheck.Length; i++)
                {

                    endingCharacters[i] = System.Convert.ToString(wordToCheck[i]);

                    //gets the start letter of the next word from the most recent word
                    lastLetter = endingCharacters[i];
                     //Debug.Log("Last letter: "+lastLetter);

                }

                //Debug.Log("letter condition: " + letterCondition + " last letter: " + lastLetter);

                if (letterCondition == lastLetter)
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words ending in " + letterCondition;

                    }


                    // Debug.Log("ending rule matched! " + firstCondition + " words remaining");
                }



                break;
            case "containing":

                if (wordToCheck.Contains(letterCondition))
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words containing " + letterCondition;

                    }


                }

                break;

            case "starting":
                //split the lettters in the wordToCheck string and grab the last one
                //
                string[] startingCharacters = new string[wordToCheck.Length];
                for (int i = 0; i < wordToCheck.Length; i++)
                {

                    startingCharacters[i] = System.Convert.ToString(wordToCheck[i]);

                    //gets the start letter of the next word from the most recent word
                    firstLetter = startingCharacters[0];

                }


                if (letterCondition == firstLetter)
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words starting with " + letterCondition;

                    }


                     //Debug.Log("ending rule matched! " + firstCondition + " words remaining");
                }

                break;

            case "points":
                if (Points.pointsScored >= pointsThreshold)
                {
                    firstCondition -= 1;

                    levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsThreshold + " points or more";

                    ///Debug.Log("First condition is " + firstCondition);

                }
                break;
        }



        //if the first condition is met (how many words required) then the level is complete
        if(firstCondition==0)
        {
            GameManager.Instance.LevelComplete();
        }


    }

}
