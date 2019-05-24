﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Game Manager Code
    //sets up an instance of the GameManager
    public static GameManager Instance;

    //[SerializeField] private AudioClip bgMusic;
    //public float audioTrackSelection;
    private AudioSource gameManagerAudioSource;

    [SerializeField] private AudioClip gameOverAudio;
    [SerializeField] private AudioClip bigScore;

    [SerializeField] private Text blueTotalScore;
    [SerializeField] private Text redTotalScore;

    [SerializeField] private RectTransform gameOverPanel;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject obj;

    //instance of the Points Class to handle points
    private PointsClass scoreClass;

    private int blueTotal;
    private int redTotal;

    public int BlueTotal
    {
        get { return blueTotal; }
        set { BlueTotal = value; }
    }

    public int RedTotal
    {
        get { return redTotal; }
        set { RedTotal = value; }
    }




    public RectTransform GameOverPanel
    {
        get { return gameOverPanel; }
        set { GameOverPanel = value; }
    }

    private bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set { GameOver = value; }
    }


    private int liveScore;
    public int LiveScore
    {
        get { return liveScore; }
        set
        {
            liveScore = value;
        }
    }

    //holds the data for the most recent score the points text can access it
    public int mostRecentScore;

    private int totalScore;

    public int TotalScore
    {
        get { return totalScore; }
        set { TotalScore = value; }
    }

//    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveScoreText;

    public Text LiveScoreText
    {
        get { return liveScoreText; }
        set { LiveScoreText = value; }
    }

    private int setTimerTo = 60;

    public int SetTimerTo
    {
        get { return setTimerTo; }
    }


    //this is the singleton code to ensure there's not more than one instance running
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

        //create an instance of the points class
        scoreClass = new PointsClass();

        //add the letters to the bag List within the TileBag class
        TileBag lettersBag = new TileBag();
        lettersBag.AddLettersToDictonary();

        //instantiate all the objects to pool
        for (int i = 0; i < amountToPool; i++)
        {   
            obj = Instantiate(objectToPool);
                       
            //set object to inactive
            obj.SetActive(false);
           // obj.tag = "Pooled Tile";
            //obj.transform.SetParent(GameObject.Find("Pool").transform);
            pooledObjects.Add(obj);


        }


        gameManagerAudioSource = GetComponent<AudioSource>();

        gameManagerAudioSource.loop = true;


            //setTimerTo = 20;
            //set scores to blank
        liveScoreText.text = "";
        //scoreText.text = "";

        //make the send button inactive on start up
        DictionaryManager.Instance.sendButton.interactable = false;
    }


    public void CalculateScores()
    {

        //check to see if there's a multiplier
        if( DictionaryManager.Instance.Multiplier >= 3)
        {
            totalScore = totalScore + (liveScore* DictionaryManager.Instance.Multiplier);
            mostRecentScore = liveScore * DictionaryManager.Instance.Multiplier;
        }

        //otherwise just do the standard score adding.
        else
        {
            /*
            var bonusReference = GameObject.Find("Bonus Bar").GetComponent<BonusBar>();

            var additionalPoints = bonusReference.BonusAwarded;
          
        */
            /*

                var primaryTile = GameObject.Find("Primary Tile");
               var primaryTilePoints = primaryTile.GetComponent<Tile>();
                var primaryTileTotalPoints = primaryTilePoints.points.;
                */

           // scoreClass.addPoints();
            totalScore = totalScore + liveScore;

               mostRecentScore = LiveScore;
        }


        //add audio if the score of the last word was bigger than 50 points
        if (mostRecentScore >= 350)
        {
            AudioManager.Instance.PlayAudio(bigScore);
        }


        //scoreText.text = totalScore.ToString();


    }


    public void TallyColours(string colour)
    {
        if(colour == "blue")
        {
            blueTotal += 1;
        }
         else if(colour == "red")
        {
            redTotal += 1;
        }
    }

    public void GameOverMethod()
    {

       gameOverPanel.gameObject.SetActive(true);
        AudioManager.Instance.PlayAudio(gameOverAudio);

    }

    public void ResetGame()
    {

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        /*
        ResetScores();
        setTimerTo = 60;
        blueTotal = 0;
        redTotal = 0;
        totalScore = 0;
        DictionaryManager.Instance.TotalWordsMade = 0;
        gameOverPanel.gameObject.SetActive(false);
        DictionaryManager.Instance.ClearWord();
        DictionaryManager.Instance.WordBeingMade = "";
        DictionaryManager.Instance.PrimaryTile.SetActive(false);
        var primaryTile = GameObject.Find("Primary Tile");
        primaryTile.SetActive(false);*/

    }



    public GameObject GetPooledObject()
    {
        //
        for (int i = 0; i < pooledObjects.Count; i++)
        {


            //if the pooled objects aren't active in the hierarchy then get the next pooled object
            if (pooledObjects[i].activeInHierarchy != true)
            {
                return pooledObjects[i];
            }
        }
        //if it's active then just return nothing.
        return null;
    }


    public void StartSetup()
    {

        //add the letters to the bag List within the TileBag class
        TileBag lettersBag = new TileBag();
       // lettersBag.AddLettersToDictonary();


        //instantiate all the objects to pool
        for (int i = 0; i < amountToPool; i++)
        {
            obj = Instantiate(objectToPool);

            //set object to inactive
            obj.SetActive(false);
            // obj.tag = "Pooled Tile";
            //obj.transform.SetParent(GameObject.Find("Pool").transform);
            pooledObjects.Add(obj);


        }
    }


}
