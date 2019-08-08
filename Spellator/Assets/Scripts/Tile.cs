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

    //used to adding double and triple points to the overall score
    public int adjustedPointValue;

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

    //use as a unit of measurement for offsetting tiles
    private int tileOffset = 110;

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

        //get the primary tile position as a reference to use in the tweens below
        //it is in the update function as it needs to be updated constantly for use with the tweens below
        nextTileSpot = GameObject.Find("Primary Tile").transform.position;


        //make sure both the primary tile and the selected tiles move in relation to the Primary Tile game object
        if (CompareTag("TileSelected"))
        {
            //check if a word has been made before this
            if (DictionaryManager.Instance.chainFlag)
            {
                iTween.MoveUpdate(gameObject, new Vector3((nextTileSpot.x) + (tileOffset * positionInWord)- tileOffset, nextTileSpot.y), 1);

            }
            else
            {
                iTween.MoveUpdate(gameObject, new Vector3((nextTileSpot.x) + (tileOffset * positionInWord), nextTileSpot.y), 1);

            }

        }

        else if(CompareTag("PrimaryTile"))
        {
            iTween.MoveUpdate(gameObject, new Vector3(nextTileSpot.x, nextTileSpot.y), 1);

        }


    }


    private void OnEnable()
    {

        //set the colour back to black. It'll then get reset to the triple or double colour below
        letter.color = Color.black;
        points.color = Color.black;

        // iTween.Move(gameObject, iTween.Hash("x", 1.01, "y", 1.01, "time", Random.RandomRange(1f, 2f)));

        //create instance of the TileClass for use in the checks below
        spawnedTile = new TileClass(gameObject.transform.position);


        

        //if the tag is PrimaryTile then set the tile letter and points to be that of the StartLetter
        //otherwise, set them to come up randomly from the bag
        if (CompareTag("PrimaryTile"))
        {
            spawnedTile.letter = DictionaryManager.Instance.StartLetter;
            spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];

           

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



        switch (spawnedTile.specialAttribute)
        {
            case "heart":
                specialIcon.SetActive(true);
                //Debug.Log("heart tile");
                break;
            case "double":
                //specialIcon.SetActive(false);
                
                letter.color = Color.red;
                letter.color = Color.red;
                //update the points value of the tile so that it is added correctly to the overall live score
                adjustedPointValue = spawnedTile.points * 2;
                points.text = (spawnedTile.points * 2).ToString();
               // Debug.Log("double tile");

                break;
            case "triple":
                //  specialIcon.SetActive(false);
                letter.color = Color.blue;
                //update the points value of the tile so that it is added correctly to the overall live score
                adjustedPointValue = spawnedTile.points * 3;
                points.text = (spawnedTile.points * 3).ToString();
                //Debug.Log("triple tile");

                break;

            case "none":
                specialIcon.SetActive(false);
                adjustedPointValue = spawnedTile.points;

                break;
        }


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
            adjustedPointValue = spawnedTile.points;
            //tilePointValue = spawnedTile.points;

        }




    }



    public void HandleClick()


    {

        AudioManager.Instance.PlayAudio(tileClick);

        //check if the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
        if (CompareTag("Tile"))
        {

            //add this tile's Pos to the SelectedTiles list in TileManager
            TileManager.Instance.SelectedTiles.Add(transform.parent);


            //start spelling the word using the letter from this tile
            DictionaryManager.Instance.CreateWord(letter.text);


            //set the tag of this tile to be selected
            gameObject.tag = "TileSelected";



            //move tiles into position
            //iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "CheckWordBeingSpelled"));

            //use the chainFlag to see if you've made a word before or not.
            if (DictionaryManager.Instance.chainFlag)
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x) + (tileOffset * DictionaryManager.Instance.WordBeingMade.Length)- tileOffset, "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "CheckWordBeingSpelled"));

            } else
            {
                iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x) + (tileOffset * DictionaryManager.Instance.WordBeingMade.Length), "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "CheckWordBeingSpelled"));

            }

            //sets the next free position to the TileManager.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();

            //add the score to the live scroe

            if (PointsClass.multiplier >= 3)
            {
                scores.addLiveScore(adjustedPointValue * PointsClass.multiplier);
            }

            else
            {
                scores.addLiveScore(adjustedPointValue);

            }

            //move the live scor text box to below the current tile
            // SetLiveScorePos();

            GameManager.Instance.LiveScoreText.text = PointsClass.liveScore.ToString();

            positionInWord = DictionaryManager.Instance.WordBeingMade.Length;

        }


    }

    public void CheckWordBeingSpelled()
    {
         //if the word is longer than 3 letters, check if it's in the dictionary
            if (DictionaryManager.Instance.WordBeingMade.Length >= 3)
            {
                DictionaryManager.Instance.CheckWord();

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

        //decreases the health meter by the amount of the points on this tile

        //Camera.main.GetComponent<PlayerHealth>().DealDamage(spawnedTile.points);

        GameObject.Find("HealthBar").GetComponent<PlayerHealth>().DealDamage(spawnedTile.points);

        AudioManager.Instance.PlayAudio(smashSounds[Random.Range(0,smashSounds.Length)]);

        gameObject.SetActive(false);
        //set the tile holder to refill its tiles AFTER this object has been set to inactive
        gameObject.transform.parent.GetComponent<TileCreator>().RefillTiles();

    }

    public void SetPrimaryTile()
    {

        //set the tile's tag to be PrimaryTile
        gameObject.tag = "PrimaryTile";

        PointsClass.primaryTileScore = spawnedTile.points;

        //Debug.Log("the primary tile is worth " + spawnedTile.points + "points.");

        //reset the tile age
        spawnedTile.age = 4;




    }

}