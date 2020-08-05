using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDescription : MonoBehaviour
{
    public TextMeshProUGUI levelRules;
    public LevelManagerSO levelData;
    public TextMeshProUGUI levelNumber;
    public Transitions fadeManager;

    // Update is called once per frame
    void Update()
    {
        levelRules.text = levelData.levelRules;
        levelNumber.text = levelData.currentLevel.ToString();

    }

    public void RemoveThis()
    {

        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();
        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);
        gameObject.SetActive(false);

        //iTween.ColorTo(gameObject, iTween.Hash("a", 0f, "time", 3f));

        //  iTween.MoveTo(gameObject, iTween.Hash("x", -650, "time", 3f, "easetype", "InOutQuad"));

    }
}
