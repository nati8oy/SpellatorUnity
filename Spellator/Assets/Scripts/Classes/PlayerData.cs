using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{

    public int currentScore;
    public List<string> playerWordsMade = new List<string>();
    public bool audioToggle;
    public List<int> highScores = new List<int>();
    public int premiumCurrency;
    public int wordsPlayed;
    public string longestWord;
    public int skinSelection;

    public PlayerData (GameState gameState)
    {
        highScores = gameState.highScores;
        skinSelection = gameState.skinSelection;
 
        currentScore = gameState.currentScore;
        playerWordsMade = gameState.playerWordsMade;
     // audioToggle = gameState.audioToggle;
        premiumCurrency = gameState.premiumCurrency;
        wordsPlayed = gameState.wordsPlayed;
        longestWord = gameState.longestWord;

    }
}
    