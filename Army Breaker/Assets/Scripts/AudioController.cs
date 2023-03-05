using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    // Define an enum for all the audio clips you want to use in the game
    public enum Sound
    {
        ButtonClick,
        // Add more sounds here as needed
    }

    // Define an array to hold all the interface sounds
    public AudioClip[] interfaceSounds;

    // Define an array to hold all the music tracks
    public AudioClip[] musicTracks;

    // Define an array to hold all the game sounds
    public AudioClip[] gameSounds;

    // Define volume variables for each sound category
    [Range(0f, 1f)]
    public float interfaceSoundsVolume = 1f;
    [Range(0f, 1f)]
    public float musicVolume = 1f;
    [Range(0f, 1f)]
    public float gameSoundsVolume = 1f;

    // Define an audio source to play the audio clips
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayInterfaceSound(Sound sound)
    {
        // Get the audio clip from the interfaceSounds array based on the provided enum value
        AudioClip clip = interfaceSounds[(int)sound];

        // Play the audio clip through the audio source with the specified volume
        audioSource.PlayOneShot(clip, interfaceSoundsVolume);
    }

    public void PlayMusicTrack(Sound sound)
    {
        // Get the audio clip from the musicTracks array based on the provided enum value
        AudioClip clip = musicTracks[(int)sound];

        // Play the audio clip through the audio source with the specified volume
        audioSource.clip = clip;
        audioSource.volume = musicVolume;
        audioSource.Play();
    }

    public void PlayGameSound(Sound sound)
    {
        // Get the audio clip from the gameSounds array based on the provided enum value
        AudioClip clip = gameSounds[(int)sound];

        // Play the audio clip through the audio source with the specified volume
        audioSource.PlayOneShot(clip, gameSoundsVolume);
    }
}
