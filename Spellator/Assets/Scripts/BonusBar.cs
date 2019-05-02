using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class BonusBar : MonoBehaviour
{
    private float timeLeft; //Seconds Overall

    public static BonusBar Instance;
    private float percentRemaining;

    private float timerSpeed = 0.2f;

    public int remainingBonusPoints;

    //total points awarded after making the word
    private int bonusAwarded;

    public int BonusAwarded
    {
        get {return bonusAwarded; }
    }

    //total bonus points to start counting down from
    public int bonusPoints = 100;

    private bool bonusReset;


    [SerializeField] private Image bar;


    //the timer number of seconds is controlled using GameManager.Instance.SetTimerTo;

   // public Text countdown; //UI Text Object
    void Start()
    {
        timeLeft = 60;
        StartCoroutine("LoseTime", timeLeft);
        Time.timeScale = 1; //Just making sure that the timeScale is right

       
    }
    void Update()
    {

    }

    IEnumerator LoseTime(float timeRemaining)
    {

       
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(timerSpeed);
            timeRemaining--;
            percentRemaining = timeRemaining / 60;
            //Debug.Log("Percent Remaining: "+percentRemaining);
            bar.transform.localScale = new Vector3(percentRemaining, bar.transform.localScale.y);

            bonusAwarded = Mathf.RoundToInt(bonusPoints * percentRemaining);
            Debug.Log("Bonus Remaining: " + bonusAwarded);


        }
        

        StopCoroutine("LoseTime");
        //ResetBonus();
       
        Debug.Log("Coroutine stopped");
      //  StartCoroutine(LoseTime(timeLeft));


    }

    public void ResetBonus()
    {

        bonusPoints = bonusAwarded;
        StopCoroutine("LoseTime");
        //Debug.Log("this ran");

        bonusPoints = 100;
        timeLeft = 60;
        StartCoroutine("LoseTime", timeLeft);






    }

}