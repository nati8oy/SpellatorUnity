using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private GameObject tileHolder;

    [SerializeField] private Transform posInGrid;
    //[SerializeField] private GameObject[] tilePositions;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tile, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);

        tileHolder.transform.parent = posInGrid.transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (tile == null)
        {
            Instantiate(tile, new Vector3(0,0), Quaternion.identity);

        }

    }

}
