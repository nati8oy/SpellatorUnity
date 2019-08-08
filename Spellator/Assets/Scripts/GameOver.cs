using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] private Text Score;
    [SerializeField] private Text WordsMade;

    // Start is called before the first frame update
    void Start()
    {
        Score.text = Points.totalScore.ToString();
        WordsMade.text = DictionaryManager.Instance.TotalWordsMade.ToString();
       // BlueDots.text = GameManager.Instance.BlueTotal.ToString();
     //   RedDots.text = GameManager.Instance.RedTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
