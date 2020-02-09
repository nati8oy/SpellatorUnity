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

        //play particles
        if (Input.GetKeyDown(KeyCode.W))
        {
            particleTrigger.Play();
        }

    }
}
