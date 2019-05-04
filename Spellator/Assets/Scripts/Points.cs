using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Messages
{

    // Start is called before the first frame update
    void Start()
    {


        base.Start();

        iTween.PunchScale(gameObject, iTween.Hash("easeType","EaseOutQuad","y", 1.05f, "time", 0.6f));
        iTween.MoveTo(gameObject, iTween.Hash("easeType", "EaseOutQuint", "y", gameObject.transform.position.y + 400, "time", lifetime));

        messageText.text = "+ " + GameManager.Instance.mostRecentScore.ToString();
        messageText.color = red;

    }

}
