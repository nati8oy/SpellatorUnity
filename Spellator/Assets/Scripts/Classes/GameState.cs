using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public int currentScore;
	//public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
	public List<string> playerWordsMade = new List<string>();
    public List<int> highScores = new List<int>();
    public bool musicOn;
    public bool sfxOn;


    public void SaveGameData()
    {
        currentScore = Points.totalScore;

        //musicOn = wordData.musicOn;
        //sfxOn = wordData.sfxOn;

//        musicOn = GameConfig.Instance.musicOn;
  //      sfxOn = GameConfig.Instance.sfxOn;

        playerWordsMade = GameConfig.Instance.uniqueWordsList;
		//playerWordsMade = DictionaryManager.Instance.playerWordsMade;

        //save the high scores
        highScores = GameConfig.Instance.highScores;

        

		//save the data
		SaveSystem.SaveGameData(this);


        Debug.Log("Score saved " + "(" + currentScore + ")" + " Saved dictionary length is: " + playerWordsMade.Count);
    }


    public void LoadGameData()
    {
        PlayerData data = SaveSystem.LoadGameData();

        currentScore = data.currentScore;
		playerWordsMade = data.playerWordsMade;

        //load the list of unique words

		GameConfig.Instance.uniqueWordsList = data.playerWordsMade;

        //load the high scores

        GameConfig.Instance.highScores = data.highScores;

        // sfxOn = data.sfxOn;
        // musicOn = data.musicOn;

        
        Debug.Log("Loaded dictionary length is " + playerWordsMade.Count);

        //Debug.Log("Audio state: " + "sfx = " + sfxOn + " music = " + musicOn);


    }
}
