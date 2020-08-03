using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public Toggle tutorialToggle;
    public TutorialSO tutorialSO;


    // Start is called before the first frame update
    void Start()
    {

        tutorialToggle.onValueChanged.AddListener(delegate {
            ToggleCheck();
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCheck()
    {
        if (tutorialToggle.isOn)
        {
            tutorialSO.tutorialOn = true;
            //Debug.Log(tutorialSO.tutorialOn);

            //add the action if the toggle is on
        }
        else
        {
            tutorialSO.tutorialOn = false;
           // Debug.Log(tutorialSO.tutorialOn);
        }

    }
}
