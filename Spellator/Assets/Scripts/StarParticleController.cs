using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticleController : MonoBehaviour
{

    private void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            gameObject.SetActive(false);
            //Debug.Log("particles!");
        }
    }
    
    
}
