using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Messages
{
   // private GameObject endPos;
    // Start is called before the first frame update
    void Start()
    {
        // endPos = GameObject.Find("Score");

        base.Start();
        //Destroy(gameObject, 2f);
        StartCoroutine(Move(endPos.transform.position));
        messageText.text = "+ " + GameManager.Instance.LiveScore.ToString();

    }

    // Update is called once per frame
    protected override void Update()
    {
     //   base.Update();
    }
}
