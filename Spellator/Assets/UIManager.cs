using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject wordList;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
     
    }

    // Start is called before the first frame update
    void Start()
    {

        //set up the game over panel

        GameObject obj = Instantiate(gameOverMenu);
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
