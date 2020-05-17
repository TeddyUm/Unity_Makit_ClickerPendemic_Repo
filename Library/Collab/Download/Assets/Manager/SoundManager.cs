using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioSource musicsource;
    public AudioSource btnsource;
    public AudioSource tabSource;

    private void Awake()
    {
        if (SoundManager.Instance == null) 
        { 
            SoundManager.Instance = this; 
        }
    }

    public void SetMusicVolum (float volume)
    {
        musicsource.volume = volume;
    }

    public void SetButtonVolum(float volume)
    {
        btnsource.volume = volume;
    }

    public void OnSfx()
    {
        btnsource.Play();
    }

    public void PlayTabSound()
    {
        tabSource.Play();
    }
}
