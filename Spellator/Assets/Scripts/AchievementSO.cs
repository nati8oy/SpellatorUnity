using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement data", menuName = "Achievement SO")]

public class AchievementSO : ScriptableObject
{

    public List<int> achievements;

    public void checkAchievements()
    {
        for (int i = 0; i < achievements.Count; i++)
        {

            switch (achievements[i])
            {
                case 10 :
                 Debug.Log("10 words made achievement");
                    break;
                case 20:
                    Debug.Log("10 words made achievement");
                    break;
                case 30:
                    Debug.Log("10 words made achievement");
                    break;
                case 40:
                    Debug.Log("10 words made achievement");
                    break;
            }
        }
    }
}
