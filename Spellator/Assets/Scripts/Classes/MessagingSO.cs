using UnityEngine;

[CreateAssetMenu(fileName = "New Messaging System", menuName = "Messaging System")]

public class MessagingSO : ScriptableObject
{

    public string[] OnScreenMessages;
    //public GameObject messageDisplayObject;
    //public GameObject messageObject;

/*
    public void ShowMessage()
    {
        iTween.FadeTo(messageDisplayObject, iTween.Hash("alpha", 1, "amount", 1, "easeType", "easeInOutExpo", "oncomplete", "DeactivateMessage"));

    }
    */

}


