using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    //this script is used to access data from the scriptable object which holds all of the updated information.

    public static GameConfig Instance;
    public ConfigSO configScriptableObject;

    public  bool musicOn;
    public  bool sfxOn;
    public  List<string> uniqueWordsList;
    public  string longestWord;
    public  string favouriteWordLength;


    private void Awake()
    {

        void Awake()
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

        // Start is called before the first frame update
        void Start()
        {

            //all of this data is being read out of the scriptable object
            musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
            uniqueWordsList = configScriptableObject.uniqueWordsList;
            longestWord = configScriptableObject.longestWord;
            favouriteWordLength = configScriptableObject.favouriteWordLength;

        }

        // Update is called once per frame
        void Update()
        {
            musicOn = configScriptableObject.musicOn;
            sfxOn = configScriptableObject.sfxOn;
        }
    }

}
