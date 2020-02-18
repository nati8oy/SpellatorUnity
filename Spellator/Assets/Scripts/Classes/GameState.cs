using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{

    public int currentScore;

	//public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
	public List<string> playerWordsMade = new List<string>();
    public List<int> highScores = new List<int>();
    public bool audioToggle;
    public int premiumCurrency;
    public Image mainBG;


    public void SaveGameData()
    {
        //get the toggle bool from the Game Manager
       // audioToggle = GameManager.Instance.toggle;
        premiumCurrency = DictionaryManager.Instance.starsTotal;
       // Debug.Log("audio toggle being saved as " + GameManager.Instance.toggle);
        currentScore = Points.totalScore;


        //musicOn = wordData.musicOn;
        //sfxOn = wordData.sfxOn;

        //        musicOn = GameConfig.Instance.musicOn;
        //      sfxOn = GameConfig.Instance.sfxOn;

        //playerWordsMade = GameConfig.Instance.uniqueWordsList;
        playerWordsMade = DictionaryManager.Instance.playerWordsMade;

        //save the high scores
//        highScores = GameConfig.Instance.highScores;

        

		//save the data
		SaveSystem.SaveGameData(this);


        Debug.Log("Score saved " + "(" + currentScore + ")" + " Saved dictionary length is: " + playerWordsMade.Count);
    }


    public void LoadGameData()
    {
        PlayerData data = SaveSystem.LoadGameData();

       // audioToggle = data.audioToggle;

        currentScore = data.currentScore;
		playerWordsMade = data.playerWordsMade;
        premiumCurrency = data.premiumCurrency;

        //load the list of unique words

        //DictionaryManager.Instance.playerWordsMade = data.playerWordsMade;
        DictionaryManager.Instance.starsTotal = data.premiumCurrency;
        GameConfig.Instance.uniqueWordsList = data.playerWordsMade;

        //load the high scores

        //        GameConfig.Instance.highScores = data.highScores;

        // sfxOn = data.sfxOn;
        // musicOn = data.musicOn;


        //Debug.Log("Loaded dictionary length is " + data.playerWordsMade.Count);
        //Debug.Log("Premium currenct total: " + data.premiumCurrency);

        //Debug.Log("Audio state: " + "sfx = " + sfxOn + " music = " + musicOn);


    }
}
