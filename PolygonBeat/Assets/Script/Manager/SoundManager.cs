using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager
{
    public AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public AudioMixer audioMixer;

    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SfxSlider;

    private static float masterVolume = 1f;
    private static float bgmVolume = 1f;
    private static float sfxVolume = 1f;
    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if(root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for(int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }
            //_audioSources[(int)Define.Sound.BGM].loop = true;
        }
        SetSoundSetting();
    }
    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.SFX, float pitch = 1.0f)
    {
        if (audioClip == null)
        {
            return;
        }
        if (type == Define.Sound.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.BGM];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.SFX];
            audioSource.pitch = pitch;
            audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
            audioSource.PlayOneShot(audioClip);
        }
    }
    public void PlayDelayed(AudioClip audioClip, float delay, Define.Sound type = Define.Sound.BGM, float pitch = 1.0f)
    {
        if (audioClip == null)
        {
            return;
        }
        if (type == Define.Sound.BGM)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.BGM];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.PlayDelayed(3.0f);
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.SFX];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }
    public void Play(string path, Define.Sound type = Define.Sound.SFX, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }
    public void PlayDelayed(string path, float delay, Define.Sound type = Define.Sound.BGM, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        PlayDelayed(audioClip, delay, type, pitch);
    }
   
    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.SFX)
    {
        if (path.Contains("Sounds/") == false)
        {
            path = $"Sounds/{path}";
        }
        AudioClip audioClip = null;
        if (type == Define.Sound.BGM)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }
        if (audioClip == null)
        {
            Debug.Log($"AudioClip Missing : {path}");
        }
        return audioClip;
    }
    public void Stop(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    public void Clear()
    {
        foreach(AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }
    public static void SetSoundSetting()
    {
        masterVolume = DataManager.singleTon.wholeGameData._masterVolume;
        bgmVolume = DataManager.singleTon.wholeGameData._bgmVolume;
        sfxVolume = DataManager.singleTon.wholeGameData._sfxVolume;
    }
    public static float GetMasterVolume()
    {
        return masterVolume;
    }
    public static float GetBGMVolume()
    {
        return bgmVolume;
    }

    public static float GetSFXVolume()
    {
        return sfxVolume;
    }
    public void SetBgm()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }
    public void SetSfx()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }
    public void SetMaster()
    {
        SetBgm();
        SetSfx();
    }
    private void SetSliderValues()
    {
        if (MasterSlider != null)
            MasterSlider.value = masterVolume;

        if (BgmSlider != null)
            BgmSlider.value = bgmVolume;

        if (SfxSlider != null)
            SfxSlider.value = sfxVolume;
    }
}
