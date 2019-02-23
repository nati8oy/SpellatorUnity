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

    [SerializeField] private AudioClip tileClick; 

    /*
    public AudioClip TileClick
    {
        get { return tileClick; }
    }
    */


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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip targetAudio)
    {
        mainAudioSource.PlayOneShot(targetAudio);
    }
}
