using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLoader : MonoBehaviour
{
    public AchievementSO achievementsToLoad;
    public ConfigSO configSO;
    // Start is called before the first frame update
    void Start()
    {
        achievementsToLoad.checkAchievements();

        for (int i = 0; i < achievementsToLoad.achievements.Count; i++)
        {
            //Debug.Log(achievementsToLoad.achievements.Count);
            if (configSO.uniqueWordsList.Count == 10)
            {
                Debug.Log("10 achievement active");
                
            }

            if (configSO.uniqueWordsList.Count == 20)
            {
                Debug.Log("20 achievement active");
            }

        }
    }

}
