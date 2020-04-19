using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public int currentScore;

	//public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
	public List<string> playerWordsMade = new List<string>();
    public List<int> highScores = new List<int>();
    public ShopSO shop;

    public bool audioToggle;
    public int gold;
    public int wordsPlayed;
    public string longestWord;
    public int skinSelection;


    public ConfigSO configData;

    public static GameState Instance;


    private void Awake()
    {

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

    private void Start()
    {
        wordsPlayed = configData.totalWordsMade;
        skinSelection = shop.currentSkin;


    }


    public void SaveGameData()
    {
        //set the tile skin to whatever the current skin in the shop is
        skinSelection = shop.currentSkin;

        Debug.Log("saved skin selection: " + skinSelection);

        currentScore = Points.totalScore;

        // wordsPlayed = DictionaryManager.Instance.totalWordsPlayed;
        wordsPlayed = configData.totalWordsMade;

        //saves the total gold amount
        gold = configData.totalGoldAmount;


        if (DictionaryManager.Instance!=null)
        {
            //get the longest word out of the SO
            longestWord = DictionaryManager.Instance.longestWord;

            //this the list of uniqe words made
            playerWordsMade = DictionaryManager.Instance.playerWordsMade;
        }


        Debug.Log("<color=red> Score saved </color>" + "(" + currentScore + ")" + " Saved dictionary: " + "(" + playerWordsMade.Count + ")" + " Words Played: " + wordsPlayed);

        //save the data
        SaveSystem.SaveGameData(this);

        
    }


    public void LoadGameData()
    {
        PlayerData data = SaveSystem.LoadGameData();

       // audioToggle = data.audioToggle;

        //load the list of unique words

        //DictionaryManager.Instance.playerWordsMade = data.playerWordsMade;

        //check to see if the dictionary manager exists yet. If it's not null then load the vars associated with it.

        if (DictionaryManager.Instance!=null)
        {
            DictionaryManager.Instance.goldTotal = data.goldAmount;
            DictionaryManager.Instance.totalWordsPlayed = data.wordsPlayed;
            //Debug.Log("loaded data from Dictionary Manager");

        }
        else
        {
           // Debug.Log("Dictonary manager doesn't exist yet!");
        }

        currentScore = data.currentScore;
        playerWordsMade = data.playerWordsMade;
        gold = data.goldAmount;
        wordsPlayed = data.wordsPlayed;
        longestWord = data.longestWord;

        //check if the current skin is not equal to null first. Then assign it whatever was saved in the save file.
        if (shop.currentSkin != null)
        {
            skinSelection = data.skinSelection;
            Debug.Log("loaded skin selection: " + skinSelection);
        }

       

        

        //set the current skin in the shop to be the one that was saved
        //shop.currentSkin = skinSelection;


        //Debug.Log("total words made (" + wordsPlayed + ") configData words: (" + configData.totalWordsMade + ")");
        //Debug.Log("longest word is currently: " + longestWord);

        // GameConfig.Instance.uniqueWordsList = data.playerWordsMade;

        //load the high scores

        //        GameConfig.Instance.highScores = data.highScores;

        // sfxOn = data.sfxOn;
        // musicOn = data.musicOn;


        //Debug.Log("Loaded dictionary length is " + data.playerWordsMade.Count);
        //Debug.Log("Premium currenct total: " + data.gold);

        //Debug.Log("Audio state: " + "sfx = " + sfxOn + " music = " + musicOn);


    }
}
