using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    //sets up an instance of the GameManager
    public static TileManager Instance;

    //array of rack positions
    [SerializeField] private Transform[] rackPositions;
    //array of play positions
    [SerializeField] public Transform[] playPositions;
    //tile prefab
    [SerializeField] private GameObject tile;

    //mumber showing the int
    public int nextFreeSlot;
    public Transform nextFreePos;
    private int nextPlayPosition;

    public int  NextPlayPosition
    {
        get { return nextPlayPosition; }
        set { NextPlayPosition = value; }
    }


    private GameObject tileHolder;


    //Singleton code
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }



    void Start()
    {

        nextFreePos = playPositions[nextFreeSlot];



        //set up the rack positions
        for (int i = 0; i<rackPositions.Length; i++)
        { 
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];
            //nextFreeSlot = nextFreeSlot +i;
        }
      
    }


    public void PlayTiles()
    {

        nextFreeSlot += 1;
        nextFreePos = playPositions[nextFreeSlot];
      
    }




    public void ReplenishTiles()
    {
        for (int i = 0; i < GameManager.Instance.selectedTiles.Length; i++)
        {
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];
        }

    }

    //moves the tiles when played


}
