using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    #region SingleTon
    private static GameObject instance;

    public GameObject Instance()
    {
        if (instance == null)
            instance = this.gameObject;

        DontDestroyOnLoad(instance);
        return instance;
    }
    #endregion

    [SerializeField] private AudioClip[] memeClips;
    private Dictionary<AudioClip, int>  ClipDictionary = new Dictionary<AudioClip, int>();

    private float volume = 0.5f;

    [SerializeField] private AudioSource currentPlayingBgm;
    [SerializeField] private AudioSource currentPlayingEffect;
    [SerializeField] private AudioSource currentPlayingMeme;

    public static UnityEvent<AudioClip> OnPlayBgm = new UnityEvent<AudioClip>();
    public static UnityEvent<AudioClip> OnPlayEffect = new UnityEvent<AudioClip>();
    public static UnityEvent<AudioClip> OnPlayMeme = new UnityEvent<AudioClip>();

    private void Start()
    {
        Instance();
        InitClipDictionary();
        OnEnable();
        //PlayBgm("")
    }

    private void OnEnable()
    {
        OnPlayBgm.AddListener(PlayBgm);
        OnPlayEffect.AddListener(PlayEffect);
        OnPlayMeme.AddListener(PlayMeme);
    }

    private void InitClipDictionary()
    {
        for(int i = 0; i < memeClips.Length; i++)
        {
            ClipDictionary.Add(memeClips[i], i);
        }
    }

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;

        currentPlayingEffect.volume = volume;
        currentPlayingMeme.volume = volume;
        currentPlayingMeme.volume = volume;
    }

    public void PauseSounds()
    {
        currentPlayingBgm.Pause();
        currentPlayingMeme.Pause();
    }

    public void ResumeSounds()
    {
        currentPlayingBgm.Play();
        currentPlayingMeme.Play();
    }

    public void PlayBgm(AudioClip bgmClip)
    {
        if(bgmClip != null)
        {
            currentPlayingBgm.resource = bgmClip;
            currentPlayingBgm.volume = volume;
            currentPlayingBgm.loop = true;
            currentPlayingBgm.Play();
        }
    }

    public void PlayEffect(AudioClip effectClip)
    {
        if (effectClip != null)
        {
            currentPlayingEffect.resource = effectClip;
            currentPlayingEffect.volume = volume;
            currentPlayingEffect.Play();
        }
    }

    public void PlayMeme(AudioClip memeClip)
    {
        if (memeClip != null)
        {
            if(currentPlayingMeme.resource != null && currentPlayingMeme.isPlaying)
            {
                if (ClipDictionary[memeClip] > ClipDictionary[currentPlayingMeme.clip])
                {
                    currentPlayingMeme.resource = memeClip;
                    currentPlayingMeme.volume = volume;
                    currentPlayingMeme.Play();
                }
            }
            else
            {
                currentPlayingMeme.resource = memeClip;
                currentPlayingMeme.volume = volume;
                currentPlayingMeme.Play();
            }
        }
    }

}
