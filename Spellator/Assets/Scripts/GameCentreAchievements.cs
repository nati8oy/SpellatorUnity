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

        ShowAchievements();
    }

    public void ShowAchievements()
    {
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

        //check for 25 words
        if (saveLoad.uniqueWordAmount >= 25)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792029", 100, (result) => {

               // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 50 words
         if (saveLoad.uniqueWordAmount >= 50)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792030", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 100 words
        if (saveLoad.uniqueWordAmount >= 100)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792031", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 250 words
        if (saveLoad.uniqueWordAmount >= 250)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792032", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 500 words
        if (saveLoad.uniqueWordAmount >= 500)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792033", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        // check for 1000 words
        if (saveLoad.uniqueWordAmount >= 1000)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70791927", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }



    }

}
