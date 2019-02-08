using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{


    [SerializeField] private GameObject tile;
    private GameObject tileHolder;

    public GameObject holder1;


    [SerializeField] private List<GameObject> rackPositions = new List<GameObject>();
    private GameObject newTile;

    [SerializeField] private Transform rack; 

    // Start is called before the first frame update
    void Start()
    {

        for(int i =0; i< rackPositions.Count; i++)
        {
            newTile = Instantiate(tile, rack.GetChild(i).transform);
            newTile.transform.parent = rackPositions[i].transform;
            Debug.Log("adding new tile");
        }

        holder1 = rack.transform.Find("Pos 1").gameObject;






        //Debug.Log(holder1.transform.childCount);
        /*
        if (position1.transform.childCount == 1)
        {
            Debug.Log("there IS a tile in position 1");
        }
        else
        {
            Debug.Log("there's NO TILE in position 1");
        }*/

    }

    //Singleton code

    // Update is called once per frame
    void Update()
    {
    

    }

    public void CheckTiles()
    {


    }

}
