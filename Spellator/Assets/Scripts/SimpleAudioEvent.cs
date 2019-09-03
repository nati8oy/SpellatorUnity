using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Simple Audio", menuName = "Simple Audio")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    //public RangedFloat volume;

    //[MinMaxRange(1, 2)]
    //public RangedFloat pitch;
    public float maxVolume;
    public float minVolume;

    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(minVolume, maxVolume);
      //  source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }



}
