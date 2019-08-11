using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{

    private GameObject newWord;
    public List<string> wordsMade;


    [SerializeField] private GameObject WordListItem;

    private void Start()
    {
        //
        wordsMade = new List<string>();

        for(int i = 0; i<30; i++)
        {
            wordsMade.Add("word" + i);
        }
       
        Debug.Log(wordsMade.Count);

        foreach (string wordInList in wordsMade)
        {
            newWord = ObjectPooler.SharedInstance.GetPooledObject("TextListItem");

            if (newWord != null)
            {
                newWord.transform.position = gameObject.transform.position;
                newWord.transform.SetParent(gameObject.transform);
                newWord.SetActive(true);

            }
        }


        
    }

}
