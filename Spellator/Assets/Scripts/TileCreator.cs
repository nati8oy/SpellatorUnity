using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private GameObject newTile;
    public Transform startPos;
    private TileSpawnerClass tileSpawner;

    private bool available = true;

    public bool Available
    {
        get { return available; }
        set { Available = value; }
    }

    private void Start()
    {
        newTile = GameManager.Instance.GetPooledObject();
        startPos = gameObject.transform;


        TileSpawnerClass tileSpawner = new TileSpawnerClass();
        tileSpawner.GetNewPooledObject(gameObject.transform.position, gameObject.transform);
        Debug.Log("the parent of this object is: " + tileSpawner.newTile.transform.parent);

      
        /*
        if (newTile != null)
        {
            newTile.transform.position = gameObject.transform.position;
            newTile.transform.parent = gameObject.transform.parent;
            newTile.SetActive(true);
            //available = false;
            
        }*/
     
    }


    public void RefillTiles()
    {
        //tileSpawner.GetNewPooledObject(gameObject.transform.position, gameObject.transform);
        Debug.Log("Refilled tiles");

        newTile = GameManager.Instance.GetPooledObject();

        if (newTile != null)
        {
            newTile.transform.position = gameObject.transform.position;
            newTile.transform.parent = gameObject.transform;
            Debug.Log("parent name for refilled tile is: " + newTile.transform.parent);
            newTile.SetActive(true);
            //available = false;

        }

    }
}
