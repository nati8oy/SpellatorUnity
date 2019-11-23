using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public LevelClass levelSetup;
    // Start is called before the first frame update
    void Start()
    {
        //IMPORTANT: Level class constructor.
        levelSetup = new LevelClass();
        levelSetup.ConstructLevelParams("length");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
