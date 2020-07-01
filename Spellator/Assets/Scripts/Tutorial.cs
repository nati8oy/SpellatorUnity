using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public GameObject tutorialPanel;
    public Sprite[] tutorialTipImages;
    public LevelManagerSO levelDetails;
    private bool doubleTileFlag;
    private bool tripleTileFlag;
    private bool stubbornTileFlag;
    private bool heartTileFlag;
    private bool defaultTileFlag;
    private bool deleteButtonFlag;
    private bool tileAgeFlag;
    private bool validWordFlag;
    private bool initialInstructionsFlag;


    public TutorialSO tutorialSO;
    // Start is called before the first frame update

    void Start()
    {
       

        //set the flags based on the GameManager TutorialOn boolean
        if (tutorialSO.tutorialOn)
        {
            TutorialActions.TutorialItemInitiated += CheckTutorialItem;


            //set the flags to true if the tutorial is on so that they don't show
            doubleTileFlag = false;
            tripleTileFlag = false;
            stubbornTileFlag = false;
            heartTileFlag = false;
            defaultTileFlag = false;
            deleteButtonFlag = false;
            tileAgeFlag = false;
            validWordFlag = false;
            initialInstructionsFlag = false;
}
        else
        {
            //set the flags to true if the tutorial is on so that they don't show
            doubleTileFlag = true;
            tripleTileFlag = true;
            stubbornTileFlag = true;
            heartTileFlag = true;
            defaultTileFlag = true;
            deleteButtonFlag = true;
            tileAgeFlag = true;
            validWordFlag = true;
            initialInstructionsFlag = true;
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
                    ShowInfoPanel(2);
                    tutorialSO.currentTip = "Double tiles score double points";
                    doubleTileFlag = true;
                }


                break;
            case "triple tiles":

                if (tripleTileFlag != true)
                {
                    ShowInfoPanel(3);
                    tutorialSO.currentTip = "Triple tiles score triple points";
                    tripleTileFlag = true;
                }

                break;

            case "default tiles":

                if (defaultTileFlag != true)
                {
                    ShowInfoPanel(4);
                    tutorialSO.currentTip = "Tile scores are shown below the letter";
                    defaultTileFlag = true;
                }

                break;

            case "delete button":

                if (deleteButtonFlag != true)
                {
                    ShowInfoPanel(5);
                    tutorialSO.currentTip = "Delete words or shake your rack to remove tiles.";
                    deleteButtonFlag = true;
                }

                break;

            case "age tiles":

                if (tileAgeFlag != true)
                {
                    ShowInfoPanel(6);
                    tutorialSO.currentTip = "Tiles age each turn. Try use them before they turn red and fall off";
                    tileAgeFlag = true;
                }

                break;

            case "valid words":

                if (validWordFlag != true)
                {
                    ShowInfoPanel(7);
                    tutorialSO.currentTip = "When the lightbulb comes on it means a word is valid";
                    validWordFlag = true;
                }

                break;

            case "initial instructions":

                if (initialInstructionsFlag != true)
                {
                    ShowInfoPanel(8);
                    tutorialSO.currentTip = "Tap letters to make words using 3 or more letters";
                    initialInstructionsFlag = true;
                }

                break;



        }
    }

    //moves panel into view

    private void ShowInfoPanel(int infoPanelImage)
    {
        iTween.MoveTo(tutorialPanel, iTween.Hash("y", 1000, "easetype", "easeInOut", "time", 0.5f));
        tutorialSO.tutorialTipImage = tutorialTipImages[infoPanelImage];

        //play audio
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxUserInterface[5]);

        }
    }

    public void CloseInfoPanel()
    {
        iTween.MoveTo(tutorialPanel, iTween.Hash("y", 1300, "easetype", "easeInOut", "time", 0.5f));
    }

   

}
