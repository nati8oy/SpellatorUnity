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


    //number showing the next available slot on the game board
    private int nextFreeSlot;

    public int NextFreeSlot
    {
        get { return nextFreeSlot; }
        set { NextFreeSlot = value; }
    }



    public Transform nextFreePos;
  


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

        /*
        for (int i = 0; i<rackPositions.Length; i++)
        { 
            tileHolder = Instantiate(tile, rackPositions[i]);
            tileHolder.transform.parent = rackPositions[i];
            rackSpacesAvailable[i] = false;
            //Debug.Log("Rackspace " + i + " is " + rackSpacesAvailable[i]);

        }*/


    }



    public void PlayTiles()
    {
        //keeps track of the next available board slot
        if (nextFreeSlot != 9) {
            nextFreeSlot += 1;
            nextFreePos = playPositions[nextFreeSlot];

            //Debug.Log("it's working!");
            //int remaining = 9 - nextFreeSlot;
           // Debug.Log("The number or remaining board slots is: " + remaining);
        }
      
    }



    public void ReplenishTiles()
    {

        for (int i = 0; i < GameManager.Instance.selectedTilesArray.Length; i++)
        {
            //create new tiles for the spots that have just beend used
            tileHolder = Instantiate(tile, selectedTiles[i]);

            //for each of the transforms in the selectedTiles list add a new tile
            foreach (Transform parent in selectedTiles)
            {
               //set the tile parent to be that of the rackPositions transforms
                tileHolder.transform.parent = selectedTiles[i];

                Debug.Log("Rack position being refilled: " + rackPositions[i]);
            }

        }
        //clear the selectedTiles list so that it puts the new tiles in the right positions
        selectedTiles.Clear();
        //Debug.Log(selectedTiles.ToString());

       
    }

    public void ClearWord()
    {
        //add all the tiles with the tag "Selected" to an array
        tilesToUntag = GameObject.FindGameObjectsWithTag("TileSelected");

        //loop through the array and delete each of the gameObjects in it


        for(int i = 0; i< selectedTiles.Count; i++)
        {

            foreach (Transform parent in selectedTiles)
            {
                //set the tile parent to be that of the rackPositions transforms
               parent.transform.position = rackPositions[i].position; 
               tile.tag = "Tile";

            }

        }
        /*

        foreach (GameObject tile in tilesToUntag)
        {
            tile.tag = "Tile";
           
        }
        */

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
