using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

    private GameObject[] tiles;
    private TileSkinSO currentSkin;
    //private string currentSkin;

    private void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    //    Debug.Log("tiles length: " + tiles.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.LevelComplete();
        }

        
 
    }
}
