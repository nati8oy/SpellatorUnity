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
       // AddEncouragementMessages();
       
    }

    public void ShowMessage()
    {

        parentObject = GameObject.Find("On Screen Messages");

        message = EncouragementMessages[Random.Range(0,EncouragementMessages.Count)];

        messageObject = GameObject.Find("Message Text").GetComponent<TextMeshProUGUI>();
        messageObject.text = message;

    }


}
