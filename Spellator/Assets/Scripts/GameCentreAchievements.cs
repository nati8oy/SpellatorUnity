using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCentreAchievements : MonoBehaviour
{

    public GameConfig gameConfig;
    public SaveLoadManager saveLoad;

    // Start is called before the first frame update
    void Start()
    {
        Social.localUser.Authenticate(success => {
            if (success)
                ReportAchievement();
            else
                Debug.Log("Failed to authenticate");
        });


        Social.LoadAchievements(achievements => {
            if (achievements.Length > 0)
            {
                Debug.Log("Got " + achievements.Length + " achievement instances");
                string myAchievements = "My achievements:\n";
                foreach (IAchievement achievement in achievements)
                {
                    myAchievements += "\t" +
                        achievement.id + " " +
                        achievement.percentCompleted + " " +
                        achievement.completed + " " +
                        achievement.lastReportedDate + "\n";
                }
                Debug.Log(myAchievements);
            }
            else
                Debug.Log("No achievements returned");
        });

        Social.ShowAchievementsUI();

    }

    public void ReportAchievement()
    {
        if (saveLoad.longestWord.Length > 4)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70790857", 100, (result) => {

                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }


       
    }

}
