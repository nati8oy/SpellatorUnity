using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBag : MonoBehaviour
{

    public List<string> allTiles = new List<string>();
    public TileBagSO tileScriptableObject;
    public int consonantCount;
    public int vowelCount;
    public int rareConsonants;
    public AnimationCurve mainAnimationCurve;

    // Start is called before the first frame update


    void Start()
    {
        consonantCount = 60;
        vowelCount = 40;
        rareConsonants = 10;


        //clear the bag before adding any tiles
       // TileBag.bag.Clear();

        /*


        for (int i = 0; i < consonantCount; i++)
        {
            TileBag.bag.Add(TileBag.consonantList[Random.Range(0, TileBag.consonantList.Count)]);
            Debug.Log("added " + i + " consonants");

        }

        for (int i = 0; i < vowelCount; i++)
        {
            TileBag.bag.Add(TileBag.vowelList[Random.Range(0, TileBag.vowelList.Count)]);
            Debug.Log("added" + i + " vowels");
            
        }

        for (int i = 0; i < rareConsonants; i++)
        {
            TileBag.bag.Add(TileBag.rareConsonantList[Random.Range(0, TileBag.rareConsonantList.Count)]);

        }
        */


//        Debug.Log("bag length = " + TileBag.bag.Count);



        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
