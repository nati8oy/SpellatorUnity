using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public ConfigSO configData;

    //public TextMeshProUGUI totalWordsMade;
    public TextMeshProUGUI currentStatus;
    public TextMeshProUGUI longestWord;
    public TextMeshProUGUI uniqueWords;
    public TextMeshProUGUI wordsPlayed;
    public Image trophy;
    public Sprite[] allTrophies;
    public TextMeshProUGUI percentageTextA;
    public TextMeshProUGUI percentageTextB;
    public TextMeshProUGUI percentageTextC;
    public TextMeshProUGUI percentageTextD;
    public TextMeshProUGUI percentageTextE;
    public TextMeshProUGUI percentageTextF;
    private int threeLetterWords;
    private int fourLetterWords;
    private int fiveLetterWords;
    private int sixLetterWords;
    private int sevenLetterWords;
    private int eightLettersOrMore;




    public RangeInt level1 = new RangeInt(1,100);
    public RangeInt leve12 = new RangeInt(101, 200);

    public int currentMedal;


    public string[] statuses;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnLoadInitiated();



        foreach(string word in configData.uniqueWordsList)
        {
            switch (word.Length){
                case 3:
                    threeLetterWords += 1;
                    break;
                case 4:
                    fourLetterWords += 1;
                    break;
                case 5:
                    fiveLetterWords += 1;
                    break;
                case 6:
                    sixLetterWords += 1;
                    break;
                case 7:
                    sevenLetterWords += 1;
                    break;
                case 8:
                    eightLettersOrMore += 1;
                    break;
                case 9:
                    eightLettersOrMore += 1;
                    break;
                case 10:
                    eightLettersOrMore += 1;
                    break;
                case 11:
                    eightLettersOrMore += 1;
                    break;
            }
        }

        percentageTextA.text = threeLetterWords.ToString();
        percentageTextB.text = fourLetterWords.ToString();
        percentageTextC.text = fiveLetterWords.ToString();
        percentageTextD.text = sixLetterWords.ToString();
        percentageTextE.text = sevenLetterWords.ToString();
        percentageTextF.text = eightLettersOrMore.ToString();


        longestWord.text = configData.longestWord;

        //totalWordsMade.text = configData.totalWordsMade.ToString() + " words played";
        //currentStatus.text = statuses[Random.Range(0, statuses.Length)];

        uniqueWords.text = configData.uniqueWordsList.Count.ToString();

        wordsPlayed.text = configData.totalWordsMade.ToString() + " words made";

        Debug.Log("total words made: " + configData.totalWordsMade);

        if(configData.totalWordsMade > 55 && configData.totalWordsMade < 61)
        {
            configData.currentRank = statuses[0];
            currentStatus.text = configData.currentRank;
            trophy.sprite = allTrophies[0];

        }  else if(configData.totalWordsMade > 61 && configData.totalWordsMade < 63)
        {
            configData.currentRank = statuses[1];
            currentStatus.text = configData.currentRank;
            trophy.sprite = allTrophies[1];
        }
        else if (configData.totalWordsMade > 63 && configData.totalWordsMade < 66)
        {
            configData.currentRank = statuses[2];
            currentStatus.text = configData.currentRank;
            trophy.sprite = allTrophies[2];
        }
        else if (configData.totalWordsMade > 66 && configData.totalWordsMade < 68)
        {
            configData.currentRank = statuses[3];
            currentStatus.text = configData.currentRank;
            trophy.sprite = allTrophies[3];
        }
        else
        {
            configData.currentRank = statuses[3];
            currentStatus.text = configData.currentRank;
            trophy.sprite = allTrophies[3];
        }

        Debug.Log("current trophy is " + trophy.sprite);

    }
}
