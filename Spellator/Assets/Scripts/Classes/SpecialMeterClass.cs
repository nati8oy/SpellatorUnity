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
        totalMeter = 50;
        meterRemaining = 0;
        meterPercent = meterRemaining / totalMeter;


    }

    public void IncreaseMeter(float amountToAdd)
    {
       
            meterRemaining = amountToAdd + meterRemaining;
            meterPercent = meterRemaining / totalMeter;


    }
}
