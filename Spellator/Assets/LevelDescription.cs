using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDescription : MonoBehaviour
{
    public TextMeshProUGUI levelRules;
    public LevelManagerSO levelData;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        levelRules.text = levelData.levelRules;

    }
}
