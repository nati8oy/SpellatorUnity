using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encouragement : Messages
{

    //private GameObject endPos;
    private List<string> encouragmentMessages = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //endPos = GameObject.Find("Score");
        base.Start();

        encouragmentMessages.Add("Wow!");
        encouragmentMessages.Add("Nice one!");
        encouragmentMessages.Add("Word up!");
        encouragmentMessages.Add("Excellent!");
        encouragmentMessages.Add("Totes amaze!");
        encouragmentMessages.Add("Great word!");
        encouragmentMessages.Add("Best!");
        encouragmentMessages.Add("Oh yeah!");
        encouragmentMessages.Add("Whoa!");

        messageText.text = encouragmentMessages[Random.Range(0, 7)];
        StartCoroutine(Move(endPos.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
