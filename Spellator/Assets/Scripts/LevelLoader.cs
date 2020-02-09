using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public LevelChanger levelChanger;

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
            // progressText.text = progress * 100 + "%";
            progressText.text = Mathf.RoundToInt(progress*100) + "%";

            //Debug.Log("loading data: " + progress);
            yield return null;
//            Debug.Log("it did fade...");
            levelChanger.FadeToLevel(0);
        }
        //

    }
}
