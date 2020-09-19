using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelCompleteActions : MonoBehaviour
{

    public LevelManagerSO levelData;
    public AudioSO audioManager;
    private AudioClip starSound;
    private int starPositionCalculator;
    private float AppearDelay;
    public Slider progressSlider;
    public ConfigSO configData;
    public Transitions fadeManager;
    public Transform goldMovePoint;
    public TutorialSO tutorial;
    public TextMeshProUGUI tipText;
    public int totalLevelXP;
    public int localLevelProgressXP;
    public int currentLevel;
    public Camera mainCamera;

    public TextMeshProUGUI totalGoldAmount;

    public GameObject coinStartPos;
    public GameObject coinEndPos;



    private GameObject goldCoinObject;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI wordsMadeText;
    public TextMeshProUGUI nextLevelTally;

    public GameObject[] remainingTiles;

    public int wordsMade;

    private void Start()
    {
        //set the star sound to be a variable
        starSound = audioManager.sfxGeneral[14];
        //starPositionCalculator = 0;
        AppearDelay = 0.3f;
        wordsMade = 0;

        //Debug.Log("Current XP: " + configData.levelProgressXP);
        //localLevelProgressXP = configData.levelProgressXP;

    }

    private void Update()
    {
        //keep the amount of gold displayed updated
        totalGoldAmount.text = configData.totalGoldAmount.ToString();

        //if the value of the slider matches that of the level then play a sound and check the level to update it.
        if (progressSlider.value == progressSlider.maxValue)
        {

            GameEvents.OnLevelUpInitiated();

            //progressSlider.value = currentLevel =
            CheckLevel();
            //progressSlider.value += 1;
        }
    }

    private void OnEnable()
    {
        //add the DisplayLevelUp function to the LevelUp game events
        GameEvents.LevelUp += DisplayLevelUp;

        

        CheckLevel();

        //assign a variable for the config data XP progress

//        Debug.Log("level progress XP is " + configData.levelProgressXP);
        //localLevelProgressXP = configData.levelProgressXP;


        //localLevelProgressXP = configData.levelProgressXP + Points.totalScore;


        localLevelProgressXP = configData.levelProgressXP + Points.totalScore;
        Debug.Log("Current XP: " + configData.levelProgressXP + " XP earned: " + Points.totalScore);

        totalLevelXP = configData.levelProgressXP;
        //grab the reward value from the SO
        StartCoroutine(LevelCompleteCheck(levelData.reward));
        StartCoroutine(CountUpWords());

        progressSlider.maxValue = currentLevel;

        fadeManager = GameObject.Find("Fade Manager").GetComponent<Transitions>();
        fadeManager.FadeType(fadeManager._flashColour, fadeManager.pulseSpeed);

        //randomly show a tip from the tutorial scriptable object
        tipText.text = tutorial.endOfLevelTips[Random.Range(0, tutorial.endOfLevelTips.Length)];


        //set the slider to be the value of level XP from the SO
        //progressSlider.value = configData.levelProgressXP;
        progressSlider.value = localLevelProgressXP - Points.totalScore;

        //set the levelProgressXP straight away so that it's saved
        configData.levelProgressXP = localLevelProgressXP;

        //set the display of the level tally
        //nextLevelTally.text = progressSlider.value.ToString() + " / " + progressSlider.maxValue.ToString();

    }

    //coroutine to count down the star reward for each level
    public IEnumerator LevelCompleteCheck(int goldEarned)
    {

        while (goldEarned>0)
        {
            goldEarned -= 1;
//            AudioManager.Instance.PlayAudio(starSound);

           
            goldCoinObject = ObjectPooler.SharedInstance.GetPooledObject("Gold");
            if (goldCoinObject != null)
            {
                /*
                //set the start position var for the star being loaded
                var startPosY = goldMovePoint.position.y;
                var coinStartX = goldMovePoint.position.x;
                var coinStartY = goldMovePoint.position.y;


                goldCoinObject.transform.position.y = startPosY;
                */




                //parent it to the rewardText game object so that it's visible as a UI element
                goldCoinObject.transform.SetParent(coinStartPos.transform);

                goldCoinObject.transform.position = coinStartPos.transform.position;

                //update the position of the upcoming star
                starPositionCalculator += 70;
                //set the gameobject to be active
                goldCoinObject.SetActive(true);
            }

            iTween.MoveTo(goldCoinObject, iTween.Hash("y", coinEndPos.transform.position.y, "x", coinEndPos.transform.position.x, "easetype", "EaseOutQuad", "time", 1f));

           /// coinEndPos += 15;


            //delay before the next star is added.
            yield return new WaitForSeconds(AppearDelay);
        }


        yield return new WaitForSeconds(1);
        goldCoinObject.SetActive(false);

        yield return null;

    }

    //add the number of unique words made to the level complete screen.
    public IEnumerator CountUpWords()
    {
        while (wordsMade!=GameManager.Instance.newWordCounter)
        {
            wordsMade += 1;
            wordsMadeText.text = GameManager.Instance.newWordCounter.ToString();

            //delay before the next star is added.
            yield return new WaitForSeconds(AppearDelay);
        }

        //progress slider code
        while ((progressSlider.value != (localLevelProgressXP)) &&(progressSlider.value<progressSlider.maxValue))
        {
            progressSlider.value += 2f;
            localLevelProgressXP += 1;
            

            AudioManager.Instance.PlayAudio(audioManager.sfxTilePops[4]);

            //add to the overall level XP 
            totalLevelXP += 1;

            nextLevelTally.text = progressSlider.value.ToString() + " / " + progressSlider.maxValue.ToString();
           // Debug.Log("progress: " + progressSlider.value);
            yield return new WaitForSeconds(0.05f);

        }
        Points.totalScore = 0;
        
        yield return null;

    }

    public void CheckLevel()
    {
        if (configData.levelProgressXP <= configData.levelXP[0])
        {
            Debug.Log("Current Level XP: " + currentLevel);
        }


        else if ((configData.levelProgressXP > configData.levelXP[0]) && (configData.levelProgressXP < configData.levelXP[1]))
        {
            currentLevel = configData.levelXP[1];
            progressSlider.maxValue = configData.levelXP[1];
        }
        else if ((configData.levelProgressXP > configData.levelXP[1]) && (configData.levelProgressXP < configData.levelXP[2]))
        {
            currentLevel = configData.levelXP[2];
            progressSlider.maxValue = configData.levelXP[2];
        }
        else if ((configData.levelProgressXP > configData.levelXP[2]) && (configData.levelProgressXP < configData.levelXP[3]))
        {
            currentLevel = configData.levelXP[3];
            progressSlider.maxValue = configData.levelXP[3];
        }
        else if ((configData.levelProgressXP > configData.levelXP[3]) && (configData.levelProgressXP < configData.levelXP[4]))
        {
            currentLevel = configData.levelXP[4];
            progressSlider.maxValue = configData.levelXP[4];
        }


    }


    public void DisplayLevelUp()
    {
        AudioManager.Instance.PlayAudio(audioManager.sfxGeneral[5]);

        Debug.Log("level up!");
        GameEvents.LevelUp -= DisplayLevelUp;

    }


}
