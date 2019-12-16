using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public LevelChanger Instance;

    private int levelToLoad;
    public Animator animator;


   // public Button startButton;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
//        startButton.onClick.AddListener(delegate { FadeToLevel(1); });

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            FadeToLevel(1);
        }

    }
    

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

        //Debug.Log("faded to level with the levelIndex of "  +   levelIndex) ;
        //Debug.Log("level to load " + levelToLoad);


    }

    public void OnFadeComplete()
    {
        Debug.Log("Level Loaded");
        SceneManager.LoadScene(levelToLoad);

    }

    public void LoadLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
       //animator.SetTrigger("StartFade");
        SceneManager.LoadScene(levelIndex);
    }
}
