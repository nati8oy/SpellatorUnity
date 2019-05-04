using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScripts : MonoBehaviour
{

   
    private float yVelocity = 0.0f;
    private float smoothTime = 0.3f;

    public IEnumerator LerpFromAtoB(Transform target, Vector3 startPosition, Vector3 endPosition)
    {
        // Debug.Log("coroutine started");
        while (Vector3.Distance(startPosition, endPosition) > 0.05f)
        {

            transform.position = Vector3.Lerp(startPosition, endPosition, smoothTime * Time.deltaTime);

            yield return null;
        }

    }


    public IEnumerator Move(Vector3 target, Transform startPosition, Transform endPosition)
    {
        while (Mathf.Abs((target - startPosition.localPosition).y) > 0.20f)
        {

            float newPosition = Mathf.SmoothDamp(startPosition.position.x, endPosition.position.x, ref yVelocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition);

            yield return null;

        }

    }
}
