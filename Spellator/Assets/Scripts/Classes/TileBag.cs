﻿using System.Collections.Generic;
using UnityEngine;

public class TileBag
{
    private string lettersToSplit;

    //create the dictionary to store all of the words in
    private Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public List<string> consonants = new List<string>();
    public List<string> vowels = new List<string>();
    public List<string> rareConsonants = new List<string>();
    public int consonantCount;
    public int vowelCount;
    public int rareConsonantCount;
    public string letterCondition;
    public int bagSize;

    public static List<string> bag = new List<string>();

    //public List<string> bag = new List<string>();

    //public static List<string> bag = new List<string>() { "A", "A", "A", "A", "A", "A", "A", "A", "A", "S", "S", "S", " S", "T", "T", "T", "T", "T", "T", "B", "B",  "D", "D", "D", "D", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "I", "I", "I", "I", "I", "I", "I", "I", "I", "O", "O", "O", "O", "O", "O", "O", "O", "R", "R", "R", "R", "R", "R", "N", "N", "N", "N", "N", "N", "G", "G", "G", "L", "L", "L", "L", "F", "F", "C", "C", "Y", "Y", "H", "H",  "P", "P","U", "U", "U", "U", "V", "V", "W", "W", "Z", "J", "K","Q", "X" };

    //these two lists are only for external use. The other consonant and vowel lists below are  
    public static List<string> consonantListForExternalUse = new List<string>() { "B", "C", "D", "F", "G", "H", "L", "M", "N", "P", "R", "S", "T", "V", "W", "Y", "X", "J", "Q", "K", "Z" };
    public static List<string> vowelListForExternalUse = new List<string>() {"A", "E","I","O","U"};

    

    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();

    public TileBag(int _consonantCount, int _vowelCount)
    {
        consonantCount = _consonantCount;
        vowelCount = _vowelCount;

        SetupBag();

    }



    //alternative constructor for the bag
    public TileBag(int _consonantCount, int _vowelCount, int _additionalLetters)
    {
        consonantCount = _consonantCount;
        vowelCount = _vowelCount;
        letterCondition = LevelManager.letterCondition;

        for (int i = 0; i < 12; i++)
        {
            bag.Add(letterCondition);
            Debug.Log("Added " + _additionalLetters + " lettercondition");
        }

        SetupBag();

    }

    //constructor for the 100 tiles mode
    public TileBag(bool limitedMode, int _consonantCount, int _vowelCount, int _bagSize)
    {

        if (limitedMode)
        {
            consonantCount = _consonantCount;
            vowelCount = _vowelCount;
            letterCondition = LevelManager.letterCondition;
            bagSize = _bagSize;

        }

       
        SetupBag();

    }


    public void SetupBag()
    {
        //add vowels to list
        vowels.Add("A");
        vowels.Add("E");
        vowels.Add("I");
        vowels.Add("O");
        vowels.Add("U");

        //add consonants to list
        consonants.Add("B");
        consonants.Add("C");
        consonants.Add("D");
        consonants.Add("F");
        consonants.Add("G");
        consonants.Add("H");
        consonants.Add("L");
        consonants.Add("M");
        consonants.Add("N");
        consonants.Add("P");
        consonants.Add("R");
        consonants.Add("S");
        consonants.Add("T");
        consonants.Add("V");
        consonants.Add("W");
        consonants.Add("Y");

        //add rare/high scoring consonants
        rareConsonants.Add("K");
        rareConsonants.Add("Q");
        rareConsonants.Add("J");
        rareConsonants.Add("X");
        rareConsonants.Add("Z");
        //create the bag


        for (int i = 0; i < consonantCount; i++)
        {
            bag.Add(consonants[Random.Range(0, consonants.Count)]);
        }

        for (int j = 0; j < vowelCount; j++)
        {
            bag.Add(vowels[Random.Range(0, vowels.Count)]);
        }


        foreach(string rareConsonantLetter in rareConsonants)
        {
            bag.Add(rareConsonantLetter);
//            Debug.Log("rare consonant added: " + rareConsonantLetter);
        }


        /*
        for (int k = 0; k < rareConsonantCount; k++)
        {
            bag.Add(rareConsonants[Random.Range(0, rareConsonants.Count)]);
        }*/

        //        Debug.Log("Bag total: " + bag.Count);
    }

}
