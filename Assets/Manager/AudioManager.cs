using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public string name; // Sound name

    public AudioClip clip;  // Sound file
    public AudioSource source; // Sound Player

    public float Audio_Volumn = 1f;
    public bool loop;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void SetVolum() { source.volume = Audio_Volumn; }
    public void SetVolum(float _volumn) { Audio_Volumn = _volumn; }
    public void Play() { source.Play(); }
    public void Stop() { source.Stop(); }
    public void SetLoop() { source.loop = true; }
    public void SetLoopCancel() { source.loop = false; }
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]

    public Sound[] sounds;
    public float Stage_Sound_Volume = 1f;

    #region Singleton
    private static AudioManager instance = null;

    // Don't destroy
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // singleton
    public static AudioManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("Sound file name : " + i + " = " + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }

    private void Update()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.volume = sounds[i].Audio_Volumn;
        }
    }

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void SetVolum(float _volumn) {

        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Audio_Volumn = _volumn;
        }
        Stage_Sound_Volume = _volumn;
    }

    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void SetLoop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoop();
                return;
            }
        }
    }

    public void SetLoopCancel(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoopCancel();
                return;
            }
        }
    }

    //public void SetVolumn(string _name, float _Volumn)
    //{
    //    for (int i = 0; i < sounds.Length; i++)
    //    {
    //        if (_name == sounds[i].name)
    //        {
    //            sounds[i].Audio_Volumn = _Volumn;
    //            sounds[i].SetVolum();
    //            return;
    //        }
    //    }
    //}
}

