﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{

    public static int multiplier;
    public static bool multiplierActive;
    public static int liveScore;
    public static int primaryTileScore;
    public static int mostRecentScore;

    public static int pointsScored;
    public int pointsAdded;


    public static int totalScore;
    public TextMeshProUGUI liveScoreText;
    //public Text liveScoreText;
    public TextMeshProUGUI currentScoreText;
    //public Text currentScoreText;


    private void Start()
    {
        //set the primary tile score to be 0 on startup 
        primaryTileScore = 0;
        //default multiplier to 1 as that's the minimum.
        multiplier = 1;
        //currentScore.text = totalScore.ToString();
    }


    public static void AddPoints (int incomingPoints)
    {

        if (multiplier > 2)
        {
            totalScore += (incomingPoints * multiplier);
            pointsScored = (incomingPoints * multiplier);
            //Debug.Log(pointsScored);

        }
        else
        {
            totalScore += incomingPoints;
            pointsScored = incomingPoints;
           // Debug.Log(pointsScored);

        }

    }

    private void Update()
    {

        currentScoreText.text = totalScore.ToString();
        liveScoreText.text = liveScore.ToString();

       
    }

    public static void resetScores()
    {

        GameManager.Instance.LiveScoreText.text = "";
        liveScore = primaryTileScore;


        /*
        if (GameObject.FindGameObjectWithTag("PrimaryTile"))
        {
            liveScore = 0 + primaryTileScore;
            Debug.Log("yes there was a primary tile and these are its points");
        }

        else
        {
        }
        */
    }

    public static void AddToLiveScore(int tileScore)
    {
        liveScore += tileScore;
    }
}

