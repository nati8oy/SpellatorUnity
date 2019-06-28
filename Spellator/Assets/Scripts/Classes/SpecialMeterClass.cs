using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMeterClass
{
    public static float totalMeter;
    public static float meterRemaining;
    public static float meterPercent;

    public SpecialMeterClass()
    {
        totalMeter = 1;
        meterRemaining = 1;
        meterPercent = meterRemaining / totalMeter;


    }

    public void IncreaseMeter(float amountToAdd)
    {

        //increases the amount of life meter you have remaining
        if (meterPercent < 1)
        {
            meterRemaining = (amountToAdd / 50) + meterRemaining;
            meterPercent = meterRemaining / totalMeter;
            //meterPercent = (meterRemaining / 10);
            //Debug.Log("Meter percent is: "+ meterPercent+ " Meter increased by: " + amountToAdd);
        }

        /*
        if (meterPercent < 1)
        {
            meterRemaining = amountToAdd + meterRemaining;
            // meterPercent = (meterRemaining / totalMeter) / 10;
            meterPercent = (meterRemaining / 10);
            Debug.Log("increased meter by: "+ amountToAdd);
           // meterPercent = (meterRemaining / totalMeter) / 100;

        }*/

        /*
        else if (meterPercent >= 1)
        {
            meterRemaining = 0;
            meterRemaining = amountToAdd + meterRemaining;
            meterPercent = (meterRemaining / totalMeter) / 10;
        }*/

    }

    public void DecreaseMeter(float reduceBy)
    {

        if (meterPercent <= 1)
        {
            meterRemaining =  meterRemaining - (reduceBy/100);
            meterPercent = meterRemaining / totalMeter;
            // meterPercent = (meterRemaining / totalMeter) / 100;
        }

        /*
        else if (meterPercent < 0)
        {
            meterPercent = 0;
        }*/
    }

}
