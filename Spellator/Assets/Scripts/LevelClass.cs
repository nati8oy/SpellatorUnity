﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClass
{

    public static int currentLevel;
    public List<int> allLevels = new List<int>();
    public List<string> levelTypes = new List<string>();

    public static string levelDescription;

    public string lastLetter;
    public string firstLetter;


    ///Various subsets of letters for use with level rules below
    public List<string> endingList = new List<string>() { "B", "D", "G", "H", "K", "L", "M", "N", "P", "R", "S", "T", "W", "A", "E" };
    public List<string> startingList= new List<string>() { "B", "C", "D", "F", "G", "H", "K", "L", "M", "N", "P", "R", "S", "T", "V", "W", "Y", "Z" };
    public List<string> containingList = new List<string>() { "A", "E", "I", "O", "U", "B", "C", "D", "F", "G", "H", "K", "L", "M", "N", "P", "R", "S", "T", "V", "W", "X", "Y"};


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

        secondCondition = 4;

        //choose the second condition randomly from the list
        //Debug.Log("Second condition updated: " + secondCondition);

        //choose the first condition randomly from the list
        firstCondition = conditionsList[Random.RandomRange(1, conditionsList.Count)];

        //set the level reward to be the first condition
        reward = firstCondition;
        Debug.Log("level reward is " + reward);


        switch (levelType)
        {
            case "length":
                levelDescription = "Make " + firstCondition.ToString() + " words using " + secondCondition.ToString() + " letters";

                break;

            case "ending":

                //choose the letter randomly
                letterCondition = endingList[Random.Range(0, endingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words ending in " + letterCondition;


                break;

            case "containing":

                //choose the letter randomly
                letterCondition = containingList[Random.Range(0, containingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words containing " + letterCondition;

                break;

            case "starting":
             
                //choose the letter randomly
                letterCondition = startingList[Random.Range(0, startingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words starting with " + letterCondition;

                break;
        }

    }

    public void LevelGoalCheck(string wordToCheck, string checkCriteria)
    {

        //Debug.Log("current goal check is: " + checkCriteria);

      

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
                    Debug.Log("length rule matched! " + firstCondition + " words remaining" );
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


    }


}
