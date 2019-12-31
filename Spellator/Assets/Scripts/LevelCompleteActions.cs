using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleteActions : MonoBehaviour
{

    public LevelManagerSO levelData;
    public AudioSO audioManager;
    private AudioClip starSound;
    private int starPositionCalculator;

    private GameObject starObject;
    public TextMeshProUGUI rewardText;

    private void Start()
    {
        //set the star sound to be a variable
        starSound = audioManager.sfxGeneral[14];
        starPositionCalculator = 0;
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


            starObject = ObjectPooler.SharedInstance.GetPooledObject("Star");
            if (starObject != null)
            {
                
                var starPos = new Vector3((Screen.width / 3)+ starPositionCalculator, Screen.height / 2);
                starObject.transform.position = starPos;
                starObject.transform.SetParent(rewardText.transform);


                starPositionCalculator += 70;
                starObject.SetActive(true);

            }



            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
}
