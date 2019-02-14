using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{


    [SerializeField] private GameObject tile;
    private GameObject tileHolder;


    private GameObject tilePos;


    [SerializeField] private List<GameObject> rackPositions = new List<GameObject>();
    private GameObject newTile;

    [SerializeField] private Transform rack;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < rackPositions.Count; i++)
        {
            newTile = Instantiate(tile, rack.GetChild(i).transform);
            newTile.transform.parent = rackPositions[i].transform;
        }

    }





}
