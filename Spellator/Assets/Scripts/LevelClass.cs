using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClass
{

    public static int currentLevel;
    public List<int> allLevels = new List<int>();
    public List<string> levelTypes = new List<string>();



    public List<string> consonantList = new List<string>() { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z" };
    public List<string> vowelList = new List<string>() { "A", "E", "I", "O", "U" };

    //sets the list for the int conditions below
    public List<int> conditionsList = new List<int>();

    //used for conditions containing ints (eg. word length)
    public int firstCondition;
    public int secondCondition;


    //used for conditions requiring strings (containg, etc.)
    public string letterCondition;


    public int numberOfConditions;


    //reward for complettion of the level
    public int reward;


    public LevelClass()
    {

        //set up the params for the upcoming level rules

        numberOfConditions = 4;

        //add the first condition to the rule
        for (int i = 0; i < numberOfConditions; i++)
        {
            conditionsList.Add(i);
        }

    }

    public void ConstructLevelParams(string levelType)
    {

        //choose the first condition randomly from the list
        firstCondition = conditionsList[Random.RandomRange(1, conditionsList.Count)];

        switch (levelType)
        {
            case "length":

                //choose the second condition randomly from the list
                secondCondition = conditionsList[Random.RandomRange(2, conditionsList.Count)];

                Debug.Log("Make " + firstCondition + " words using " + (secondCondition+1) + " letters");


                break;

            case "ending":

                //choose the letter randomly
                letterCondition = consonantList[Random.Range(0, consonantList.Count)];

                Debug.Log("Make " + firstCondition + " words ending in " + letterCondition);

                break;

            case "containing":

                //choose the letter randomly
                letterCondition = vowelList[Random.Range(0, vowelList.Count)];


                Debug.Log("Make " + firstCondition + " words containing " + letterCondition);

                break;

            case "starting":
             
                //choose the letter randomly
                letterCondition = consonantList[Random.Range(0, consonantList.Count)];

                Debug.Log("Make " + firstCondition + " words starting with " + letterCondition);

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
                firstCondition -= 1;
                Debug.Log(wordToCheck.Length);

            }
                break;
            case "ending":
                break;
            case "containing":
                break;
            case "starting":
                break;
        }


    }


}
