using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnerClass
{

    public GameObject newTile;
    public bool available;

    public TileSpawnerClass()
    {
        newTile = ObjectPooler.SharedInstance.GetPooledObject("Tile");
        available = true;
    }


    public void GetNewPooledObject(Vector3 _position, Transform _parent)
    {

        if (available)
        {

            if (newTile != null)
            {
                newTile.transform.position = _position;
                newTile.transform.parent = _parent;
                newTile.SetActive(true);
                available = false;
            }
        }


    }


}
