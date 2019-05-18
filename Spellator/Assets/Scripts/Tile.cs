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

    [SerializeField] private AudioClip tileClick;


    private int positionInRack;
    private Vector3 returnPos;

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


    //create the list of letters which this could be.

    private void OnEnable()
    {

        //create a new instance of the TileClass class
        //spawnedTile = new TileClass(gameObject.transform.position);

        //spawnedTile = new TileClass();

        spawnedTile = new TileClass(gameObject.transform.position, "default");

        //sets the letter on the tile each time the tile is enabled
        letter.text = spawnedTile.letter;
        points.text = spawnedTile.points.ToString();
        tilePointValue = spawnedTile.points;

    }


    void Start()
    {
        //gameObject.transform.localScale = new Vector3 (1,1);

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


            iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time",0.5f, "easeType", "EaseOutQuint"));

 
            //sets the next free position to the TileManage.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();
                

                //add the score

                GameManager.Instance.LiveScore = GameManager.Instance.LiveScore + tilePointValue;
                GameManager.Instance.LiveScoreText.text = GameManager.Instance.LiveScore.ToString();







        }


    }


}