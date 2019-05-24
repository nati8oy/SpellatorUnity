using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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
        mainAudioSource =  GetComponent<AudioSource>();
        
    }

    public void PlayAudio(AudioClip targetAudio)
    {
        mainAudioSource.PlayOneShot(targetAudio);
    }
}
