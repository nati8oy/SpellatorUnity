using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transition", menuName = "Cross Fade")]

public class TransitionsSO : ScriptableObject
{
    public bool fadeIn;

    public Color damageColour;
    public Color flashColour;
    public Color fadeColour;


    //set range to be used within the scriptable object
    [Range(0.01f, 0.07f)]
    public float defaultFadeSpeed;
    [Range(0.01f, 0.07f)]
    public float defaultPulseSpeed;


}
