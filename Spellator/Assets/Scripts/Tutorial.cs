using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialBubble;
    public GameObject tutorialPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.TutorialOn)
        {
            TutorialActions.TutorialItemInitiated += CheckTutorialItem;
        }
    }

    //check which tutorial item has come up (via string) and create the appropriate info bubble.

    public void CheckTutorialItem(string tutorialItem)
    {
        switch (tutorialItem)
        {
            case "stubborn tiles":
                Debug.Log("stubborn tile tutorial point");
                break;
            case "heart tiles":
                Debug.Log("heart tile tutorial point");

                //moves panel into view
                iTween.MoveBy(tutorialPanel, iTween.Hash("y", -300, "easetype", "easeInOut", "time", 0.5f));

                break;
            case "double tiles":
                Debug.Log("double tile tutorial point");
                break;
            case "triple tiles":
                Debug.Log("triple tile tutorial point");
                break;

        }
    }

    public void CloseInfoPanel()
    {
        iTween.MoveBy(tutorialPanel, iTween.Hash("y", 300, "easetype", "easeInOut", "time", 0.5f));
    }

}
