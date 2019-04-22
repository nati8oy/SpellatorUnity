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

    private GameObject[] moveTilesArray;

    private GameObject startTile;

    [SerializeField] private Transform activeWordPosition;

    public Transform ActiveWordPosition
    {
        get { return activeWordPosition; }
    }





    private Transform returnPos;
    private GameObject[] tilesToUntag;


    //this is the list to add the tile positions to
    private List<Transform> selectedTiles = new List<Transform>();

    public List<Transform> SelectedTiles

    {
        get { return selectedTiles; }
        set { SelectedTiles = value; }
    }

    [SerializeField] private bool[] rackSpacesAvailable;


    //number showing the next available slot on the game board
    private int nextFreeSlot;

    public int NextFreeSlot
    {
        get { return nextFreeSlot; }
        set { NextFreeSlot = value; }
    }


    //this indicates the next free position to spawn a tile to
    private Transform nextFreePos;

    public Transform NextFreePos
    {
        get { return nextFreePos; }
        set { NextFreePos = value; }
    }

    //this is the game object that other tiles are parented to
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

        //activeWordPosition.transform.position = transform.position;
    }



    void Start()
    {

        var firstLetterPositon = GameObject.Find("Pos 1");
       
    nextFreePos = playPositions[selectedTiles.Count];
        //Debug.Log("the NextFreePos starts as: " + nextFreePos);

    }

    public void PlayTiles()
    {
        //sets the next free position to the selectedTiles length
        nextFreePos = playPositions[selectedTiles.Count];


    }

    public void ReplenishTiles()
    {

        for (int i = 0; i < DictionaryManager.Instance.selectedTilesArray.Length; i++)
        {
            //create new tiles for the spots that have just been used
            tileHolder = Instantiate(tile, selectedTiles[i]);

            //for each of the transforms in the selectedTiles list add a new tile
            foreach (Transform parent in selectedTiles)
            {
                //set the tile parent to be that of the rackPositions transforms
                tileHolder.transform.parent = selectedTiles[i];

                //Debug.Log("Rack position being refilled: " + rackPositions[i]);
            }

        }



    }


    public void ResetWordStartPoint()
    {
        selectedTiles.Clear();
        nextFreePos = playPositions[selectedTiles.Count];
    }

    public void MoveTiles()
    {
        moveTilesArray = GameObject.FindGameObjectsWithTag("TileSelected");

        foreach (Transform child in transform)
        {
            tile.transform.position = new Vector3(tile.transform.position.x - 150, tile.transform.position.y);
            //Debug.Log("tile moved!");
        }
    }

    public void SetStartTile(string firstLetter)
    {

        startTile = Instantiate(tile, ActiveWordPosition.transform);
        var tileScript = startTile.GetComponent<Tile>();
        tileScript.letter.text = firstLetter;
        tileScript.firstLetterTile = true;
        Debug.Log("this is the first letter: " + tileScript.letter.text);
        tileScript.points.text = InitDictionary.Instance.pointsDictionary[tileScript.letter.text].ToString();

    }
}