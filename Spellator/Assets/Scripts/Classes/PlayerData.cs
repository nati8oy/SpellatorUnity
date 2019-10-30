using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{

    public int currentScore;
    public List<string> playerWordsMade = new List<string>();
    public bool musicOn;
    public bool sfxOn;
    public List<int> highScores = new List<int>();

    public PlayerData (GameState gameState)
    {
        highScores = gameState.highScores;
 
        currentScore = gameState.currentScore;
        playerWordsMade = gameState.playerWordsMade;
        musicOn = gameState.musicOn;
        sfxOn = gameState.sfxOn;
    }
}
    