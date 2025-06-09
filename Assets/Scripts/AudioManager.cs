using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public AudioClip training1Audio;
    public AudioClip training2Audio;
    public AudioClip training3Audio;
    public AudioClip training4Audio;

    private bool isInTraining = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (isInTraining || backgroundMusic == null || audioSource == null) return;

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopAllAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public void PlayTrainingAudio(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;

        isInTraining = true;

        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ResetToMenu()
    {
        isInTraining = false;
        StopAllAudio();
        PlayBackgroundMusic();
    }
}
