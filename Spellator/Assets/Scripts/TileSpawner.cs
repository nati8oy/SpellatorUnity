using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Tile;
    [SerializeField] private GameObject[] tilePositions;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<tilePositions.Length; i++)
        {
            Instantiate(Tile, new Vector3(tilePositions[i].transform.position.x, tilePositions[i].transform.position.y), Quaternion.identity);
        }


    }
}
