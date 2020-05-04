using System.Collections;
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

        gold = configData.totalGoldAmount;
        wordsPlayed = configData.totalWordsMade;
        longestWord = configData.longestWord;
        skinSelection = shop.currentSkin;
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

        gold = configData.totalGoldAmount;
        wordsPlayed = configData.totalWordsMade;
        longestWord = configData.longestWord;
        skinSelection = shop.currentSkin;

        //SaveLoad.Save<PlayerSaveLoadData>(saveLoadData, "Save Game");
        SaveLoad.Save<int>(gold, "Total Gold");
        SaveLoad.Save<int>(wordsPlayed, "Words Played");
        SaveLoad.Save<string>(longestWord, "Longest Word Made");
        SaveLoad.Save<int>(skinSelection, "Skin Selection");

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
        if (SaveLoad.SaveExists("Skin Selection"))
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



        /*
                else
                {
                    Debug.Log("No save found");
                }
                */


    }

    /*

    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        Load();
    }

    void Save()
    {
        SaveLoad.Save(CollectedItems, "CollectedItems");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("CollectedItems"))
        {
            CollectedItems = SaveLoad.Load<HashSet<string>>("CollectedItems");
        }
    }

    */
}
