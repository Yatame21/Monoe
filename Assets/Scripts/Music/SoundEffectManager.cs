using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    private static SoundEffectManager instance;
    private AudioSource audioSource;
    [SerializeField] private SoundEffectLibrary soundEffectLibrary;
    private static float currentVolume = 0.5f;

    public static SoundEffectManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            transform.SetParent(null); // Открепляем от родителя
            DontDestroyOnLoad(gameObject);
            
            // Загрузка сохраненной громкости
            currentVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
            audioSource.volume = currentVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (sfxSlider != null)
        {
            sfxSlider.value = currentVolume;
            sfxSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        currentVolume = volume;
        audioSource.volume = currentVolume;
        PlayerPrefs.SetFloat("SFXVolume", currentVolume);
        
        // Обновляем все слайдеры в сцене
        foreach (var slider in FindObjectsOfType<Slider>())
        {
            if (slider.CompareTag("SFXSlider"))
            {
                slider.onValueChanged.RemoveAllListeners();
                slider.value = currentVolume;
                slider.onValueChanged.AddListener(SetVolume);
            }
        }
    }

    public void RegisterSlider(Slider slider)
    {
        slider.value = currentVolume;
        slider.onValueChanged.AddListener(SetVolume);
    }

    public static void Play(string soundName)
    {
        if (Instance != null && Instance.soundEffectLibrary != null)
        {
            AudioClip clip = Instance.soundEffectLibrary.GetRandomClip(soundName);
            if (clip != null)
            {
                Instance.audioSource.PlayOneShot(clip, currentVolume);
            }
        }
    }
}