using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int level;
    public int health;
    public int currentScore;

    public PlayerData (Player player)
    {
        
        level = player.level;
        health = player.health;
        currentScore = player.currentScore;

    }
}
    