using System.Collections;
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



        numberOfConditions = 6;

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


        //SET VERSION
        //sets up the level parameters. eg. make 3 words that are 3 letters long.
        ConstructLevelParams(randomLevelSelection);

    }

    // Update is called once per frame
    void Update()
    {
        //this is the data from the level
        levelDescriptionText.text = levelDescription;
        levelDetails.levelRules = levelDescription;


    }



    //set up the rules for the level
    public void ConstructLevelParams(string levelType)
    {
        //this sets the max number of letters in a word
        secondCondition = conditionsList[Random.RandomRange(3, conditionsList.Count)]; ;

        //choose the second condition randomly from the list
        //Debug.Log("Second condition updated: " + secondCondition);

        //choose the first condition randomly from the list
        firstCondition = conditionsList[Random.RandomRange(1, conditionsList.Count)];


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
        }

    }

    public void LevelGoalCheck(string wordToCheck, string checkCriteria)
    {

        switch (checkCriteria)
        {


            case "length":
                //  Debug.Log(firstCondition + " words remaining!");

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
                    // Debug.Log("Last letter: "+lastLetter);

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


                    // Debug.Log("ending rule matched! " + firstCondition + " words remaining");
                }

                break;
        }

        if(firstCondition==0)
        {
            GameManager.Instance.LevelComplete();
        }


    }

}
