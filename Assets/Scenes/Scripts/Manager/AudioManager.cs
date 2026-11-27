using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource sfxAudioSource;

    private void Awake()
    {
        if (Instance != this && Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }
}
