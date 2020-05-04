using System.Collections;
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
    public Image trophy;
    public Sprite[] allTrophies;

    public RangeInt level1 = new RangeInt(1,100);
    public RangeInt leve12 = new RangeInt(101, 200);

    public int currentMedal;


    public GameState gameDataObject;
    public string[] statuses;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnLoadInitiated();


        longestWord.text = configData.longestWord;

        //totalWordsMade.text = configData.totalWordsMade.ToString() + " words played";
        currentStatus.text = statuses[Random.Range(0, statuses.Length)];

        uniqueWords.text = configData.uniqueWordsList.Count.ToString();

        wordsPlayed.text = configData.totalWordsMade.ToString() + " words made";



        trophy.sprite = allTrophies[Random.Range(0,4)];
        Debug.Log("current trophy is " + trophy.sprite);


        //set the variable
        // gameDataObject = GameObject.Find("GameState").GetComponent<GameState>();



        /*
        //load the data
        gameDataObject.LoadGameData();

        longestWord.text = configData.longestWord;

        //totalWordsMade.text = configData.totalWordsMade.ToString() + " words played";
        currentStatus.text = statuses[Random.Range(0, statuses.Length)];

        uniqueWords.text = gameDataObject.playerWordsMade.Count.ToString();

        wordsPlayed.text = gameDataObject.wordsPlayed.ToString() + " words made";
        */

    }
}
