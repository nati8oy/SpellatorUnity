using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSlider : MonoBehaviour
{

    private Vector3 sliderPanelPosition;
    public GameObject sliderPanel;
    public GameObject backButton;
    public GameObject nextButton;
    public GameObject playButton;
    public TutorialSO tutorialSO;

    public int slideNumber;


    // Start is called before the first frame update
    void Start()
    {
        slideNumber = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (slideNumber == 1)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }

        if (slideNumber == 6)
        {
            nextButton.SetActive(false);
            playButton.SetActive(true);
        }
        else if (slideNumber < 6)
        {
            nextButton.SetActive(true);
            playButton.SetActive(false);
        }

       
    }


        public void Slide(string direction)
    {
      
        if (direction == "next")
        {
            iTween.MoveBy(sliderPanel, new Vector3(Screen.width * -1, 0, 0), 0.2f);
            slideNumber += 1;
        }
         else if(slideNumber>1)
        {
            iTween.MoveBy(sliderPanel, new Vector3(640, 0, 0), 0.2f);
            slideNumber -= 1;
        }

    }

    public void HideTutorial()
    {
        gameObject.SetActive(false);
        tutorialSO.tutorialOn = false;
    }
}
