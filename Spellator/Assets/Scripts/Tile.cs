using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{

    public TextMeshProUGUI letter;
    public TextMeshProUGUI points;

    public TileClass spawnedTile;

    public bool firstLetterTile;
    
    [SerializeField] private Image blueDot;
    [SerializeField] private Image redDot;

    [SerializeField] private AudioClip tileClick;

    //for the coroutine
    private float smoothing = 10f;

    private int positionInRack;
    private Vector3 returnPos;

    private float moveSpeed;
    public float speed = 1.0F;
    public int PositionInRack

    {
        get { return positionInRack; }
        set { PositionInRack = value; }
    }

    private int tilePointValue;

    public int TilePointValue
    {
        get { return tilePointValue; }
    }

    /*
    public Transform tileCreatorParent;
    private Transform originalParent;


    public Transform OriginalParent

    {
        get { return originalParent; }
        set { OriginalParent = value; }
    }*/

    //create the list of letters which this could be.

    private void OnEnable()
    {

        //create a new instance of the TileClass class
        spawnedTile = new TileClass(gameObject.transform.position);
        //Debug.Log("enable script is working");
        spawnedTile.Scramble();

    }


    void Start()
    {
       

        //check to see if the tile is the first tile for chain mode words
        if (firstLetterTile == false)
        {
            //sets the letter and point text of each tile
            letter.text = spawnedTile.letter;
            points.text = spawnedTile.points.ToString();
            tilePointValue  = spawnedTile.points;

        }



    }

    public void HandleClick()


    {
        //var mainWord = GameObject.Find("Word Being Spelled");
        //iTween.MoveTo(mainWord, new Vector3(mainWord.transform.position.x-200, mainWord.transform.position.y, 0), 0.5f);

        AudioManager.Instance.PlayAudio(tileClick);

            //check is the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
            if (gameObject.tag != "TileSelected")
            {

                //add this tile's Pos to the SelectedTiles list in TileManager
                TileManager.Instance.SelectedTiles.Add(transform.parent);


                //start spelling the word using the letter from this tile
                DictionaryManager.Instance.CreateWord(letter.text);

                //if the word is longer than 3 letters, check if it's in the dictionary
                if (DictionaryManager.Instance.WordBeingMade.Length >= 3)
                {
                    DictionaryManager.Instance.CheckWord();
                }

                gameObject.tag = "TileSelected";


            //////////////////
            ///THIS IS THE SECTION WHERE THE TILE PARENT is changed to be attached to the main word 
            /////////////////
            /// 
           // ParentTileToActiveWord();

            //this sets the next tile to be placed

           // iTween.MoveTo(gameObject, new Vector3(TileManager.Instance.NextFreePos.position.x, TileManager.Instance.NextFreePos.position.y, 0), 0.5f);

            iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time",0.5f, "easeType", "EaseOutQuint"));

            // TileManager.Instance.NextFreePos.position
            //StartCoroutine(PlayTileToBoard(TileManager.Instance.NextFreePos));

            //sets the next free position to the TileManage.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();
                

                //add the score

                GameManager.Instance.LiveScore = GameManager.Instance.LiveScore + tilePointValue;
                GameManager.Instance.LiveScoreText.text = GameManager.Instance.LiveScore.ToString();







        }


    }


    /*
    //this function resets the tile parent to be that of the Tile Creator to which it was spawned
    public void SetToOriginalParent()
    {
        gameObject.transform.parent = originalParent;
    }

    //this function parents the tile to the active word positon
    public void ParentTileToActiveWord()
    {
        gameObject.transform.parent = TileManager.Instance.ActiveWordPosition;
    }*/

}