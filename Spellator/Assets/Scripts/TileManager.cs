using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    //sets up an instance of the GameManager
    public static TileManager Instance;

    //private GameObject[] currentTileCount;
    //[SerializeField] private Canvas tileUI;
    //[SerializeField] private GameObject tile;
    //private GameObject tileHolder;


    [SerializeField] private Transform[] rackPositions;
    [SerializeField] public Transform[] playPositions;
    [SerializeField] private GameObject tile;

    private int nextFreeSlot = 9;


    private GameObject tileHolder;
    // private Vector3 pos;
    //private int numberOfTilesToAdd;


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
        for (int i = 0; i<rackPositions.Length; i++)
        {
            
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];
            nextFreeSlot = nextFreeSlot +i;
        }
      
    }



    void Update()

    {
       
    }



    public void MoveTiles()
    {

    }
    //Lerps the tile to their play ares positions



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
