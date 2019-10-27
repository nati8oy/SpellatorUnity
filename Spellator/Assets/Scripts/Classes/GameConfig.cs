using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{

    public static GameConfig Instance;

    public ConfigSO configScriptableObject;

    public bool musicOn;
    public bool sfxOn;
    public List<string> uniqueWordsList;
    public string longestWord;
    public string favouriteWordLength;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
