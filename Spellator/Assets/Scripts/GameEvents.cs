using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action SaveInitiated;
    public static Action LoadInitiated;
    public static Action TutorialItemInitiated;

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }

    public static void OnLoadInitiated()
    {
        LoadInitiated?.Invoke();
    }

    public static void OnTutorialItemInitiated()
    {
        TutorialItemInitiated?.Invoke();
    }


}


