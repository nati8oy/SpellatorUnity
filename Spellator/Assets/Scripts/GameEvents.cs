using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static System.Action SaveInitiated;
    public static System.Action LoadInitiated;
    public static System.Action TutorialItemInitiated;


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


