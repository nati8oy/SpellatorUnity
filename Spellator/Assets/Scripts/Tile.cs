using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{

    [SerializeField] private Image tileBGImage;
    public Sprite[] tileStateImages;

    //sets whether or not the tile can age
    public bool canAge = true;

    public TextMeshProUGUI letter;
    public TextMeshProUGUI points;



    public TileClass spawnedTile;

    public bool firstLetterTile;

    private TileBag tileBag = new TileBag();

    [SerializeField] private AudioClip tileClick;
    [SerializeField] private GameObject specialIcon;

    public AudioClip[] popSounds;


    public Vector3 nextTileSpot;

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



    private void Update()
    {
      

            switch (spawnedTile.age)
            {
                case 4:
                    // tileBGImage.color = Color.white;
                    tileBGImage.sprite = tileStateImages[3];
                    break;
                case 3:
                   // tileBGImage.color = Color.white;
                    tileBGImage.sprite = tileStateImages[2];
                    break;
                case 2:
                  //  tileBGImage.color = Color.yellow;
                    tileBGImage.sprite = tileStateImages[1];
                    break;
                case 1:
                   // tileBGImage.color = Color.red;
                    tileBGImage.sprite = tileStateImages[0];
                    break;
                case 0:
                    break;

            }



    }

    //create the list of letters which this could be.

    private void OnEnable()
    {
        //create instance of the TileClass for use in the checks below
        spawnedTile = new TileClass(gameObject.transform.position);

        switch (spawnedTile.specialAttribute)
        {
            case "star":
                specialIcon.SetActive(true);

                break;
            case "triangle":
                specialIcon.SetActive(true);

                break;
            case "circle":
                specialIcon.SetActive(true);

                break;
            case "square":
                specialIcon.SetActive(true);

                break;
            case "none":
                specialIcon.SetActive(false);
                break;
        }

     



        //if that tag is PrimaryTile then set the tile letter and points to be that of the StartLetter
        //otherwise, set them to come up randomly from the bag
        if (CompareTag("PrimaryTile"))
        {
            spawnedTile.letter = DictionaryManager.Instance.StartLetter;
            spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];

            /*
            if (spawnedTile.letter == "X")
            {
                spawnedTile.letter = TileBag.bag[Random.Range(0, TileBag.bag.Count)];
                spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];
            }
            */

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

        //removes the tile from the bag
        RemoveLetterFromBag();




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
            tilePointValue = spawnedTile.points;

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




            nextTileSpot = GameObject.Find("Primary Tile").transform.position;

            //iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x)+(110*DictionaryManager.Instance.WordBeingMade.Length), "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeOutQuint"));


            if (DictionaryManager.Instance.WordBeingMade.Length != 5)
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut"));

            } else if (DictionaryManager.Instance.WordBeingMade.Length == 5)
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "MoveTileForLongWord"));

            }


            //sets the next free position to the TileManager.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();

            //add the score
            scores.addLiveScore(spawnedTile.points);

            //move the live scor text box to below the current tile
            SetLiveScorePos();

            GameManager.Instance.LiveScoreText.text = PointsClass.liveScore.ToString();


           
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
        //removes the letters from the bag
        TileBag.bag.Remove(spawnedTile.letter);
        //Debug.Log("there are " + TileBag.bag.Count + " tiles remaining in the bag");

    }

    //this function sets the position of the live score text box to be under the current letter
    public void SetLiveScorePos(){
        var liveScoreGameObject = GameObject.Find("Live Score");
        liveScoreGameObject.transform.position = new Vector3(liveScoreGameObject.transform.position.x+100, liveScoreGameObject.transform.position.y);
}

    public void MoveTileForLongWord()

    {
        if (DictionaryManager.Instance.WordBeingMade.Length > 3)    
        {
            DictionaryManager.Instance.ScootTilesDown(-450);
      
        }


    }

    public void ReduceAge()
    {
        spawnedTile.age -= 1;
    }

}