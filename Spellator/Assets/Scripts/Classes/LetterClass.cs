using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterClass 
{
    //what is the letter that is being spawned
    public string letter;

    //how rare is this letter? rarer letters should be used less frequently
    public int rarity;

    // public enum TypeOfLetter { Vowel, Consonant};
    public string typeOfLetter;
    public List<string> common = new List<string>();
    public List<string> rare = new List<string>();
    public List<string> veryRare = new List<string>();


    //this is used for vowel or consonant identifiers

    public LetterClass()
    {
        switch (letter)
        {
           case "A" :
                typeOfLetter = "vowel";
                rarity = 1;
                break;

            case "B":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "C":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "D":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "E":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "F":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "G":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "H":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "I":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "J":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "K":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "L":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "M":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "N":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "O":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "P":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "Q":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "R":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "S":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "T":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "U":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "V":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "W":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "X":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "Y":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
            case "Z":
                typeOfLetter = "consonant";
                rarity = 3;
                break;
        }
    }
}
