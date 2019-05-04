using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{


    public Color red;
    //[SerializeField] public Transform target;
    public Transform endPos;
    [SerializeField] public Text messageText;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;
    public float lifetime = 1.2f;


    public virtual void Start()
    {
        red = Color.white;
        Destroy(gameObject, lifetime);
        endPos = GameObject.Find("Score").transform;

    }

    protected virtual void Update()
    {

    }

}
