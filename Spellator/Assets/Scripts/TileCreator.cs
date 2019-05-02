using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private GameObject newTile;
    public Transform startPos;

    private string currentStatus = "Available";



    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform;
        newTile = Instantiate(tile, gameObject.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTileStatus(string statusUpdate)
    {

      if(statusUpdate == "Available")
        {
            newTile = Instantiate(tile, gameObject.transform);
        }


    }
}
