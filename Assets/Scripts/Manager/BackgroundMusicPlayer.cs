using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicPlaylist;
    private AudioSource audioSource;
    private int musicIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSong();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        audioSource.clip = musicPlaylist[musicIndex];
        audioSource.Play();
        musicIndex = (musicIndex + 1) % musicPlaylist.Length;
    }
}
