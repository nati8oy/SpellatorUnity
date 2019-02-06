using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    //sets up an instance of the GameManager
    public static TileManager Instance;

    private float smoothing = 5f;


    //array of rack positions
    [SerializeField] public Transform[] rackPositions;
    //array of play positions
    [SerializeField] public Transform[] playPositions;
    //tile prefab
    [SerializeField] private GameObject tile;

    private Transform returnPos;
    private GameObject[] tilesToUntag;


    /*
    public Transform ReturnPos
    {
        get { return returnPos; }
        set { ReturnPos = value; }
    }
    */

    //this is the list to add the tile positions to
    private List <Transform> selectedTiles = new List<Transform>();

    public List<Transform> SelectedTiles

    {
        get { return selectedTiles; }
        set { SelectedTiles = value; }
    }

    //private List<bool> rackSpacesAvailable = new List<bool>(); 
    [SerializeField] private bool[] rackSpacesAvailable;


    //number showing the int
    private int nextFreeSlot;

    public int NextFreeSlot
    {
        get { return nextFreeSlot; }
        set { NextFreeSlot = value; }
    }



    public Transform nextFreePos;
    private int nextPlayPosition;

    public int  NextPlayPosition
    {
        get { return nextPlayPosition; }
        set { NextPlayPosition = value; }
    }


    private GameObject tileHolder;


    //Singleton code
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }



    void Start()
    {

        nextFreePos = playPositions[nextFreeSlot];
               
        //set up the rack positions
        for (int i = 0; i<rackPositions.Length; i++)
        { 
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];
            rackSpacesAvailable[i] = false;
            //Debug.Log("Rackspace " + i + " is " + rackSpacesAvailable[i]);

        }


    }



    public void PlayTiles()
    {
        if (nextFreeSlot < 9) {
            nextFreeSlot += 1;
            nextFreePos = playPositions[nextFreeSlot];
        }
      
    }



    public void ReplenishTiles()
    {
        for (int i = 0; i < GameManager.Instance.selectedTiles.Length; i++)
        {
            tileHolder = Instantiate(tile, rackPositions[i]);


            tileHolder.transform.parent = rackPositions[i];

        }

    }

    public void ClearWord()
    {
        //add all the tiles with the tag "Selected" to an array
        tilesToUntag = GameObject.FindGameObjectsWithTag("TileSelected");


        //loop through the array and delete each of the gameObjects in it
        foreach (GameObject tile in tilesToUntag)
        {
            tile.tag = "Tile";
        }

       GameManager.Instance.WordBeingMade = "";
       //clear the list of transforms for the tile positions
       selectedTiles.Clear();

    }




    public IEnumerator ReturnTiles(Transform returnPos)
    {

        //foreach(Transform returnPos in selectedTiles)
        //{
            while (Vector3.Distance(transform.position, returnPos.position) > 0.05f)
            {
                transform.position = Vector3.Lerp(transform.position, returnPos.position, smoothing * Time.deltaTime);

                yield return null;
            }

        //}

        selectedTiles.Clear();

    }



}
