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

    private SpecialMeterClass specialMeter = new SpecialMeterClass();

    public TileClass spawnedTile;

    public bool firstLetterTile;

    private TileBag tileBag = new TileBag();

    [SerializeField] private AudioClip tileClick;
    [SerializeField] private GameObject specialIcon;

    public AudioClip[] popSounds;
    public AudioClip[] smashSounds;


    public Vector3 nextTileSpot;

    private PointsClass scores = new PointsClass();

    private int positionInRack;
    private Vector3 returnPos;

    private Vector3 currentSpot;

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


    private int positionInWord;


    private void Update()
    {
      
        //check the tile's age and swap in the appropirate tile state image
            switch (spawnedTile.age)
            {
                case 4:
                    tileBGImage.sprite = tileStateImages[3];
                    letter.color = Color.black;
                    points.color = Color.black;
                break;
                case 3:
                    tileBGImage.sprite = tileStateImages[2];
                    break;
                case 2:
                    tileBGImage.sprite = tileStateImages[1];
                    break;
                case 1:
                    tileBGImage.sprite = tileStateImages[0];
                    break;
                case 0:
                tileBGImage.sprite = tileStateImages[0];
                letter.color = Color.gray;
                points.color = Color.gray;
                break;

            }

        var currentPos = GameObject.Find("Primary Tile").transform.position;

        if (gameObject.CompareTag("TileSelected"))
        {
           // iTween.MoveUpdate(gameObject, iTween.Hash("x", GameManager.Instance.rackSpots[DictionaryManager.Instance.WordBeingMade.Length].transform.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f));

            // iTween.MoveUpdate(gameObject, iTween.Hash("x", currentPos.x+(110*positionInWord), "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f));
            //iTween.MoveUpdate(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f));

        }






    }


    private void OnEnable()
    {
       // iTween.Move(gameObject, iTween.Hash("x", 1.01, "y", 1.01, "time", Random.RandomRange(1f, 2f)));

        //create instance of the TileClass for use in the checks below
        spawnedTile = new TileClass(gameObject.transform.position);


        switch (spawnedTile.specialAttribute)
        {
            case "heart":
                specialIcon.SetActive(true);
                break;
            case "double":
              //  specialIcon.SetActive(false);
            //    letter.color = Color.red;
                break;
            case "triple":
              //  specialIcon.SetActive(false);
               // letter.color = Color.blue;

                break;

            case "none":
                specialIcon.SetActive(false);

                break;
        }


        //if the tag is PrimaryTile then set the tile letter and points to be that of the StartLetter
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
            }*/
            

            PointsClass.primaryTileScore = spawnedTile.points;

        } else if (CompareTag("Tile"))
        {

            spawnedTile.letter = TileBag.bag[Random.Range(0, TileBag.bag.Count)];
            spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];
            RemoveLetterFromBag();



        }



        //sets the letter on the tile each time the tile is enabled
        letter.text = spawnedTile.letter;
        points.text = spawnedTile.points.ToString();
        tilePointValue = spawnedTile.points;

        //removes the tile from the bag





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
        if (CompareTag("Tile"))
        {

           
            

            //add this tile's Pos to the SelectedTiles list in TileManager
            TileManager.Instance.SelectedTiles.Add(transform.parent);


            //start spelling the word using the letter from this tile
            DictionaryManager.Instance.CreateWord(letter.text);

            //if the word is longer than 3 letters, check if it's in the dictionary
            if (DictionaryManager.Instance.WordBeingMade.Length >= 3)
            {
                DictionaryManager.Instance.CheckWord();
                positionInWord = DictionaryManager.Instance.WordBeingMade.Length;
            }

            gameObject.tag = "TileSelected";




            nextTileSpot = GameObject.Find("Primary Tile").transform.position;

            // currentSpot = (nextTileSpot.x) + (110 * DictionaryManager.Instance.WordBeingMade.Length);

            //iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut"));


            // iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x)+(110*DictionaryManager.Instance.WordBeingMade.Length), "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeOutQuint"));


            //move tiles into position
            iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut"));


            /*
             if (DictionaryManager.Instance.WordBeingMade.Length != 5)
             {
                 iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut"));

             } else if (DictionaryManager.Instance.WordBeingMade.Length == 5)
             {
                 iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "MoveTileForLongWord"));

             }*/


            //sets the next free position to the TileManager.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();

            //add the score
            scores.addLiveScore(spawnedTile.points);

            //move the live scor text box to below the current tile
           // SetLiveScorePos();

            GameManager.Instance.LiveScoreText.text = PointsClass.liveScore.ToString();


           
        }


    }
    public void RemoveTileOnComplete()
    {
        //set tiles back to inactive so that they can go back into the object pool
        gameObject.SetActive(false);
        AudioManager.Instance.PlayAudio(popSounds[Random.Range(0, 3)]);

    


    }

    public void RemoveLetterFromBag()
    {
        //removes the letters from the bag
        TileBag.bag.Remove(spawnedTile.letter);
        //TileBag.usedLetters.Add(spawnedTile.letter);

        /*
        foreach(string letterInBag in TileBag.usedLetters)
        {
            Debug.Log("used letter: " + letterInBag);
        }
    */   

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

    //this function needs to be on the tile as it has to have an oncomplete function run
    //this oncomplete refills the tiles via the TileCreator
    public void DropTile()
    {
        var randomTime = Random.Range(0.5f, 1f);
        var randomDistance = Random.Range(-500, -800);

        iTween.MoveBy(gameObject, iTween.Hash("y", randomDistance, "time", randomTime, "easetype", "easeInOutExpo", "delay", randomTime, "oncomplete", "SetTileInactive"));

        


        //Debug.Log("Meter Percent: " + SpecialMeterClass.meterPercent + " Reduced by: " + spawnedTile.points + " Remaining Meter: " + SpecialMeterClass.meterRemaining);
    }

    //function to refill the tiles and set this one to inactive so it can go back into the object pool
    public void SetTileInactive()
    {
        

        //decreases the "special" meter by the amount of the points on this tile
        specialMeter.DecreaseMeter(spawnedTile.points);
        AudioManager.Instance.PlayAudio(smashSounds[Random.Range(0,smashSounds.Length)]);

        //checks to see if the life meter has anything left in it. If not, it's game over, fool.
        GameManager.Instance.CheckLifeMeter();

        gameObject.SetActive(false);
        gameObject.transform.parent.GetComponent<TileCreator>().RefillTiles();
    }

}