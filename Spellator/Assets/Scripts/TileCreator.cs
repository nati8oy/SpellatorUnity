using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private GameObject newTile;


    // Start is called before the first frame update
    void Start()
    {
        newTile = Instantiate(tile, gameObject.transform);
       // newTile.transform.parent = GameObject.Find("Dynamic Tile Holder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
