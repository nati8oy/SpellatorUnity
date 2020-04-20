using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    //this script is used to access data from the scriptable object which holds all of the updated information.

    public static GameConfig Instance;
    public ConfigSO configScriptableObject;
    public LevelManagerSO levelData;

    public  bool musicOn;
    public  bool sfxOn;
    public  List<string> uniqueWordsList;
    public string currentTileSkin;

    public List<int> highScores = new List<int>();

    public string longestWord;
    public  string favouriteWordLength;

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

    void Start()
        {

        //load the game save data
        GameObject.Find("GameState").GetComponent<GameState>().LoadGameData();


        uniqueWordsList = configScriptableObject.uniqueWordsList;
//        GetComponent<GameState>().LoadGameData();


        //all of this data is being read out of the scriptable object
        musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
            longestWord = configScriptableObject.longestWord;
            favouriteWordLength = configScriptableObject.favouriteWordLength;
            //highScores = configScriptableObject.topTenHighScores;

        configScriptableObject.FindLongestWord();
        //Debug.Log("game config says unique words list is " + uniqueWordsList.Count + " long");

        }


    //set the level to 0 for each of the  
   

        // Update is called once per frame
        void Update()
        {
            musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
            uniqueWordsList = configScriptableObject.uniqueWordsList;

//        var test = DictionaryManager.Instance.totalWordsPlayed;

     //   Debug.Log("test var is: " + test);


    }

    public void ResetLevels()
    {
        levelData.currentLevel = 0;
        Debug.Log("levels reset to " + levelData.currentLevel);
    }


}
