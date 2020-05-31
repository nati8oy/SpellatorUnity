using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCentreAchievements : MonoBehaviour
{

    public GameConfig gameConfig;
    public ConfigSO configData;
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
        //check for 25 words
        if (configData.uniqueWordsList.Count >= 10)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70790857", 100, (result) => {

                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        //check for 25 words
        if (configData.uniqueWordsList.Count >= 25)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792029", 100, (result) => {

               // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 50 words
         if (configData.uniqueWordsList.Count >= 50)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792030", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 100 words
        if (configData.uniqueWordsList.Count >= 100)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792031", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 250 words
        if (configData.uniqueWordsList.Count >= 250)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792032", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
        // check for 500 words
        if (configData.uniqueWordsList.Count >= 500)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70792033", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }

        // check for 1000 words
        if (configData.uniqueWordsList.Count >= 1000)
        {
            GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
            Social.ReportProgress("70791927", 100, (result) => {

                // Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }



    }

}
