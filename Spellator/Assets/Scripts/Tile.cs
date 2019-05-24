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

    private TileBag tileBag = new TileBag();
    
    [SerializeField] private AudioClip tileClick;
    public AudioClip[] popSounds;



    private PointsClass scores = new PointsClass();

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




        //create instance of the TileClass for use in the checks below
        spawnedTile = new TileClass(gameObject.transform.position);


        //if that tag is PrimaryTile then set the tile letter and points to be that of the StartLetter
        //otherwise, set them to come up randomly from the bag
        if (CompareTag ("PrimaryTile"))
        {
            spawnedTile.letter = DictionaryManager.Instance.StartLetter;
            spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];
            PointsClass.primaryTileScore = spawnedTile.points;

        } else if (CompareTag("Tile"))
        {
            spawnedTile.letter = TileBag.bag[Random.Range(0, TileBag.bag.Count)];
            spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];


            /*
            //extra check that the letter tile isn't equal to 0. This is the stop the bug where an "S" appears with 0 points and can't be played.
            if (spawnedTile.points != 0)
            {
                RemoveLetterFromBag();
            }
            else if (spawnedTile.points == 0)
            {
                spawnedTile.letter = TileBag.bag[Random.Range(0, TileBag.bag.Count)];
                spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];
            }
            */

        }



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
            if (gameObject.tag == "Tile")
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
                


            iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time",0.5f, "easetype", "EaseOutQuint"));

 
            //sets the next free position to the TileManage.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();

            //add the score
            scores.addLiveScore(spawnedTile.points);

            GameManager.Instance.LiveScoreText.text = PointsClass.liveScore.ToString();

            //GameManager.Instance.LiveScore = GameManager.Instance.LiveScore + tilePointValue;
            // GameManager.Instance.LiveScoreText.text = GameManager.Instance.LiveScore.ToString();



        }


    }
    public void RemoveTileOnComplete()
    {
        //Debug.Log("Tile set to inactive");
        gameObject.SetActive(false);
        AudioManager.Instance.PlayAudio(popSounds[Random.Range(0, 3)]);
        // iTween.FadeFrom(gameObject, iTween.Hash("time", 0.25f, "alpha", 1));

    }

    public void RemoveLetterFromBag()
    {

        TileBag.bag.Remove(spawnedTile.letter);
        Debug.Log("there are " + TileBag.bag.Count + " tiles remaining in the bag");

    }


}