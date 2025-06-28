using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    
    private static MusicManager Instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;

   
    private static float currentVolume = 0.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            
           
            audioSource.volume = currentVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        if (musicSlider != null)
        {
            musicSlider.value = currentVolume;
            musicSlider.onValueChanged.AddListener(SetVolume);
        }

        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(false, backgroundMusic);
        }
    }

    public static void SetVolume(float volume)
    {
        currentVolume = volume; 
        if (Instance != null && Instance.audioSource != null)
        {
            Instance.audioSource.volume = currentVolume;
        }
    }

    public static void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        if (Instance == null) return;
        
        if (audioClip != null)
        {
            Instance.audioSource.clip = audioClip;
        }
        
        
        Instance.audioSource.volume = currentVolume;
        
        if (resetSong)
        {
            Instance.audioSource.Stop();
        }
        Instance.audioSource.Play();
    }

    public static void PauseBackgroundMusic()
    {
        if (Instance != null && Instance.audioSource != null)
        {
            Instance.audioSource.Pause();
        }
    }
}