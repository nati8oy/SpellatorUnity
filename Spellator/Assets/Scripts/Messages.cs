using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Messages
{
    public string message;
    public TextMeshProUGUI messageObject;
    public GameObject parentObject;
    public static Vector3 startPos;
    public List<string> EncouragementMessages;

   public Messages()
    {
        AddEncouragementMessages();
        //parentObject = GameObject.Find("On Screen Messages");
        //message = GameManager.Instance.mostRecentScore.ToString();
        //iTween.MoveBy(GameManager.Instance.MessageObject, new Vector3(200,0), 1);

    }

    public void ShowMessage()
    {

        parentObject = GameObject.Find("On Screen Messages");

        message = EncouragementMessages[Random.Range(0,EncouragementMessages.Count)];

        messageObject = GameObject.Find("Message Text").GetComponent<TextMeshProUGUI>();
        messageObject.text = message;

    }

    public void AddEncouragementMessages()
    {
        EncouragementMessages = new List<string>();
        EncouragementMessages.Add("Marvellous!");
        EncouragementMessages.Add("Amazing!");
        EncouragementMessages.Add("Wow!");
        EncouragementMessages.Add("Nice word!");
        EncouragementMessages.Add("Smashing it!");
        EncouragementMessages.Add("Holy Heck!");
        EncouragementMessages.Add("For real?!");
        EncouragementMessages.Add("Love!");

    }

}
