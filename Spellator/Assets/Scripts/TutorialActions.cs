using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TutorialActions : MonoBehaviour
{
    public static Action <string> TutorialItemInitiated;

    public static void OnTutorialItemInitiated(string tutorialItem)
    {
        TutorialItemInitiated?.Invoke(tutorialItem);
    }
}


