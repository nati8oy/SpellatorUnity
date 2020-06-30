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
            if(levelDetails.levelComplete == true)
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

                if (stubbornTileFlag != true)
                {
                    Debug.Log("stubborn tile tutorial point");

                    ShowInfoPanel(0);
                    tutorialSO.currentTip = "Stubborn tiles don't age at all.";
                    stubbornTileFlag = true;
                }

                break;
            case "heart tiles":

                if (heartTileFlag != true)
                {
                    Debug.Log("heart tile tutorial point");
                    ShowInfoPanel(1);
                    tutorialSO.currentTip = "Use heart tiles to replenish health";
                    heartTileFlag = true;
                }

                break;
            case "double tiles":

                if (doubleTileFlag != true)
                {
                    Debug.Log("double tile tutorial point");

                    ShowInfoPanel(2);
                    tutorialSO.currentTip = "Double tiles score double points";
                    doubleTileFlag = true;
                }


                break;
            case "triple tiles":

                if (tripleTileFlag != true)
                {

                    Debug.Log("triple tile tutorial point");

                    ShowInfoPanel(3);
                    tutorialSO.currentTip = "Triple tiles score triple points";
                    tripleTileFlag = true;
                }

                break;

        }
    }

    //moves panel into view

    private void ShowInfoPanel(int infoPanelImage)
    {
        iTween.MoveTo(tutorialPanel, iTween.Hash("y", 1000, "easetype", "easeInOut", "time", 0.5f));
        tutorialSO.tutorialTipImage = tutorialTipImages[infoPanelImage];
        AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxUserInterface[5]);
    }

    public void CloseInfoPanel()
    {
        iTween.MoveTo(tutorialPanel, iTween.Hash("y", 1300, "easetype", "easeInOut", "time", 0.5f));
    }

}
