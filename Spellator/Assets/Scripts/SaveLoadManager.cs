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

        //SaveLoad.Save<PlayerSaveLoadData>(saveLoadData, "Save Game");
        SaveLoad.Save<int>(skinSelection, "Skin Selection");

        Debug.Log("Game Saved!!");
    }

     void Load()
    {

        //skin selection
        if (SaveLoad.SaveExists("Skin Selection"))
        {


            skinSelection = SaveLoad.Load<int>("Skin Selection");
            //shop.currentSkin = skinSelection;
            //LoadSkin(SaveLoad.Load<int>("Skin Selection"));
            Debug.Log("loaded data!" + " skin selection is:" + skinSelection);
            
        }
        else
        {
            Debug.Log("No save found");
        }
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
