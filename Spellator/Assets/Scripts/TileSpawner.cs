using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] GameObject Tile;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Tile = null)
        {
            Instantiate(Tile, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}
