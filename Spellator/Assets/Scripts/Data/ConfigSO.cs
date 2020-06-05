using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Word Data", menuName = "Word List")]
[System.Serializable]

public class ConfigSO : ScriptableObject
{
    public List<string> uniqueWordsList;
    public bool sfxOn;
    public bool musicOn;

    public string favouriteWordLength;

    public int totalWordsMade;
    public string currentStatus;
    public string longestWord;
    public int uniqueWords;
    public int totalGoldAmount;
    public string currentRank;
    public int levelProgressXP;
    public int[] levelXP;
   

    public List<int> skinsPurchased = new List<int>();


    //public int highScore;
    //public Vector3[] playedTilePositions;

    private List<int> wordLengths = new List<int>();
    //public List<int> topTenHighScores = new List<int>();



    public void FavouriteWordLength()
    {
        foreach (string word in uniqueWordsList)
        {
            wordLengths.Add(word.Length);
        }
    }


    /*
    public void SetHighScores(int score)
    {
        //add the high scores to the top 10 list of high scores.

        highScore = score;

        topTenHighScores.Add(highScore);
        topTenHighScores.Sort();


        /*
        if ((highScore >= topTenHighScores[9])&&())
        {
            topTenHighScores.Add(highScore);

        }*/


        //check each of the scores in the list against the incoming score.

        /*
        foreach (int playerScore in topTenHighScores)
        {
            //check if the incoming score is higher than those in the list already
            if (score>= playerScore && topTenHighScores.Count<9)
            {
                highScore = playerScore;
                topTenHighScores.Add(highScore);
                Debug.Log(topTenHighScores);
            }
        }
    }

    */


    public void FindLongestWord()
    {

        foreach (string word in uniqueWordsList)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
                Debug.Log(longestWord);
            }
        }
    }

}
