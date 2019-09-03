using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleParticleEffect : ParticleEvent
{
    public Material particleMaterial;

    public override void PlayPS(ParticleSystem ps)
    {
        ps.Play();

    }
}
