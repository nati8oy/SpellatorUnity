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

    public PlayerData (GameState gameState)
    {
        highScores = gameState.highScores;
 
        currentScore = gameState.currentScore;
        playerWordsMade = gameState.playerWordsMade;
       audioToggle = gameState.audioToggle;
        premiumCurrency = gameState.premiumCurrency;

    }
}
    