using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.TutorialOn)
        {
            TutorialActions.TutorialItemInitiated += CheckTutorialItem;
        }
    }

    public void CheckTutorialItem(string tutorialItem)
    {
        switch (tutorialItem)
        {
            case "stubborn tiles":
                Debug.Log("stubborn tile tutorial point");
                break;
        }
    }

}
