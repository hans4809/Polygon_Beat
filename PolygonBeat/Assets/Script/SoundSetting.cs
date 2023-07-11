using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundSetting : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider MasterSlider;
    public Slider BgmSlider;
    public Slider SfxSlider;


    private static float masterVolume = 1f;
    private static float bgmVolume = 1f;
    private static float sfxVolume = 1f;

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


    private void Start()
    {
        if (SoundManager.Instance != null)
        {
            masterVolume = SoundManager.Instance.GetMasterVolume();
            bgmVolume = SoundManager.Instance.GetBGMVolume();
            sfxVolume = SoundManager.Instance.GetSFXVolume();
        }




        SetSliderValues();

        MasterSlider.onValueChanged.AddListener(OnMasterSliderValueChanged);
        BgmSlider.onValueChanged.AddListener(OnBGMSliderValueChanged);
        SfxSlider.onValueChanged.AddListener(OnSFXSliderValueChanged);
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

    private void OnMasterSliderValueChanged(float value)
    {
        masterVolume = value;
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetMasterVolume(masterVolume);
        }
    }

    private void OnBGMSliderValueChanged(float value)
    {
        bgmVolume = value;
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetBGMVolume(bgmVolume);
        }
    }

    private void OnSFXSliderValueChanged(float value)
    {
        sfxVolume = value;
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetSFXVolume(sfxVolume);
        }
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
}
