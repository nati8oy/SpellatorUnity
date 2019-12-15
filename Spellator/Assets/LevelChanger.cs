using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public LevelChanger Instance;

    private int levelToLoad;
    public Animator animator;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
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
        Debug.Log("faded to level");

        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
