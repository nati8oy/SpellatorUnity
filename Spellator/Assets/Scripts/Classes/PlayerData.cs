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

    public PlayerData (GameState gameState)
    {
 
        currentScore = gameState.currentScore;
        playerWordsMade = gameState.playerWordsMade;
        musicOn = gameState.musicOn;
        sfxOn = gameState.sfxOn;
    }
}
    