using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimerOnUpdate : MonoBehaviour
{
    float timeLeft = 300.0f;

    public Text text;



    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("gameOver");
        }
    }
}