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
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnEnable()
    {
        GameManager.Instance.GetComponent<GameState>().SaveGameData();
    }
}
