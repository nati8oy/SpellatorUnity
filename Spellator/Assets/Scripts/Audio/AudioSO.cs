using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Audio Object", menuName = "New Audio Object")]

public class AudioSO : ScriptableObject
{
    //set the volume range by slider
    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    [Header("General Audio")]
    public AudioClip[] musicBackgroundMusic;
    public AudioClip[] sfxGeneral;
    [Space]
    [Header ("SFX categories")]
    public AudioClip[] sfxBigScore;
    public AudioClip[] sfxTilePops;

    public AudioClip[] sfxTileCrashes;
    public AudioClip[] sfxUserInterface;

 



}
