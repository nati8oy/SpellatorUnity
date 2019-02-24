using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{

    //[SerializeField] public Transform target;
    public Transform endPos;
    [SerializeField] public Text messageText;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    public virtual void Start()
    {
        Destroy(gameObject, 1.2f);
        endPos = GameObject.Find("Score").transform;

    }

    protected virtual void Update()
    {

    }


  public IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {

            float newPosition = Mathf.SmoothDamp(transform.position.y, endPos.transform.position.y, ref yVelocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition);

            yield return null;

        }
        
    }
}
