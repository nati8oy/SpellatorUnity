using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsClass
{
    public static int totalScore;
    public static int multiplier;
    public static bool multiplierActive;
    public static int liveScore;
    public static int primaryTileScore;
    public static int mostRecentScore;
    public int pointsScored;
    public int bonusPoints;
    public int pointsAdded;
   

    public PointsClass()
    {
        //set the primary tile score to be that 
        primaryTileScore = 0;
        //default multiplier to 1 as that's the minimum.
        multiplier = 1;
    }

    public void addPoints(int _pointsScored)
    {

        pointsScored = _pointsScored;

        if (multiplierActive==true)
        {
            totalScore = totalScore + (pointsScored * multiplier);
            //Debug.Log("multplier is active and is set to: " + multiplier);
        } else if (multiplierActive==false)
        {
            totalScore = totalScore + pointsScored;
            //Debug.Log("multplier is inactive");
        }

        mostRecentScore = liveScore;
        liveScore = primaryTileScore;
    }

    public void addLiveScore(int _pointsAdded)
    {
        pointsAdded = _pointsAdded;
        liveScore = pointsAdded + liveScore;
    }

    public void resetScores()
    {
        liveScore = 0 + primaryTileScore;

    }
}
