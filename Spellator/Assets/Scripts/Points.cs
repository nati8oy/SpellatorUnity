using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Messages
{

  // private ParticleSystem pe;
    // Start is called before the first frame update
    void Start()
    {


        base.Start();
      
        StartCoroutine(Move(endPos.transform.position));
        messageText.text = "+ " + GameManager.Instance.mostRecentScore.ToString();
        messageText.color = red;

    }

}
