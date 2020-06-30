using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialPanel;
    public Sprite[] tutorialTipImages;
    public LevelManagerSO levelDetails;
    public bool doubleTileFlag;
    public bool tripleTileFlag;
    public bool stubbornTileFlag;
    public bool heartTileFlag;


    public TutorialSO tutorialSO;
    // Start is called before the first frame update

    void Start()
    {
        if (GameManager.Instance.TutorialOn)
        {
            TutorialActions.TutorialItemInitiated += CheckTutorialItem;
        }

        //set the flags based on the GameManager TutorialOn boolean
        if (GameManager.Instance.TutorialOn)
        {
            //set the flags to true if the tutorial is on so that they don't show
            doubleTileFlag = false;
            tripleTileFlag = false;
            stubbornTileFlag = false;
            heartTileFlag = false;
        }
        else
        {
            //set the flags to true if the tutorial is on so that they don't show
            doubleTileFlag = true;
            tripleTileFlag = true;
            stubbornTileFlag = true;
            heartTileFlag = true;
        }
    }

    private void Update()
    {
            if(levelDetails.levelComplete == false)
        {
            TutorialActions.TutorialItemInitiated -= CheckTutorialItem;
        }
  
    }

    //check which tutorial item has come up (via string) and create the appropriate info bubble.

    public void CheckTutorialItem(string tutorialItem)
    {
        switch (tutorialItem)
        {
            case "stubborn tiles":
                Debug.Log("stubborn tile tutorial point");

                ShowInfoPanel(0);
                tutorialSO.currentTip = "Stubborn tiles don't age at all.";

                break;
            case "heart tiles":
                Debug.Log("heart tile tutorial point");
                ShowInfoPanel(1);
                tutorialSO.currentTip = "Use heart tiles to replenish health";

                break;
            case "double tiles":
                Debug.Log("double tile tutorial point");

                ShowInfoPanel(2);
                tutorialSO.currentTip = "Double tiles score double points";
                break;
            case "triple tiles":
                Debug.Log("triple tile tutorial point");

                ShowInfoPanel(3);
                tutorialSO.currentTip = "Triple tiles score triple points";
                break;

        }
    }

    //moves panel into view

    private void ShowInfoPanel(int infoPanelImage)
    {
        iTween.MoveBy(tutorialPanel, iTween.Hash("y", -300, "easetype", "easeInOut", "time", 0.5f));
        tutorialSO.tutorialTipImage = tutorialTipImages[infoPanelImage];
    }

    public void CloseInfoPanel()
    {
        iTween.MoveBy(tutorialPanel, iTween.Hash("y", 300, "easetype", "easeInOut", "time", 0.5f));
    }

}
