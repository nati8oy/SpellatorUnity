using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;


    public LevelClass levelSetup;
    public LevelManagerSO levelDetails;
    public TextMeshProUGUI levelDescriptionText;
    public string randomLevelSelction;

    //set up singleton
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
        //RANDOM VERSION
       // randomLevelSelction = levelDetails.levelType[Random.Range(0, levelDetails.levelType.Count)];


        //IMPORTANT: Level class constructor.
        levelSetup = new LevelClass();

        //SET VERSION
        //sets up the level parameters. eg. make 3 words that are 3 letters long.
        levelSetup.ConstructLevelParams("starting");


    }

    // Update is called once per frame
    void Update()
    {
        //this is the data from the level
        levelDescriptionText.text = LevelClass.levelDescription;

    }

    public void CheckLevels()
    {

    }
}
