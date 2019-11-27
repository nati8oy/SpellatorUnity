using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Object", menuName = "Level Manager")]


public class LevelManagerSO : ScriptableObject
{

    //public enum Level {wordLength, firstLetter, lastLetter, specificWord }

    [Header("Level Data")]
    //what the current level or difficulty of the game is
    public int currentLevel;

    //public int numberOfWordsToMake;
    //public int numberOflettersToUse;

    //a list of all the levels. E.g. where the 
    public List<int> allLevels = new List<int>();

    //the kinds of level, word length, ending, containing, start with, etc.
    public List<string> levelTypes = new List<string>();

    //the reward for the level.
    public int reward;

    //check to see if the level is complete or not
    public bool levelComplete;

    //use this for tracking how many levels in they are.
    public int overallLevel;

    //the description text that tells you how to win a level
    //e.g. make 3 words ending in T
    public string levelRules;

    //each of the lists from which to choose when a rule is set.
    //rules can only be set for words to end with these letters
    public List<string> endingList = new List<string>();

    //rules can only be set for words to start with these letters
    public List<string> startingList = new List<string>();

    //rules can only be set for words to contain these letters
    public List<string> containingList = new List<string>();



}
