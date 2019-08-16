using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public int currentScore;
	//public Dictionary<string, int> playerWordsMade = new Dictionary<string, int>();
	public List<string> playerWordsMade = new List<string>();


	public void SaveGameData()
    {
        currentScore = Points.totalScore;
		playerWordsMade = DictionaryManager.Instance.playerWordsMade;


		//save the data
		SaveSystem.SaveGameData(this);

        Debug.Log("Score saved " + "(" + currentScore + ")" + " Saved dictionary length is: " + playerWordsMade.Count);
    }


    public void LoadGameData()
    {
        PlayerData data = SaveSystem.LoadGameData();

        currentScore = data.currentScore;
		playerWordsMade = data.playerWordsMade;
		DictionaryManager.Instance.playerWordsMade = data.playerWordsMade;


        Debug.Log("score loaded: " + currentScore + " Loaded dictionary length is " + playerWordsMade.Count);

    }
}
