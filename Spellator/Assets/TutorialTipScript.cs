using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTipScript : MonoBehaviour
{
    public SpriteRenderer tipImage;
    public TextMeshProUGUI tipDescription;
    public TutorialSO tutorialSO;


    private void Update()
    {
        tipDescription.text = tutorialSO.currentTip;
        tipImage.sprite = tutorialSO.tutorialTipImage;
    }
}
