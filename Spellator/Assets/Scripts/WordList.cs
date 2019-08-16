using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordList : MonoBehaviour
{

    private GameObject newWord;
    public List<string> wordsMade = new List<string>();
    [SerializeField] private TextMeshProUGUI textArea;


    [SerializeField] private GameObject WordListItem;


    private void OnEnable()
    {
        
    }

    private void Start()
    {

        wordsMade = DictionaryManager.Instance.playerWordsMade;

        /*
            for (int i = 0; i< wordsMade.Count; i++)
        {
            textArea.text += ("\n" + wordsMade[i]);

        }
        */
        Debug.Log("wordsMade List is: "+ wordsMade.Count +" long");

        //textArea.text = wordsMade.ToString();

        //get the dictionary list of words and split them on every comma
       // dictionaryList = new List<string>(fullDictionary.Split(','));


        

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
