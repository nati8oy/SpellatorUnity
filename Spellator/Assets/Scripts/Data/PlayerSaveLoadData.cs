using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerSaveLoadData 
{

    public int gold;
    public int wordsPlayed;
    public string longestWord;
    public int skinSelection;
    public bool audioOn;

    public ShopSO shop;
    public ConfigSO configData;


    public PlayerSaveLoadData(int Gold, int WordsPlayed, string LongestWord, int SkinSelection, bool AudioOn)
    {
       this.gold = Gold;
       this.wordsPlayed = WordsPlayed;
       this.skinSelection = SkinSelection;
       this.audioOn = AudioOn;

    }
}
