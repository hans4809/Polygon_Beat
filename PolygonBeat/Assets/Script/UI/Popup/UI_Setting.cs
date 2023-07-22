using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Popup
{
    [SerializeField] AudioMixer audioMixer;
    private Slider _masterSlider;
    private Slider _bgmSlider;
    private Slider _sfxSlider;

    public enum GameObjects
    {
        Close,
        MasterSlider,
        BgmSlider,
        SfxSlider
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.Close).AddUIEvent(CloseClicked);
        _masterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        _bgmSlider = Get<GameObject>((int)GameObjects.BgmSlider).GetComponent<Slider>();
        _sfxSlider = Get<GameObject>((int)GameObjects.SfxSlider).GetComponent<Slider>();
        _masterSlider.value = DataManager.singleTon.wholeGameData._masterVolume;
        _bgmSlider.value = DataManager.singleTon.wholeGameData._bgmVolume;
        _sfxSlider.value = DataManager.singleTon.wholeGameData._sfxVolume;
        _masterSlider.gameObject.AddUIEvent(MasterVolume);
        _bgmSlider.gameObject.AddUIEvent(BGMVolume);
        _sfxSlider.gameObject.AddUIEvent(SFXVolume);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void CloseClicked(PointerEventData data)
    {
        ClosePopUPUI();
    }
    public void MasterVolume(PointerEventData data)
    {
        Debug.Log(_masterSlider.value);
        DataManager.singleTon.wholeGameData._masterVolume = _masterSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(_masterSlider.value) * 20);
    }
    public void BGMVolume(PointerEventData data)
    {
        Debug.Log(_bgmSlider.value);
        DataManager.singleTon.wholeGameData._bgmVolume = _bgmSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_bgmSlider.value) * 20);
    }
    public void SFXVolume(PointerEventData data)
    {
        Debug.Log(_sfxSlider.value);
        DataManager.singleTon.wholeGameData._sfxVolume = _sfxSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_sfxSlider.value) * 20);
    }
}
