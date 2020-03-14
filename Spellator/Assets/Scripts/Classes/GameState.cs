using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public int currentScore;

	//public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
	public List<string> playerWordsMade = new List<string>();
    public List<int> highScores = new List<int>();
    public bool audioToggle;
    public int premiumCurrency;
    public int wordsPlayed;
    public string longestWord;


    public ConfigSO configData;

    [HideInInspector]
    public GameState Instance;


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
    }


    public void SaveGameData()
    {
        //get the toggle bool from the Game Manager
       // audioToggle = GameManager.Instance.toggle;
        premiumCurrency = DictionaryManager.Instance.starsTotal;
       // Debug.Log("audio toggle being saved as " + GameManager.Instance.toggle);
        currentScore = Points.totalScore;

        //playerWordsMade = GameConfig.Instance.uniqueWordsList;

        //get the longest word out of the SO
        longestWord = DictionaryManager.Instance.longestWord;

        //this the list of uniqe words made
        playerWordsMade = DictionaryManager.Instance.playerWordsMade;

        //Debug.Log(playerWordsMade);

        // wordsPlayed = DictionaryManager.Instance.totalWordsPlayed;
        wordsPlayed = configData.totalWordsMade;


        //Debug.Log("words played " +  wordsPlayed);
        //wordsPlayed = playerWordsMade.Count;


        //save the high scores
        //        highScores = GameConfig.Instance.highScores;


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
            DictionaryManager.Instance.starsTotal = data.premiumCurrency;
            DictionaryManager.Instance.totalWordsPlayed = data.wordsPlayed;
            //Debug.Log("loaded data from Dictionary Manager");

        }
        else
        {
           // Debug.Log("Dictonary manager doesn't exist yet!");
        }

        currentScore = data.currentScore;
        playerWordsMade = data.playerWordsMade;
        premiumCurrency = data.premiumCurrency;
        wordsPlayed = data.wordsPlayed;
        longestWord = data.longestWord;



        //Debug.Log("total words made (" + wordsPlayed + ") configData words: (" + configData.totalWordsMade + ")");
       //Debug.Log("longest word is currently: " + longestWord);

        // GameConfig.Instance.uniqueWordsList = data.playerWordsMade;

        //load the high scores

        //        GameConfig.Instance.highScores = data.highScores;

        // sfxOn = data.sfxOn;
        // musicOn = data.musicOn;


        //Debug.Log("Loaded dictionary length is " + data.playerWordsMade.Count);
        //Debug.Log("Premium currenct total: " + data.premiumCurrency);

        //Debug.Log("Audio state: " + "sfx = " + sfxOn + " music = " + musicOn);


    }
}
