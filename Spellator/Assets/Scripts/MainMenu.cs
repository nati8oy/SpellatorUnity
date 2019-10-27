using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private Scene scene;
    public ConfigSO configData;


//    [SerializeField] private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(configData.longestWord);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("DefaultGameMode", LoadSceneMode.Single);
    }
}
