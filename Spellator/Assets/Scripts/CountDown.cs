using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour
{
    private int timeLeft; //Seconds Overall

    //the timer number of seconds is controlled using GameManager.Instance.SetTimerTo;

    public Text countdown; //UI Text Object
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right

        timeLeft = GameManager.Instance.SetTimerTo;
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;

            if (timeLeft == 0)
            {
                StopCoroutine("LoseTime");

                GameManager.Instance.GameOverMethod();
                //Debug.Log("Game over man! Game over!");
                 }
        }

       
    }
 
}