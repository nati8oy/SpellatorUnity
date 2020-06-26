using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartParticlesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        KillParticles();

    }

    IEnumerator KillParticles()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
