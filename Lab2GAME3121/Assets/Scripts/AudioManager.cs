using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Clips")]
    public AudioClip backgroundMusic;
    public List<AudioClip> wallHits = new List<AudioClip>(); // pool of wall hit sounds
    public AudioClip winSound;
    public AudioClip deathSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;
    private int lastWallIndex = -1;
    [Range(0f, 2f)] public float wallHitVolume = 1.5f; // Was too quiet, so I increased it to 1.5f

    void Awake()
    {
        Instance = this;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.25f;
        musicSource.playOnAwake = false;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;
    }

    void Start()
    {
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null) sfxSource.PlayOneShot(clip, volume);
    }

    // Picks a random clip from the pool, never the same one twice in a row
    public void PlayWallHit()
    {
        if (wallHits == null || wallHits.Count == 0) return;

        int index = Random.Range(0, wallHits.Count);
        if (wallHits.Count > 1 && index == lastWallIndex)
        {
            index = (index + 1 + Random.Range(0, wallHits.Count - 1)) % wallHits.Count;
        }
        lastWallIndex = index;

        sfxSource.PlayOneShot(wallHits[index], wallHitVolume);
    }

    public void StopMusic() { musicSource.Stop(); }

    public void PlayAtPoint(AudioClip clip, Vector3 pos, float volume = 1f)
    {
        if (clip != null) AudioSource.PlayClipAtPoint(clip, pos, volume);
    }
}