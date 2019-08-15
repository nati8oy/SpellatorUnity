using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int health = 100;
    public int currentScore;

    [SerializeField] public Text scoreText;

    public void SavePlayer()
    {
        currentScore = Points.totalScore;
        SaveSystem.SavePlayer(this);

        Debug.Log("current score saved is: " + currentScore);
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        currentScore = data.currentScore;
        scoreText.text = data.currentScore.ToString();

        Debug.Log("score loaded: " + currentScore);
    }


}
