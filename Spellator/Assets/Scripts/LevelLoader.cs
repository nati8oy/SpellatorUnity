﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider; 

    public void LoadLevel(int sceneIndex)
    
    {
        StartCoroutine(LoadAsyncronously(sceneIndex));
    }

    private IEnumerator LoadAsyncronously(int sceneIndex) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            //Debug.Log("loading data: " + progress);
            yield return null;
        }
        //

    }
}
