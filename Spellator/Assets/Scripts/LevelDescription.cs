using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDescription : MonoBehaviour
{
    public TextMeshProUGUI levelRules;
    public LevelManagerSO levelData;
    public TextMeshProUGUI levelNumber;

    // Update is called once per frame
    void Update()
    {
        levelRules.text = levelData.levelRules;
        levelNumber.text = levelData.currentLevel.ToString();

    }

    public void MoveOffScreen()
    {
        //iTween.ColorTo(gameObject, iTween.Hash("a", 0f, "time", 3f));

        iTween.MoveTo(gameObject, iTween.Hash("x", -650, "time", 3f, "easetype", "InOutQuad"));

    }
}
