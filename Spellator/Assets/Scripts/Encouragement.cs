using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encouragement 
{

    private List<string> encouragmentMessages = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        encouragmentMessages.Add("Wow!");
        encouragmentMessages.Add("Nice one!");
        encouragmentMessages.Add("Keep it up!");
        encouragmentMessages.Add("Excellent!");
        encouragmentMessages.Add("Totes amaze!");
        encouragmentMessages.Add("Great word!");
        encouragmentMessages.Add("Best!");
        encouragmentMessages.Add("Oh yeah!");
        encouragmentMessages.Add("Whoa!");
        encouragmentMessages.Add("Wunderbar!");
        encouragmentMessages.Add("Incredible!");


        //messageText.text = encouragmentMessages[Random.Range(0, 7)];
        //StartCoroutine(Move(endPos.transform.position));
    }

}
