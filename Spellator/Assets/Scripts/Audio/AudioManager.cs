using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSO audioObject;
    public float volume;

    public float delayAmount;

    [Header("General Audio")]
    public AudioClip[] musicBackgroundMusic;
    public AudioClip[] sfxGeneral;

    [Space]
    [Header("SFX categories")]
    public AudioClip[] sfxBigScore;
    public AudioClip[] sfxTilePops;
    public AudioClip[] sfxTileCrashes;

    public AudioClip[] sfxUserInterface;

    public AudioSource crashAudioSource;
    public AudioSource popAudioSource;


    private AudioSource mainAudioSource;
    public AudioSource MainAudioSource
    {
        get { return mainAudioSource; }
    }
    


    //this is the singleton code to ensure there's not more than one instance running
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        

        //setup the vars from the SO
        musicBackgroundMusic = audioObject.musicBackgroundMusic;
        sfxGeneral = audioObject.sfxGeneral;
        sfxBigScore = audioObject.sfxBigScore;
        sfxTilePops = audioObject.sfxTilePops;
        sfxTileCrashes = audioObject.sfxTileCrashes;
        sfxUserInterface = audioObject.sfxUserInterface;



        mainAudioSource =  GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        volume = audioObject.volume;
    }

    public void PlayAudio(AudioClip targetAudio)
    {
        //mainAudioSource.volume = volume;
        mainAudioSource.PlayOneShot(targetAudio);
    }

    public void PlayAudioWithSource(AudioClip targetAudio, AudioSource source, float volumeLevel)
    {
        source.volume = volumeLevel;
        //source.pitch = volumeLevel;
        mainAudioSource.PlayOneShot(targetAudio);

    }

}
