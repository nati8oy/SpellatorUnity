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

        uniqueWordsList = configScriptableObject.uniqueWordsList;


        //all of this data is being read out of the scriptable object
        musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
            longestWord = configScriptableObject.longestWord;
            favouriteWordLength = configScriptableObject.favouriteWordLength;

        configScriptableObject.FindLongestWord();


        
        //set the level from the SO
        if(levelData.currentLevel==0)

        {
            levelData.currentLevel = 1;

        }


    }


        void Update()
        {
            musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
            uniqueWordsList = configScriptableObject.uniqueWordsList;
    }


}
