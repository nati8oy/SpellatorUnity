using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public static int multiplier;
    public static bool multiplierActive;
    public static int liveScore;
    public static int primaryTileScore;
    public static int mostRecentScore;

    public int pointsScored;
    public int pointsAdded;


    public static int totalScore;
    public Text liveScoreText;
    public Text currentScoreText;


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
        }
        else
        {
            totalScore += incomingPoints;
        }
    }

    private void Update()
    {

        currentScoreText.text = totalScore.ToString();
        liveScoreText.text = liveScore.ToString();


        if (Input.GetKeyDown("1"))
        {
            totalScore += 20;

        }
       
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

