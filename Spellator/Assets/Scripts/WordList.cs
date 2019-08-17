using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{

    private GameObject newWord;
    public List<string> wordsMade = new List<string>();


    private void Start()
    {
        //set the wordsMade list to be that of list stored in the DictionaryManager
        wordsMade = DictionaryManager.Instance.playerWordsMade;
        wordsMade.Sort();

        //get the text box and add the total word count to it
        //GetComponent<TextMeshProUGUI>().text = wordsMade.Count + " unique words";

        Debug.Log("wordsMade List is: "+ wordsMade.Count +" long");

        foreach (string wordInList in wordsMade)
        {
            //get the object from the pool that is tagged as "TextListItem"
            newWord = ObjectPooler.SharedInstance.GetPooledObject("TextListItem");
            if (newWord != null)
            {
                newWord.transform.position = gameObject.transform.position;
                newWord.transform.SetParent(gameObject.transform);
                //set the value of the text box in the prefab to be the word from the list
                newWord.GetComponent<TextMeshProUGUI>().text = wordInList;
                newWord.SetActive(true);

            }
        }


        
    }

}
