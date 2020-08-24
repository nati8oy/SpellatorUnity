using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    public LevelClass levelSetup;
    public LevelManagerSO levelDetails;
    public GameConfig gameConfig;
    public TextMeshProUGUI levelDescriptionText;
    public string randomLevelSelection;

    public GameObject[] currentRack;

    public DifficultyGradientSO difficulty;

    public enum LevelRuleType
    {
        length, ending, containing, starting, points, tiles, tileCount
    }

    public LevelRuleType levelRuleType; 

    public static int currentLevel;
    public List<int> allLevels = new List<int>();
    public List<string> _levelTypes = new List<string>();

    public static string levelDescription;

    public string lastLetter;
    public string firstLetter;


    ///Various subsets of letters for use with level rules below
    public List<string> _endingList = new List<string>();
    public List<string> _startingList = new List<string>();
    public List<string> _containingList = new List<string>();

    public bool _levelComplete;


    //this flag is used to see if there has been a tile that matches the "containing" or "starting" condition.
    //it's used so that the levelmanager can check if the tile type matches. If it does, then you can flick it off.
    public static bool tileSpawnFlag;

    //sets the list for the int conditions below
    public List<int> conditionsList = new List<int>();

    //used for conditions containing ints (eg. word length)
    public static int firstCondition;
    public static int secondCondition;


    //used for conditions requiring strings (containg, etc.)
    public static string letterCondition;
    public static int pointsThreshold;


    public int numberOfConditions;


    //reward for complettion of the level
    public int reward;


    public TileBag tileBag;



    [Header("Level Theme")]
    public Image bgImage;

    public LevelTheme levelTheme;
    public Camera mainCamera;
    public AudioSO audioObject;
    public AudioClip bgMusic;


    //set up singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;



        numberOfConditions = 4;

        //add the first condition to the rule
        for (int i = 0; i < numberOfConditions; i++)
        {
            conditionsList.Add(i);
        }

        //load data to choose the type of level from the SO
        _levelTypes = levelDetails.levelTypes;


        //set up lists to select from scriptable object
        _endingList = levelDetails.endingList;
        _startingList = levelDetails.startingList;
        _containingList = levelDetails.containingList;
        //_levelComplete = levelDetails.levelComplete;

        //set the level complete to be "false". This is so that we can trigger the game over animations,etc.
        levelDetails.levelComplete = false;

        //RANDOM VERSION
        randomLevelSelection = _levelTypes[Random.Range(0, _levelTypes.Count)];


    }

    // Start is called before the first frame update
    void Start()
    {
        LevelThemeManager();


        

        //set up the levels via the function below
        SetLevels();

        //this looks at the LevelRuleType enum value and creates the appropriate bag style for them.
        switch (levelRuleType)
        {
            case LevelRuleType.containing:
                tileBag = new TileBag(55, 40, 18);
                //choose the music from the audio object scriptable object
                bgMusic = audioObject.musicBackgroundMusic[1];
                break;

            case LevelRuleType.starting:
                tileBag = new TileBag(55, 40, 18);
                bgMusic = audioObject.musicBackgroundMusic[1];
                break;
            case LevelRuleType.tiles:
                tileBag = new TileBag(55, 40);
                bgMusic = audioObject.musicBackgroundMusic[2];
                break;
            case LevelRuleType.length:
                tileBag = new TileBag(55, 40);
                bgMusic = audioObject.musicBackgroundMusic[4];
                break;
            case LevelRuleType.points:
                tileBag = new TileBag(55, 40);
                bgMusic = audioObject.musicBackgroundMusic[5];
                break;
                //this is the limited version of the game with a st number of tiles.
                //this constructor adds the tile number as the last one here
            case LevelRuleType.tileCount:
                bgMusic = audioObject.musicBackgroundMusic[0];
                tileBag = new TileBag(true, 55, 40, 100);
                break;
        }


        //set the audio source audio clip
        mainCamera.GetComponent<AudioSource>().clip = bgMusic;
        //play the audio clip via the source
        mainCamera.GetComponent<AudioSource>().Play();
        //loop the music
        mainCamera.GetComponent<AudioSource>().loop = true;

        //        Debug.Log("You are playing level " + levelDetails.currentLevel);



        /*
        //set the letter in the difficulty SO so that it's available at the start of each level

        difficulty.focusLetter = letterCondition;
        Debug.Log("letter condition is: " + letterCondition);
        */

        //SET VERSION
        //sets up the level parameters. eg. make 3 words that are 3 letters long.
        //ConstructLevelParams(randomLevelSelection);

    }

    //this function manages the themes for the point screen and the backgrounds
    public void LevelThemeManager()
    {
        // bgImage.sprite = levelTheme.bgImage[Random.Range(0,2)];
        


        
        


    }


    public void SetLevels()
    {
        switch (levelDetails.currentLevel)
        {
            case 1:
                /*
                //make 2 x words containing "letter"
                levelRuleType = LevelRuleType.containing;
                ConstructLevelParams("containing", 3, 2, 0);
                break;
                */
                //use 10 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 10, 0, 0);
                bgImage.sprite = levelTheme.bgImage[0];

                break;

            case 2:
                //use 25 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 25, 0, 0);
                bgImage.sprite = levelTheme.bgImage[0];

                break;

            case 3:
                //make 10 x 3 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 10, 3, 0);
                bgImage.sprite = levelTheme.bgImage[0];

                break;

            case 4:
                //make 4 x 4 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 4, 0);
                bgImage.sprite = levelTheme.bgImage[0];

                break;
        
            case 5:
                //use 40 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 40, 0, 0);
                bgImage.sprite = levelTheme.bgImage[1];

                break;
            case 6:
                //use 60 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 60, 0, 0);
                bgImage.sprite = levelTheme.bgImage[1];
                break;

            case 7:
                //make 2 x words starting with "letter"
                levelRuleType = LevelRuleType.starting;
                ConstructLevelParams("starting", 3, 2, 0);
                bgImage.sprite = levelTheme.bgImage[1];
                break;
            case 8:
                //make 2 words worth 10XP 
                levelRuleType = LevelRuleType.points;
                ConstructLevelParams("points", 2, 0, 10);
                bgImage.sprite = levelTheme.bgImage[1];
                break;

            case 9:
                //make 5 x 4 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 5, 4, 0);
                bgImage.sprite = levelTheme.bgImage[1];
                break;

            case 10:
                //make 2 x 5 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 2, 5, 0);
                bgImage.sprite = levelTheme.bgImage[2];
                break;
           
            case 11:
                // make 2 words worth 20XP
                 levelRuleType = LevelRuleType.points;
                ConstructLevelParams("points", 2, 0, 20);
                bgImage.sprite = levelTheme.bgImage[2];
                break;

            case 12:
                //make 2 x 6 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 2, 6, 0);
                bgImage.sprite = levelTheme.bgImage[2];
                break;

            case 13:
                //make 2 x words containing "letter"
                levelRuleType = LevelRuleType.containing;
                ConstructLevelParams("containing", 3, 2, 0);
                bgImage.sprite = levelTheme.bgImage[2];
                break;
         
            case 14:
                //make 4 x words starting with "letter"
                levelRuleType = LevelRuleType.starting;
                ConstructLevelParams("starting", 3, 4, 0);
                bgImage.sprite = levelTheme.bgImage[2];
                break;

            case 15:
                //use 75 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 75, 0, 0);
                bgImage.sprite = levelTheme.bgImage[3];
                break;
            case 16:
                //use 60 tiles
                levelRuleType = LevelRuleType.tiles;
                ConstructLevelParams("tiles", 75, 0, 0);
                bgImage.sprite = levelTheme.bgImage[3];
                break;

            case 17:
                //make 3 x 5 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 5, 0);
                bgImage.sprite = levelTheme.bgImage[3];
                break;

            case 18:
                //make 3 x 6 letter words
                levelRuleType = LevelRuleType.length;
                ConstructLevelParams("length", 3, 6, 0);
                bgImage.sprite = levelTheme.bgImage[3];
                break;



        }

    }

    //gets all the letter values of the tiles on the rack and puts them into "currentRack"
    public IEnumerator GetTilesOnRack(string levelType)
    {

        yield return new WaitForSeconds(0.5f);

        //set the currentRack array to be the tile 
        currentRack = GameObject.FindGameObjectsWithTag("Tile");

//        Debug.Log("Coroutine started");
        //        Debug.Log("current rack contains " + currentRack.Length + " tiles");


        //check that the rack tile letter isn't "focus letter".
        //Also check the level type doesn't equal "points". The reason being that any other type of level rule will require a specific letter to be available

        //check if the rule is "points"
        if (levelType != "points")
        {

            //check if the letter is the one from the level rule
            if (currentRack[0].GetComponent<Tile>().letter.text != difficulty.focusLetter)
            {
                currentRack[0].GetComponent<Tile>().letter.text = difficulty.focusLetter;
                //currentRack[0].GetComponent<Tile>().spawnedTile.points = TileBag.pointsDictionary[currentRack[0].GetComponent<Tile>().spawnedTile.letter];
               // currentRack[0].GetComponent<Tile>().spawnedTile.points = difficulty.focusLetterPoints;
                //currentRack[0].GetComponent<Tile>().spawnedTile.points = TileBag.pointsDictionary[difficulty.focusLetter];

            }
        }
         

        yield return null;

    }


    // Update is called once per frame
    void Update()
    {
        //this is the data from the level
        levelDescriptionText.text = levelDescription;
        levelDetails.levelRules = levelDescription;


    }



    //set up the rules for the level
    public void ConstructLevelParams(string levelType, int numberOfWords, int minWordLength, int pointsRequired)
    {
        //this sets the max number of letters in a word
        //secondCondition = conditionsList[Random.RandomRange(3, conditionsList.Count)]; ;
        secondCondition = minWordLength;


        //choose the second condition randomly from the list
        //Debug.Log("Second condition updated: " + secondCondition);

        //choose the first condition randomly from the list
        //firstCondition = conditionsList[Random.RandomRange(1, conditionsList.Count)];
        firstCondition = numberOfWords;



        //check if the letter is on the rack or not.
        StartCoroutine(GetTilesOnRack(levelType));

        switch (levelType)
        {

            case "tiles":
                levelDescription = "Make words using " + firstCondition.ToString() + " tiles in total"; 
                break;

            case "length":
                levelDescription = "Make " + firstCondition.ToString() + "x " + secondCondition.ToString() + " letter words";

                break;

            case "ending":

                //choose the letter randomly
                letterCondition = _endingList[Random.Range(0, _endingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words ending in " + letterCondition;
                difficulty.focusLetter = letterCondition;
               // difficulty.focusLetterPoints = TileBag.pointsDictionary[letterCondition];

                break;

            case "containing":

                //choose the letter randomly
                letterCondition = _containingList[Random.Range(0, _containingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words containing " + letterCondition;
                difficulty.focusLetter = letterCondition;
               // difficulty.focusLetterPoints = TileBag.pointsDictionary[letterCondition];

                break;

            case "starting":

                //choose the letter randomly
                letterCondition = _startingList[Random.Range(0, _startingList.Count)];

                levelDescription = "Make " + firstCondition.ToString() + " words starting with " + letterCondition;
                difficulty.focusLetter = letterCondition;
                //difficulty.focusLetterPoints = TileBag.pointsDictionary[letterCondition];

                break;
            case "points":

                //set the amount of points required to finish this level
                pointsThreshold = pointsRequired;
               // Debug.Log(levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsRequired + " points or more");

                levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsRequired + " points or more" ;

                break;

        }


        //set the level type for the Inumerator so that it can use the string and make sure there is a letter of that type on the rack
       // GetTilesOnRack(levelType);
        



    }

    public void LevelGoalCheck(string wordToCheck, string checkCriteria)
    {

        switch (checkCriteria)
        {

            case "tiles":

                 
                foreach(char letter in wordToCheck)
                {
                    //Debug.Log("1 point added");
                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;

                    }
                }

                levelDescription = firstCondition.ToString() + " tiles left to play";


                break;


            case "length":
                  //Debug.Log(firstCondition + " words remaining!");

                if (wordToCheck.Length == secondCondition)
                {
                    //reduce the first condition by one (track changes to quota essentially) 
                    //but only minus if the firstCondition is greater than 0
                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;

                    }
                    //Debug.Log("length rule matched! " + firstCondition + " words remaining");
                }

                levelDescription = "Make " + firstCondition.ToString() + " words using " + secondCondition.ToString() + " letters";


                break;
            case "ending":

                //Debug.Log("letter condition: " + letterCondition);


                //split the lettters in the wordToCheck string and grab the last one
                //
                string[] endingCharacters = new string[wordToCheck.Length];
                for (int i = 0; i < wordToCheck.Length; i++)
                {

                    endingCharacters[i] = System.Convert.ToString(wordToCheck[i]);

                    //gets the start letter of the next word from the most recent word
                    lastLetter = endingCharacters[i];
                     //Debug.Log("Last letter: "+lastLetter);

                }

                //Debug.Log("letter condition: " + letterCondition + " last letter: " + lastLetter);

                if (letterCondition == lastLetter)
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words ending in " + letterCondition;

                    }


                    // Debug.Log("ending rule matched! " + firstCondition + " words remaining");
                }



                break;
            case "containing":

                if (wordToCheck.Contains(letterCondition))
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words containing " + letterCondition;

                    }


                }

                break;

            case "starting":
                //split the lettters in the wordToCheck string and grab the last one
                //
                string[] startingCharacters = new string[wordToCheck.Length];
                for (int i = 0; i < wordToCheck.Length; i++)
                {

                    startingCharacters[i] = System.Convert.ToString(wordToCheck[i]);

                    //gets the start letter of the next word from the most recent word
                    firstLetter = startingCharacters[0];

                }


                if (letterCondition == firstLetter)
                {

                    if (firstCondition > 0)
                    {

                        firstCondition -= 1;
                        levelDescription = "Make " + firstCondition.ToString() + " words starting with " + letterCondition;

                    }


                     //Debug.Log("ending rule matched! " + firstCondition + " words remaining");
                }

                break;

            case "points":
                if (Points.pointsScored >= pointsThreshold)
                {
                    firstCondition -= 1;

                    levelDescription = "Make " + firstCondition.ToString() + " words worth " + pointsThreshold + " points or more";

                    ///Debug.Log("First condition is " + firstCondition);

                }
                break;
        }



        //if the first condition is met (how many words required) then the level is complete
        if(firstCondition==0)
        {
            GameManager.Instance.StartCoroutine(GameManager.Instance.LevelComplete());
            //GameManager.Instance.LevelComplete();
            levelDetails.levelComplete = true;
            //Debug.Log("Level has been completed");

            //if you passed the level then increment the level

            //update the current level. This is set within the gameConfig file
            if (levelDetails.currentLevel < 18)
            {
                levelDetails.currentLevel += 1;
            }

        }


    }

}
