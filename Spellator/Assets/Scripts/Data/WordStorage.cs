using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordStorage : MonoBehaviour
{
    public ConfigSO wordListStorage;
    public List<string> currentWordList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        currentWordList = wordListStorage.uniqueWordsList;
        Debug.Log("The SO word list is" + currentWordList.Count + " long");
    }

    // Update is called once per frame
    void Update()
    {
//        currentWordList = wordListStorage.uniqueWordsList;

    }
}
