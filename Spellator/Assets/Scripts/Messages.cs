using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages
{
    public string message;
    public Color textColour;

   public Messages()
    {
        //message = GameManager.Instance.mostRecentScore.ToString();
        //iTween.MoveBy(GameManager.Instance.MessageObject, new Vector3(200,0), 1);
       
    }

    public void MessageToDisplay(string _message)
    {
        message = _message;

    }

}
