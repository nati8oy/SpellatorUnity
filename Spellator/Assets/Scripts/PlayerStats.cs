﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public ConfigSO configData;

    public TextMeshProUGUI totalWordsMade;
    public TextMeshProUGUI currentStatus;
    public TextMeshProUGUI longestWord;
    public TextMeshProUGUI uniqueWords;
    public TextMeshProUGUI wordsPlayed;


    public GameState gameDataObject;
    public string[] statuses;

    // Start is called before the first frame update
    void Start()
    {
        //set the variable
       // gameDataObject = GameObject.Find("GameState").GetComponent<GameState>();

        //load the data
        gameDataObject.LoadGameData();

        longestWord.text = configData.longestWord;

        //totalWordsMade.text = configData.totalWordsMade.ToString() + " words played";
        currentStatus.text = statuses[Random.Range(0, statuses.Length)];

        uniqueWords.text = gameDataObject.playerWordsMade.Count.ToString();

        wordsPlayed.text = gameDataObject.wordsPlayed.ToString() + " words made";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}