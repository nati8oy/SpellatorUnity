using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{


    [SerializeField] private GameObject tile;
    private GameObject tileHolder;

    public static TileSpawner Instance;


    private GameObject tilePos;


    [SerializeField] private List<GameObject> rackPositions = new List<GameObject>();
    private GameObject newTile;

    [SerializeField] private Transform rack;

    //this is the singleton code to ensure there's not more than one instance running
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



       // TileSetup();


    }


    public void TileSetup()
    {

        for (int i = 0; i < rackPositions.Count; i++)
        {
            newTile = Instantiate(tile, rack.GetChild(i).transform);
            newTile.transform.parent = rackPositions[i].transform;
            var TileScript = newTile.GetComponent<Tile>();

            //Debug.Log(TileScript.startPosition); 

        }

    }


}
