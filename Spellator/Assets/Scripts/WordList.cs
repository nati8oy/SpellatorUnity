using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{

    private GameObject newWord;
    public TextMeshProUGUI uniqueWords;

    public ConfigSO wordData;
    
    public List<string> wordsMade = new List<string>();
    public Dictionary<string, int> fullWordList = new Dictionary<string, int>();


    private void Start()
    {

        InitWordsMade();

    }

    private void OnEnable()
    {
        InitWordsMade();
       
        //when the wordlist menu gameobject is enabled check if the words that have been made are in there or not.
        for (int i = 0; i < wordsMade.Count; i++)
        {
            //if the words aren't already in this list then add them.
            //otherwise if they are then don't add them
            if (!fullWordList.ContainsKey(wordsMade[i]))
            {
                fullWordList.Add(wordsMade[i], 1);
                //get the object from the pool that is tagged as "TextListItem"
                newWord = ObjectPooler.SharedInstance.GetPooledObject("TextListItem");
                if (newWord != null)
                {
                    newWord.transform.position = gameObject.transform.position;
                    newWord.transform.SetParent(gameObject.transform);
                    //set the value of the text box in the prefab to be the word from the list
                    newWord.GetComponent<TextMeshProUGUI>().text = wordsMade[i];
                    newWord.SetActive(true);

                }
                Debug.Log("added the word " + wordsMade[i] + " full word list is now "+ fullWordList.Count + " long");
                

            } else if (fullWordList.ContainsKey(wordsMade[i]))
            {
                Debug.Log("didn't add the word " + wordsMade[i] + " full word list is now " + fullWordList.Count + " long");
            }
        }
      
    }

    //initialise the words that have been made on both enable and start
    private void InitWordsMade()
    {
        //set the wordsMade list to be that of list stored in the DictionaryManager
        wordsMade = DictionaryManager.Instance.playerWordsMade;

        //sort the list alphabetically
        wordsMade.Sort();

        uniqueWords.text = "You've made " + wordsMade.Count.ToString() + " unique words";
    }

}
