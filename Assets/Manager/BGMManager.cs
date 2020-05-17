using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // Rene part variable
    public AudioClip[] clips;   // BGMs
    private AudioSource source;

    public float BGM_Volume;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    #region Singleton
    static public BGMManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    #endregion

    // Rene part function
    void Start()
    {
        BGM_Volume = 1f;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        source.volume = BGM_Volume;
    }

    public void Play(int _playMusicTrack)
    {
        source.volume = BGM_Volume;
        source.clip = clips[_playMusicTrack];
        source.Play();
    }

    public void SetVolum (float _volumn) { BGM_Volume = _volumn; }
    public void Pause() { source.Pause(); }
    public void Unpause() { source.UnPause();}
    public void Stop() { source.Stop(); }

    public void FadeOutMusic()
    {
        StopAllCoroutines();    // If Coroutines are played together
        StartCoroutine(FadeOutMusicCoroutine());
    }

    IEnumerator FadeOutMusicCoroutine()
    {
        for (float i = 1.0f; i >= 0f; i -= 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }

    public void FadeInMusic()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInMusicCoroutine());
    }

    IEnumerator FadeInMusicCoroutine()
    {
        for (float i = 0f; i <= 1f; i += 0.01f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }
}
