using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAnimInactive : MonoBehaviour
{
    //this is a simple script to set the tile inactive

    public Animator anim;

    public void setAnimationInactive()
    {
        gameObject.SetActive(false);
    }

    public void resetScoreAnimation(string animationValue)
    {
        anim.SetBool(animationValue, false);

    }
}
