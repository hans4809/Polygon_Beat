using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Popup
{
    [SerializeField] AudioMixer audioMixer;
    private Slider _MasterSlider;
    private Slider _BGMSlider;
    private Slider _SFXSlider;

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
        _MasterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        _BGMSlider = Get<GameObject>((int)GameObjects.BgmSlider).GetComponent<Slider>();
        _SFXSlider = Get<GameObject>((int)GameObjects.SfxSlider).GetComponent<Slider>();
        _MasterSlider.value = DataManager.singleTon.wholeGameData._masterVolume;
        _BGMSlider.value = DataManager.singleTon.wholeGameData._bgmVolume;
        _SFXSlider.value = DataManager.singleTon.wholeGameData._sfxVolume;
        _MasterSlider.gameObject.AddUIEvent(MasterVolume, Define.UIEvent.Slider);
        _BGMSlider.gameObject.AddUIEvent(BGMVolume, Define.UIEvent.Slider);
        _SFXSlider.gameObject.AddUIEvent(SFXVolume, Define.UIEvent.Slider);
        if (_BGMSlider.value <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("BGM", -80);
        }
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_BGMSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = _BGMSlider.value;
        if (_SFXSlider.value <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("SFX", -80);
        }
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_SFXSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = _SFXSlider.value;
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
        DataManager.singleTon.wholeGameData._masterVolume = _MasterSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        if (DataManager.singleTon.wholeGameData._masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("Master", -80);
        }
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(_MasterSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.Master].volume = _MasterSlider.value;
    }
    public void BGMVolume(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._bgmVolume = _BGMSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        if (DataManager.singleTon.wholeGameData._bgmVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("BGM", -80);
        }
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_BGMSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.BGM].volume = _BGMSlider.value;
    }
    public void SFXVolume(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._sfxVolume = _SFXSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        if (DataManager.singleTon.wholeGameData._sfxVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("SFX", -80);
        }
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_SFXSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = _SFXSlider.value;
    }
}
