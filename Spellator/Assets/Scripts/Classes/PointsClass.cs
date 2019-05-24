using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsClass
{
    public static int totalScore;
    public static int multiplier;
    public static int liveScore;
    public static int primaryTileScore;
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
        totalScore = totalScore + pointsScored + bonusPoints + liveScore;
        liveScore = primaryTileScore;
    }

    public void addLiveScore(int _pointsAdded)
    {
        pointsAdded = _pointsAdded;
        liveScore = liveScore + pointsAdded + primaryTileScore;
    }

    public void resetScores()
    {
        liveScore = 0 + primaryTileScore;

    }
}
