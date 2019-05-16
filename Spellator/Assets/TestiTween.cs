using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomMove()
    {

        iTween.MoveTo(gameObject, iTween.Hash("x", Random.Range(550, 557), "y", Random.Range(1375, 1368), "time", 2, "oncomplete", "RandomMove"));
    }
}
