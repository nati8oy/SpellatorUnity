using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        GameEvents.OnSaveInitiated();
    }

    public void Load()
    {
        if (SaveLoad.SaveExists("Test"))
        {
            Debug.Log("loaded data!");
            SaveLoad.Load<int>("Test");
        }
        else
        {
            Debug.Log("No data to load!");
        }
    }
}
