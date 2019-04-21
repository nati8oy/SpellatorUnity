using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class EnergyBar : MonoBehaviour
{
    private float timeLeft; //Seconds Overall

    public static EnergyBar Instance;
    private float percentRemaining;
    public int bonusPoints = 500;
    private int bonusAwarded;

    [SerializeField] private Image bar;


    //the timer number of seconds is controlled using GameManager.Instance.SetTimerTo;

   // public Text countdown; //UI Text Object
    void Start()
    {
        timeLeft = 60;
        StartCoroutine(LoseTime(timeLeft));
        Time.timeScale = 1; //Just making sure that the timeScale is right

       
    }
    void Update()
    {
        //countdown.text = ("" + timeLeft); //Showing the Score on the Canvas


    }
    //Simple Coroutine
    IEnumerator LoseTime(float timeRemaining)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            timeRemaining--;
            percentRemaining = timeRemaining / 60;
            Debug.Log("Percent Remaining: "+percentRemaining);
            bar.transform.localScale = new Vector3(percentRemaining, bar.transform.localScale.y);


            bonusAwarded = Mathf.RoundToInt(bonusPoints * percentRemaining);
            Debug.Log("Bonus Remaining: "+ bonusAwarded);



            if (timeRemaining <= 0)
            {
                StopCoroutine("LoseTime");

                GameManager.Instance.GameOverMethod();
                //Debug.Log("Game over man! Game over!");
                 }
        }

       
    }

    public void ResetBonus()
    {
      
        StopCoroutine("LoseTime");
        bonusPoints = 500;
        timeLeft = 60;
        StartCoroutine(LoseTime(timeLeft));

       
    }

}