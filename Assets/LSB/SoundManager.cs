using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

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

    private float volume = 0.5f;

    [SerializeField] private Sound[] Bgms;
    [SerializeField] private Sound[] Effects;

    [SerializeField] private List<AudioSource> currentPlayingSounds;

    public static event Action<string> OnPlayBgm;
    public static event Action<string> OnPlayEffectSound;

    private void Start()
    {
        OnEnable();
        //PlayBgm("")
    }

    private void OnEnable()
    {
        OnPlayBgm += PlayBgm;
        OnPlayEffectSound += PlayEffectSound;
    }

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;

        foreach(var source in currentPlayingSounds)
        {
            source.volume = newVolume;
        }
    }

    public void PauseSounds()
    {
        foreach(var source in currentPlayingSounds)
        {
            source.Pause();
        }
    }

    public void ResumeSounds()
    {
        foreach(var source in currentPlayingSounds)
        {
            source.Play();
        }
    }

    public void PlayBgm(string soundName)
    {
        foreach (var bgm in Bgms)
        {
            if (bgm.name == soundName)
            {
                if (currentPlayingSounds.Count == 0)
                {
                    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                    currentPlayingSounds.Add(audioSource);
                }

                currentPlayingSounds[0].clip = bgm.clip;
                currentPlayingSounds[0].volume =  volume;
                currentPlayingSounds[0].loop = true;
                currentPlayingSounds[0].Play();
                return;
            }
        }

        Debug.Log("배경 사운드 플레이 오류!!");
    }

    public void PlayEffectSound(string soundName)
    {
        foreach (var effect in Effects)
        {
            if (effect.name == soundName)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = effect.clip;
                audioSource.volume = volume;
                audioSource.Play();

                currentPlayingSounds.Add(audioSource);

                StartCoroutine(RemoveAudioSourceAfterPlay(audioSource));
                return;
            }
        }

        Debug.Log("효과 사운드 플레이 오류!!");
    }

    private IEnumerator RemoveAudioSourceAfterPlay(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
            yield return null;

        currentPlayingSounds.Remove(audioSource);
        Destroy(audioSource);
    }
}
