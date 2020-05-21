using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
