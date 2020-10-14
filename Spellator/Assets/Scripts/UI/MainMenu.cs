using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private Scene scene;
    public ConfigSO configData;

    public GameObject modeSelectPanel;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("DefaultGameMode", LoadSceneMode.Single);
    }

    //shows the game mode selection panel
    public void DisplayGameModePanel(string onOff)
    {
        if (onOff == "show")
        {
            modeSelectPanel.SetActive(true);
        } else
        {
            modeSelectPanel.SetActive(false);
        }            
    }


}
