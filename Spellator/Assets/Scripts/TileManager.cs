using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{

    //private GameObject[] currentTileCount;
    //[SerializeField] private Canvas tileUI;
    //[SerializeField] private GameObject tile;
    //private GameObject tileHolder;

    [SerializeField] private Transform[] rackPositions;
    [SerializeField] private Transform[] playPositions;
    [SerializeField] private GameObject tile;

    private GameObject tileHolder;
   // private Vector3 pos;
    //private int numberOfTilesToAdd;



   

    void Start()
    {

        for (int i = 0; i<rackPositions.Length; i++)
        {
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];

           // tileHolder.transform.parent = tileUI.transform;

        }
        /*
        foreach(Transform in rackPositions)
        {
            tileHolder = Instantiate(Tile,)
        }*/


        /*
        currentTileCount = GameObject.FindGameObjectsWithTag("Tile");
        Debug.Log(currentTileCount.Length);*/
    }



    void Update()

    {
        /*
      currentTileCount = GameObject.FindGameObjectsWithTag("Tile");

        for (int i = 0;  i < currentTileCount.Length; i++)
        {
            tileHolder = Instantiate(tile, pos, Quaternion.identity);
            tileHolder.transform.parent = tileUI.transform;
        }*/
    }



    IEnumerator CheckForTiles()
    {
       


        yield return null;
        yield return new WaitForSeconds(2f);

    }

    /*
    IEnumerator CheckForTiles()
    {

        Debug.Log("Number of tiles to add: " + currentTileCount.Length);

        numberOfTilesToAdd = (9 - currentTileCount.Length);
        Debug.Log("Number of tiles to add: " + numberOfTilesToAdd);

        if (currentTileCount.Length < 9)
        {

            foreach (GameObject tile in currentTileCount)
            {

                Instantiate(tile, pos, Quaternion.identity);
                tile.transform.parent = tileUI.transform;
                Debug.Log("New Tile");
            }

            yield return null;
        }


        yield return new WaitForSeconds(1f);


        StartCoroutine(CheckForTiles());

    }*/
}
