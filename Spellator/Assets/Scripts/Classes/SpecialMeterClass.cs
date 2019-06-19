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
        meterRemaining = 0;
        meterPercent = meterRemaining / totalMeter;


    }

    public void IncreaseMeter(float amountToAdd)
    {

        if (meterPercent < 1)
        {
            meterRemaining = amountToAdd + meterRemaining;
            meterPercent = (meterRemaining / totalMeter) / 10;
           // meterPercent = (meterRemaining / totalMeter) / 100;
            Debug.Log("Meter percent is: " + meterPercent);
        }
        else if (meterPercent >= 1)
        {
            meterRemaining = 0;
            meterRemaining = amountToAdd + meterRemaining;
            meterPercent = (meterRemaining / totalMeter) / 10;
        }

    }

}
