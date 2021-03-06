﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    //[SerializeField] private Text Score;
    //[SerializeField] private Text WordsMade;
    public ConfigSO configData;
    //public GameObject gameState;
    public TextMeshProUGUI tipText;
    public TutorialSO tipData;

    // Start is called before the first frame update
    void Start()
    {
        //Score.text = Points.totalScore.ToString();
        //WordsMade.text = DictionaryManager.Instance.TotalWordsMade.ToString();
       

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnEnable()
    {
        //save the game when the game over panel shows
        //gameState.GetComponent<GameState>().SaveGameData();
        GameEvents.OnSaveInitiated();
        tipText.text =  tipData.endOfLevelTips[Random.Range(0, tipData.endOfLevelTips.Length)];

    }
}
