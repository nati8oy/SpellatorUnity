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
    public List<string> uniqueWordsList = new List<string>();
    public int uniqueWordAmount;
    public string currentPlayerRank;
    public List<int> skinsPurchased = new List<int>();
    public int currentXPTotal;
    public List<int> wordsByLength;
    public int currentLevel;


    public bool audioOn;
    

    [Header("Scriptable Objects")]

    public ShopSO shop;
    public ConfigSO configData;
    public LevelManagerSO levelData;


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
       // ClearAllData();

        //set all vars to be the ones from the scriptable object
        gold = configData.totalGoldAmount;
        wordsPlayed = configData.totalWordsMade;
        longestWord = configData.longestWord;
        skinSelection = shop.currentSkin;
        uniqueWordsList = configData.uniqueWordsList;
        uniqueWordAmount = uniqueWordsList.Count;
        currentPlayerRank = configData.currentRank;
        skinsPurchased = configData.skinsPurchased;
        currentXPTotal = configData.levelProgressXP;
        wordsByLength = configData.listOfWordLengths;
        currentLevel = levelData.currentLevel;



//        Debug.Log("shop skin selection " + shop.currentSkin);


        //create a new saveLoadData object
        //saveLoadData = new PlayerSaveLoadData(configData.totalGoldAmount, configData.totalWordsMade, configData.longestWord, shop.currentSkin, true);
    }


    public void LoadSkin(int skin)
    {
        skinSelection = skin;
      //  Debug.Log("skin selection is" + skinSelection);
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
        skinsPurchased = configData.skinsPurchased;
        currentXPTotal = configData.levelProgressXP;
        wordsByLength = configData.listOfWordLengths;
        currentLevel = levelData.currentLevel;




        //SaveLoad.Save<PlayerSaveLoadData>(saveLoadData, "Save Game");

        //saves the data to the correct type and names the save game
        SaveLoad.Save<int>(gold, "Total Gold");
        SaveLoad.Save<int>(wordsPlayed, "Words Played");
        SaveLoad.Save<string>(longestWord, "Longest Word Made");
        SaveLoad.Save<int>(skinSelection, "Skin Selection");
        SaveLoad.Save<List<string>>(uniqueWordsList, "Unique words made");
        SaveLoad.Save<int>(uniqueWordAmount, "Unique words made (int)");
        SaveLoad.Save<string>(currentPlayerRank, "Player Rank");
        SaveLoad.Save<List<int>>(skinsPurchased, "Skins Purchased");
        SaveLoad.Save<int>(currentXPTotal, "Current XP Level");
        SaveLoad.Save<List<int>>(wordsByLength, "Number of words by length");
        SaveLoad.Save<int>(currentLevel, "Current level");





        //        Debug.Log("Game Saved!!");
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

        //the number of unique words made
        if (SaveLoad.SaveExists("Skins Purchased"))
        {
            skinsPurchased = SaveLoad.Load<List<int>>("Skins Purchased");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.skinsPurchased = skinsPurchased;
        }

        //the number of unique words made
        if (SaveLoad.SaveExists("Current XP Level"))
        {
            currentXPTotal = SaveLoad.Load<int>("Current XP Level");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.levelProgressXP = currentXPTotal;
        }

        //the number of unique words made
        if (SaveLoad.SaveExists("Number of words by length"))
        {
            wordsByLength = SaveLoad.Load<List<int>>("Number of words by length");
            //set the skin selection in the shopSO back to the skinSelection var
            configData.listOfWordLengths = wordsByLength;
        }



        //skin selection
        if (SaveLoad.SaveExists("Current level"))
        {
            currentLevel = SaveLoad.Load<int>("Current level");
            //set the skin selection in the shopSO back to the skinSelection var
            levelData.currentLevel = currentLevel;
        }

    }

    public void ClearAllData()
    {
        configData.levelProgressXP = 0;
        configData.levelProgressXP = 0;
        configData.skinsPurchased.Clear();
        uniqueWordsList.Clear();
        configData.uniqueWordsList.Clear();
        shop.currentSkin = 0;
        configData.longestWord = null;
        configData.totalWordsMade = 0;
        configData.totalGoldAmount = 0;
        levelData.currentLevel = 1;
    }
}
