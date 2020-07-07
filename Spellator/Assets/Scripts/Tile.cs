﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{


     public Image tileBGImage;

    private PlayerHealth healthHandler;

    //public static TileDisplay tileDisplayAccess;
    public static TileSkinSelection tileDisplayAccess;

    public TutorialSO tutorial;

    public TileBagSO currentBag;
    public LevelManagerSO levelManager;
    public Animator animator;
    public ParticleSystem twinkleParticles;
   // public ParticleSystem glowParticles;

    public int specialChance;

    //sets whether or not the tile can age
    public bool canAge = true;

    public GameObject explosionClip;

    public AudioSO audioScriptableObject;

    private Transitions fadeManager;
    public AnimationCurve mainAnimationCurve;

    public TextMeshProUGUI letter;
    public TextMeshProUGUI points;

    private GameObject explosionObject;

    //used to adding double and triple points to the overall score
    public int adjustedPointValue;

    //add reference to scriptable objects
    public AudioEvent removeTileAudio;
    public AudioEvent popSounds;
    public AudioSource smashAudioSource;
    public AudioSource popAudioSource;
    public AudioSource swishAudioSource;

    public TileClass spawnedTile;
    public GameObject levelUpText;

    public bool firstLetterTile;

    //private TileBag tileBag;

    //[SerializeField] private AudioClip tileClick;
    [SerializeField] private GameObject specialIcon;
    [SerializeField] private GameObject pointsIcon;
    [SerializeField] private GameObject circleBG;

    //public AudioClip[] popSounds;
    //public AudioClip[] smashSounds;

    public GameObject healthParticles;

    public Vector3 nextTileSpot;


    private int positionInRack;

    //use as a unit of measurement for offsetting tiles
    private int tileOffset = 100;

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



    void Start()
    {
        healthParticles = ObjectPooler.SharedInstance.GetPooledObject("Heart Particles");

        //glowParticles.Stop();

        //stop the twinkle particle effect
        twinkleParticles.Stop();
        //check to see if the tile is the first tile for chain mode words
        if (firstLetterTile == false)
        {
            //sets the letter and point text of each tile
            letter.text = spawnedTile.letter;
            points.text = spawnedTile.points.ToString();
            adjustedPointValue = spawnedTile.points;

        }

        //used for Scriptable Object access
        //tileDisplayAccess = GetComponent<TileDisplay>();

        tileDisplayAccess = GetComponent<TileSkinSelection>();


        healthHandler = GameObject.Find("HealthBar").GetComponent<PlayerHealth>();

    }

    private void Update()
    {


        switch (spawnedTile.age)
        {
            case 4:
                //if the age is 4 then use the tiles from the scriptable object within the array
               tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[0];
                //set the colour of the tile text to be that of the default skin selected colour
                //letter.color = Color.black;
               letter.color = tileDisplayAccess.tileTextColour;
                points.color = tileDisplayAccess.tileTextColour;
                break;
            case 3:
                //if the age is 4 then use the tiles from the scriptable object within the array
               tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[1];
                break;
            case 2:
                tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[2];
                break;
            case 1:
                tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[3];
                break;
            case 0:
                tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[4];

                if (levelManager.levelComplete != true)
                {
                    //set the colour of the tile text to be that of the inactive text within the scriptable object
                    letter.color = tileDisplayAccess.tileDisabledColour;
                    points.color = tileDisplayAccess.tileDisabledColour;
                }
               
                break;

        }

        if (spawnedTile.tilePower == "heal")
        {
            specialIcon.SetActive(true);

            //Debug.Log("tile power is: " + TileClass.TilePower.heal);
        }

        switch (spawnedTile.specialAttribute)
        {
            /*
            case "heart":
                specialIcon.SetActive(true);
                break;
            */
            case "double":

                pointsIcon.SetActive(true);
                circleBG.SetActive(true);
                pointsIcon.GetComponent<Image>().color = tileDisplayAccess.doubleLetterColour;
                //letter.color = tileDisplayAccess.doubleLetterColour;

                //update the points value of the tile so that it is added correctly to the overall live score
                adjustedPointValue = spawnedTile.points * 2;
                points.text = adjustedPointValue.ToString();
                break;
            case "triple":

                pointsIcon.SetActive(true);
                circleBG.SetActive(true);
                pointsIcon.GetComponent<Image>().color = tileDisplayAccess.tripleLetterColour;
                //letter.color = tileDisplayAccess.tripleLetterColour;

                //update the points value of the tile so that it is added correctly to the overall live score
                adjustedPointValue = spawnedTile.points * 3;
                points.text = (spawnedTile.points * 3).ToString();
                break;

            case "stubborn":

                tileBGImage.sprite = tileDisplayAccess.tileAgeSprites[5];
                canAge = false;

                break;

            case "none":
                specialIcon.SetActive(false);
                pointsIcon.SetActive(false);
                circleBG.SetActive(false);
                adjustedPointValue = spawnedTile.points;
                break;
        }





        //get the primary tile position as a reference to use in the tweens below
        //it is in the update function as it needs to be updated constantly for use with the tweens below
        nextTileSpot = GameObject.Find("Primary Tile").transform.position;


        //CONTENT REMOVED FROM HERE FOR TILE POSITIONING
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
        //stop the particles that were playing when this was the primary tile
        //glowParticles.Stop();

//        healthParticles = ObjectPooler.SharedInstance.GetPooledObject("Heart Particles");

        //this is the code that chooses the random value from the curve.
        //The curve can be adjusted in the inspector
        float CurveWeightedRandom(AnimationCurve curve)
        {
            //multiply the float that is returned by 100
            return curve.Evaluate(Random.value)* GameManager.Instance.specialTileProbability;
        }

        //this is the curve
        //CurveWeightedRandom(mainAnimationCurve);

        specialChance = Mathf.CeilToInt(CurveWeightedRandom(mainAnimationCurve));

//        Debug.Log("curve number: " + Mathf.CeilToInt(CurveWeightedRandom(mainAnimationCurve)));

        //        Debug.Log("<color=red>curve weighted random</color> " + CurveWeightedRandom(GameManager.Instance.GetComponent<CreateNewBag>().mainAnimationCurve));



        //  animator.SetBool("clearTile", false);


        //create instance of the TileClass for use in the checks below

        spawnedTile = new TileClass(gameObject.transform.position);
//        Debug.Log("spawned tile attribute: " + spawnedTile.specialAttribute);
        //resets the special type of a tile when it loads
        spawnedTile.AllocateSpecialType();


        //Debug.Log(TileBag.pointsDictionary.Count);

        //if the tag is PrimaryTile then set the tile letter and points to be that of the StartLetter
        //otherwise, set them to come up randomly from the bag
        if (CompareTag("PrimaryTile"))
        {

            spawnedTile.letter = DictionaryManager.Instance.StartLetter;
            spawnedTile.points = currentBag.letterDictionary[spawnedTile.letter];

            /*
             //set the primary tile score to be that of this tile
             Points.primaryTileScore = spawnedTile.points;'
             */

        } else if (CompareTag("Tile"))
        {

            //get the spawned letter by grabbing the value from the animation curve (which has been multiplied by the length of the bag
            //then converted to a whole number via Mathf.CeilToInt

            // spawnedTile.letter = TileBag.bag[Mathf.CeilToInt(CurveWeightedRandom(GameManager.Instance.GetComponent<CreateNewBag>().mainAnimationCurve))];

           
                spawnedTile.letter = TileBag.bag[Random.Range(0,TileBag.bag.Count)];
            
            

            //check that the letter actually exists in the bag before using it
            if (TileBag.bag.Contains(spawnedTile.letter))
            {
                //set the tile point amount
                spawnedTile.points = currentBag.letterDictionary[spawnedTile.letter];
                // TileBag.bag.Remove(spawnedTile.letter);
                //Debug.Log(" Tile spawned: " + spawnedTile.letter + " tile points: " + spawnedTile.points);

            }

            else
            {
                Debug.Log("<color=green> You're missing a tile letter!<color>");
            }



            //currentBag.bag.Remove(spawnedTile.letter);


            // currentBag.RemoveLetterUsed(TileBag.bag.Count.ToString());

            // spawnedTile.letter = TileBag.bag[Random.Range(0, TileBag.bag.Count)];
            //spawnedTile.points = TileBag.pointsDictionary[spawnedTile.letter];

        }



        //sets the letter on the tile each time the tile is enabled
        letter.text = spawnedTile.letter;
        points.text = spawnedTile.points.ToString();
        tilePointValue = spawnedTile.points;


        //refill the tile bag
        // GameManager.Instance.CheckBagLevels();
        // Debug.Log(TileBag.bag.Count + " Tiles remaining in bag");

    }






    public void HandleClick()

    {
        //TutorialActions.OnTutorialItemInitiated("stubborn tiles");
        //for tutorial only
        if (tutorial.tutorialOn)
        {
            CheckTileTutorial();

        }

        Debug.Log(spawnedTile.specialAttribute);


        //Debug.Log(GameManager.Instance.testList.Count);

        //play the tile animation  
        // animator.SetBool("correctWord", true);

        //play the small twinkle particles
        twinkleParticles.Play();

        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxTilePops[7]);
            //AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxUserInterface[3]);
            /*
            swishAudioSource.volume = 0.4f;
            AudioManager.Instance.PlayAudioWithSource(AudioManager.Instance.sfxUserInterface[3], swishAudioSource, 0.1f);

            */
        }

        //check if this is a primary tile that is being clicked and thus removed
        if (CompareTag("PrimaryTile"))
        {
            //reset the flags for the first tile, etc.
            DictionaryManager.Instance.chainFlag = false;
            DictionaryManager.Instance.WordBeingMade = "";

            //reset the multiplier
            Points.multiplier = 1;

            //play the lost multiplier sound
            AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[7]);
            fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();
            fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

            //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
            explosionClip = ObjectPooler.SharedInstance.GetPooledObject("Explosion");

            if (explosionClip != null)
            {
                explosionClip.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
                explosionClip.transform.SetParent(GameManager.Instance.mainCanvas.transform);
                explosionClip.SetActive(true);
                //available = false;

            }



            //remove the tile and play its animation
            RemoveTileOnComplete();

        }
        //check if the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
        else if (CompareTag("Tile"))
        {

            //add this tile's Pos to the SelectedTiles list in TileManager
            TileManager.Instance.SelectedTiles.Add(transform.parent);


            //start spelling the word using the letter from this tile
            DictionaryManager.Instance.CreateWord(letter.text);


            //set the tag of this tile to be selected
            gameObject.tag = "TileSelected";



            //move tiles into position
            //iTween.MoveTo(gameObject, iTween.Hash("x", TileManager.Instance.NextFreePos.position.x, "y", TileManager.Instance.NextFreePos.position.y, "time", 0.5f, "easetype", "easeOut", "oncomplete", "CheckWordBeingSpelled"));

            //use the chainFlag to see if there's an active primary tile
            
                //iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x) + (tileOffset * DictionaryManager.Instance.WordBeingMade.Length)- tileOffset, "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeInOut", "oncomplete", "CheckWordBeingSpelled"));
            iTween.MoveTo(gameObject, iTween.Hash("x", (nextTileSpot.x) + (tileOffset * DictionaryManager.Instance.WordBeingMade.Length) - tileOffset, "y", nextTileSpot.y, "time", 0.5f, "easetype", "easeInOut", "oncomplete", "CheckWordBeingSpelled"));


            //sets the next free position to the TileManager.Instance.selectedTiles length

            TileManager.Instance.PlayTiles();

            //add the score to the live score

                Points.AddToLiveScore(adjustedPointValue);

       

            GameManager.Instance.LiveScoreText.text = Points.liveScore.ToString();

            positionInWord = DictionaryManager.Instance.WordBeingMade.Length;

        }

//        Debug.Log("tile letter: " + spawnedTile.letter + " points: " + spawnedTile.points);



    }

    public void CheckWordBeingSpelled()
    {
         //if the word is longer than 3 letters, check if it's in the dictionary
            if (DictionaryManager.Instance.WordBeingMade.Length >= 3)
            {
                DictionaryManager.Instance.CheckWord();

            }
          //  animator.SetBool("clearTile", false);
    }

    public void RemoveTileOnComplete()
    {
        GameManager.Instance.ShakeCamera(6,6,0.5f);

        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlayAudioWithSource(AudioManager.Instance.sfxTilePops[Random.Range(0, 6)], popAudioSource, Random.Range(0.4f, 1f));

        }
        else
        {

        }

        if (spawnedTile.tilePower == "heal")
        {
            //healthParticles.transform.position = GameObject.Find("HealthBar").transform.position;
            //healthParticles.transform.SetParent(DictionaryManager.Instance.healthBar.transform);
            healthParticles.transform.position = gameObject.transform.position;
            healthParticles.SetActive(true);

            //heal if it's a heart tile
            DictionaryManager.Instance.healthBar.GetComponent<PlayerHealth>().Heal(adjustedPointValue);

            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxGeneral[17]);

            }
        }
        
     

        


        
        //check if levelComplete in the levelManager SO is true/false
        //used to make sure that the animations don't play if the level is complete


        //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
        explosionClip = ObjectPooler.SharedInstance.GetPooledObject("Explosion");

        if (explosionClip != null)
        {
            explosionClip.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            explosionClip.transform.SetParent(GameManager.Instance.mainCanvas.transform);
            explosionClip.SetActive(true);
            //available = false;

        }

        if (levelManager.levelComplete == true)
        {

            explosionObject = ObjectPooler.SharedInstance.GetPooledObject("CorrectWord");
            if (explosionObject != null)
            {
                explosionObject.transform.position = gameObject.transform.position;
                explosionObject.SetActive(true);
//                Debug.Log("explosions worked!");
            }

            levelUpText = ObjectPooler.SharedInstance.GetPooledObject("Level Up Text");
            if (levelUpText != null)
            {
                levelUpText.transform.position = gameObject.transform.position;
                //levelUpText.transform.SetParent(mainCanvas);
                levelUpText.SetActive(true);

            }

           
            //popSounds.Play(popAudioSource);

        }
        else
        {
           // Debug.Log("animations not played");
        }


        //set tiles back to inactive so that they can go back into the object pool
        gameObject.SetActive(false);
        // AudioManager.Instance.PlayAudio(popSounds[Random.Range(0, 3)]);
       // Debug.Log("remove sound played");




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

        iTween.MoveBy(gameObject, iTween.Hash("y", randomDistance, "time", randomTime, "easetype", "easeInExpo", "delay", randomTime, "oncomplete", "SetTileInactive"));

        


        //Debug.Log("Meter Percent: " + SpecialMeterClass.meterPercent + " Reduced by: " + spawnedTile.points + " Remaining Meter: " + SpecialMeterClass.meterRemaining);
    }

    //function to refill the tiles and set this one to inactive so it can go back into the object pool
    public void SetTileInactive()
    {

        //decreases the health meter by the amount of the points on this tile

        //Camera.main.GetComponent<PlayerHealth>().DealDamage(spawnedTile.points);


        //uses a cached reference for performance reasons

        //multiply the health so that it decreases by a factor of 1.25 (rounded up)

        healthHandler.DealDamage(Mathf.CeilToInt(spawnedTile.points*1.25f));
        //GameObject.Find("HealthBar").GetComponent<PlayerHealth>().DealDamage(spawnedTile.points);

        //removeTileAudio.Play(smashAudioSource);

        //AudioManager.Instance.PlayAudio(AudioManager.Instance.sfxTileCrashes[Random.Range(0,6)]);

        //play audio using a separate audio source and setting the volume on play

        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlayAudioWithSource(AudioManager.Instance.sfxTileCrashes[Random.Range(0, 6)], smashAudioSource, Random.Range(0.05f, 0.1f));

        }
        //        Debug.Log("volume of sound: " + smashAudioSource.volume);

        //AudioManager.Instance.PlayAudio(smashSounds[Random.Range(0,smashSounds.Length)]);

        gameObject.SetActive(false);
        //set the tile holder to refill its tiles AFTER this object has been set to inactive
        gameObject.transform.parent.GetComponent<TileCreator>().RefillTiles();

    }

    public void SetPrimaryTile()
    {

        //set the tile's tag to be PrimaryTile
        gameObject.tag = "PrimaryTile";

        Points.primaryTileScore = spawnedTile.points;
        Points.liveScore = Points.primaryTileScore;

        //play the particles that are for the primary tile

        /*
        if (levelManager.levelComplete != true)
        {
            glowParticles.Play();
        }*/

        //Debug.Log("the primary tile is worth " + spawnedTile.points + "points.");

        //reset the tile age
        spawnedTile.age = 4;

    }

    //resets the particle systems to be inactive so they can be reused in the object pool
    private IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            healthParticles.SetActive(false);
            //            Debug.Log("heart particles inactive");
            StopCoroutine("CheckIfAlive");
        }
    }


    public void CheckTileTutorial()
    {
        switch (spawnedTile.specialAttribute)
        {
            case "stubborn":
                TutorialActions.OnTutorialItemInitiated("stubborn tiles");
                break;

                /*
            case "heart":
                TutorialActions.OnTutorialItemInitiated("heart tiles");
                break;
                */
            case "double":
                TutorialActions.OnTutorialItemInitiated("double tiles");
                break;

            case "triple":
                TutorialActions.OnTutorialItemInitiated("triple tiles");
                break;

            case "none":
                TutorialActions.OnTutorialItemInitiated("default tiles");
                break;
        }
    }

}