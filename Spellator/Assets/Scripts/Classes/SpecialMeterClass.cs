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

    public void IncreaseMeter(float _meterRemaining)
    {
        if (meterRemaining <= 1)
        {
            meterRemaining = _meterRemaining + meterRemaining;
            meterPercent = meterRemaining / totalMeter;
        }

    }
}
