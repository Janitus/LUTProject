using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip menuMusic;

    private void Awake () {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else {
            Destroy (gameObject);
            return;
        }

        sfxSource = GetComponent<AudioSource> ();
    }

    private void Start () => PlayMenuMusic ();

    public void PlaySound ( AudioClip clip ) {
        if (clip == null) return;
        sfxSource.PlayOneShot (clip);
    }

    public void PlayMusic ( AudioClip clip, float volume = 0.125f ) {
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play ();
    }

    public void PlayMenuMusic () {
        PlayMusic (menuMusic);
    }

}
