﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;
    public PlayerSaveLoadData saveLoadData;
    
    [Header("Save Items")]

    public int gold;
    public int wordsPlayed;
    public string longestWord;
    public int skinSelection { get; private set; }
    public List<string> uniqueWordsList = new List<string>();
    public int uniqueWordAmount;
    public string currentPlayerRank;

    public bool audioOn;
    

    [Header("Scriptable Objects")]

    public ShopSO shop;
    public ConfigSO configData;


    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        Load();

        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }


    void Start()
    {
        //set all vars to be the ones from the scriptable object
        gold = configData.totalGoldAmount;
        wordsPlayed = configData.totalWordsMade;
        longestWord = configData.longestWord;
        skinSelection = shop.currentSkin;
        uniqueWordsList = configData.uniqueWordsList;
        uniqueWordAmount = uniqueWordsList.Count;
        currentPlayerRank = configData.currentRank;



        Debug.Log("shop skin selection " + shop.currentSkin);


        //create a new saveLoadData object
        //saveLoadData = new PlayerSaveLoadData(configData.totalGoldAmount, configData.totalWordsMade, configData.longestWord, shop.currentSkin, true);
    }


    public void LoadSkin(int skin)
    {
        skinSelection = skin;
        Debug.Log("skin selection is" + skinSelection);
    }



    public void Save()
    {/*
     
        */
        //create a saveLoadData object and update its properties
        // saveLoadData = new PlayerSaveLoadData(gold,wordsPlayed,longestWord,skinSelection, true);


        //set all the vars to their current state from the scriptable object
        gold = configData.totalGoldAmount;
        wordsPlayed = configData.totalWordsMade;
        longestWord = configData.longestWord;
        skinSelection = shop.currentSkin;
        uniqueWordsList = configData.uniqueWordsList;
        uniqueWordAmount = uniqueWordsList.Count;
        currentPlayerRank = configData.currentRank;


        //SaveLoad.Save<PlayerSaveLoadData>(saveLoadData, "Save Game");
        SaveLoad.Save<int>(gold, "Total Gold");
        SaveLoad.Save<int>(wordsPlayed, "Words Played");
        SaveLoad.Save<string>(longestWord, "Longest Word Made");
        SaveLoad.Save<int>(skinSelection, "Skin Selection");
        SaveLoad.Save<List<string>>(uniqueWordsList, "Unique words made");
        SaveLoad.Save<int>(uniqueWordAmount, "Unique words made (int)");
        SaveLoad.Save<string>(currentPlayerRank, "Player Rank");



        Debug.Log("Game Saved!!");
    }

    void Load()
    {

        //skin selection
        if (SaveLoad.SaveExists("Total Gold"))
        {
            gold = SaveLoad.Load<int>("Total Gold");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.totalGoldAmount = gold;
        }

        //load words played
        if (SaveLoad.SaveExists("Words Played"))
        {
            wordsPlayed = SaveLoad.Load<int>("Words Played");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.totalWordsMade = wordsPlayed;
        }

        //load Longest Word
        if (SaveLoad.SaveExists("Longest Word Made"))
        {
            longestWord = SaveLoad.Load<string>("Longest Word Made");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.longestWord = longestWord;
        }

        //skin selection
        if (SaveLoad.SaveExists("Skin Selection"))
        {
            skinSelection = SaveLoad.Load<int>("Skin Selection");
            //set the skin selection in the shopSO back to the skinSelection var
            shop.currentSkin = skinSelection;
        }

        //the list of unique words made
        if (SaveLoad.SaveExists("Unique words made"))
        {
            uniqueWordsList = SaveLoad.Load<List<string>>("Unique words made");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.uniqueWordsList = uniqueWordsList;
        }

        //the number of unique words made
        if (SaveLoad.SaveExists("Unique words made (int)"))
        {
            uniqueWordAmount = SaveLoad.Load<int>("Unique words made (int)");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.uniqueWords =  uniqueWordsList.Count;
        }

        //the number of unique words made
        if (SaveLoad.SaveExists("Player Rank"))
        {
            currentPlayerRank = SaveLoad.Load<string>("Player Rank");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.currentRank = currentPlayerRank;
        }
    }
}