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
    private float starAppearDelay;

    private GameObject starObject;
    public TextMeshProUGUI rewardText;

    private void Start()
    {
        //set the star sound to be a variable
        starSound = audioManager.sfxGeneral[14];
        //starPositionCalculator = 0;
        starAppearDelay = 0.1f;
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

           
            starObject = ObjectPooler.SharedInstance.GetPooledObject("Star");
            if (starObject != null)
            {

                //set the start position var for the star being loaded
                var starPos = new Vector3((Screen.width / 3)+ starPositionCalculator, Screen.height / 2);
                starObject.transform.position = starPos;
                //parent it to the rewardText game object so that it's visible as a UI element
                starObject.transform.SetParent(rewardText.transform);

                //update the position of the upcoming star
                starPositionCalculator += 70;
                //set the gameobject to be active
                starObject.SetActive(true);

            }


            //delay before the next star is added.
            yield return new WaitForSeconds(starAppearDelay);
        }

        yield return null;
    }
}
