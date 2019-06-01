using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMessagesInactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Messages.startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateMessage()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = Messages.startPos;
    }

}
