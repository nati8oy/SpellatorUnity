using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public LevelClass levelSetup;
    public LevelManagerSO levelDetails;
    public string _levelDescription;
    public TextMeshProUGUI levelDescriptionText;


    // Start is called before the first frame update
    void Start()
    {
        //IMPORTANT: Level class constructor.
        levelSetup = new LevelClass();

        //sets up the level parameters. eg. make 3 words that are 3 letters long.
        levelSetup.ConstructLevelParams("length");


    }

    // Update is called once per frame
    void Update()
    {
        levelDescriptionText.text = LevelClass.levelDescription;

    }

    public void CheckLevels()
    {

    }
}
