using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

    private GameObject[] tiles;
    private TileSkinSO currentSkin;
    // public GameObject woodPanel;
    //private string currentSkin;
    public ParticleSystem particleTrigger;
    public GameObject explosion;
    public ConfigSO configData;


    private void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        //    Debug.Log("tiles length: " + tiles.Length);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.StartCoroutine(GameManager.Instance.LevelComplete());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           // explosion.SetActive(true);
        }

        //add gold
        if (Input.GetKeyDown(KeyCode.W))
        {
            configData.totalGoldAmount += 10;
            Debug.Log("10 gold added");
        }

        //animation test
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.LevelComplete();
        }

    }
}
