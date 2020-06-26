using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Tutorial data", menuName = "Tutorial Object")]

public class TutorialSO : ScriptableObject
{
    //public GameObject[] speechBubbles;
    public string currentTip;
    public Sprite tutorialTipImage;

}
