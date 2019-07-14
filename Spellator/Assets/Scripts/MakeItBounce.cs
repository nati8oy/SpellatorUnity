using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        iTween.MoveBy(gameObject, iTween.Hash("y", 20, "easetype", "easeOutCirc", "time", 0.5f, "loopType", "pingPong"));

    }

   
}