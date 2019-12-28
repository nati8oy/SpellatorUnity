using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteActions : MonoBehaviour
{

    public LevelManagerSO levelData;
    public AudioSO audioManager;
    private AudioClip starSound;

    private void Start()
    {
        starSound = audioManager.sfxGeneral[14];
    }

    private void OnEnable()
    {
        //grab the reward value from the SO
        StartCoroutine(LevelCompleteCheck(levelData.reward));
    }

    //coroutine to count down the star reward for each level
    public IEnumerator LevelCompleteCheck(int starsEarned)
    {

        while (starsEarned>0)
        {
            starsEarned -= 1;
            AudioManager.Instance.PlayAudio(starSound);

            
            Debug.Log("stars remaining " + starsEarned);
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
