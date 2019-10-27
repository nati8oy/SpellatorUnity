using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Word Data", menuName = "Word List")]
public class ConfigSO : ScriptableObject
{
    public List<string> uniqueWordsList;
    public bool sfxOn;
    public bool musicOn;

    public  string longestWord;
    public  string favouriteWordLength;

    private List<int> wordLengths = new List<int>();

        
    public void FavouriteWordLength()
    {
        foreach(string word in uniqueWordsList)
        {
            wordLengths.Add(word.Length);
        }
    }

    public void FindLongestWord()
    {
        //Debug.Log(uniqueWordsList[1]);

        
        foreach (string word in uniqueWordsList)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
                Debug.Log(longestWord);
            }
        }
    }

}
