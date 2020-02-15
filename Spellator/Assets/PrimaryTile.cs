using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryTile : MonoBehaviour
{
    public ParticleSystem pointParticles;
    public int maximumParticles;
    public int particleSizes;


    void Start()
    {

    }

    void Update()
    {
        var main = pointParticles.main;
        //set the max number of particles;
        main.maxParticles = maximumParticles;
    }
}
