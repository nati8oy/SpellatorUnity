using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComplete : MonoBehaviour
{
    public Animator anim;

public void SetAnimationComplete(string boolName)
    {
        anim.SetBool(boolName, false);
    }

}
