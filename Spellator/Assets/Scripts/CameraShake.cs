using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour
{

    public void ShakeDatAss()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.2f);

            Debug.Log("button pressed");
        }
    }
}
