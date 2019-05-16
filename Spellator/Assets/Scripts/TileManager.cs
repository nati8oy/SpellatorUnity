using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    //sets up an instance of the GameManager
    public static TileManager Instance;

    //array of rack positions
    [SerializeField] public Transform[] rackPositions;
    //array of play positions
    [SerializeField] public Transform[] playPositions;
    //tile prefab
    [SerializeField] private GameObject tile;

    private GameObject[] moveTilesArray;

    private GameObject startTile;

    [SerializeField] private Transform activeWordPosition;

    [SerializeField] private Transform primaryTile;

    public Transform ActiveWordPosition
    {
        get { return activeWordPosition; }
    }

    private Transform firstLetterPosition;



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

        firstLetterPosition = GameObject.Find("Pos 1").transform;


        nextFreePos = playPositions[selectedTiles.Count];


    }

    public void PlayTiles()
    {
        //sets the next free position to the selectedTiles length
        nextFreePos = playPositions[selectedTiles.Count];

    }


    public void ResetWordStartPoint()
    {
        selectedTiles.Clear();
        nextFreePos = playPositions[selectedTiles.Count];
    }



    public void SetStartTile(string firstLetter)
    {

        startTile = Instantiate(tile, primaryTile.transform);
        var tileScript = startTile.GetComponent<Tile>();
        tileScript.letter.text = firstLetter;
        tileScript.firstLetterTile = true;


        startTile.tag = "PrimaryTile";
        //        startTile.name = "PrimaryTile";

        tileScript.points.text = InitDictionary.Instance.pointsDictionary[tileScript.letter.text].ToString();

    }

    public void ShakeTiles (){
        iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

    }
}