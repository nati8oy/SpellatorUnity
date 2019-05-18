using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages
{
    public string messageText;
    public Color textColour;

   public Messages()
    {
        messageText = GameManager.Instance.mostRecentScore.ToString();
      //  iTween.MoveBy(messageObject, new Vector3(200,0), 1);
       
    }

}
