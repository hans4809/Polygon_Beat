using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GamePause : UI_Popup
{
    Slider _MasterSlider;
    Slider _BGMSlider;
    Slider _SFXSlider;
    AudioSource _bgm;
    GameScene gameScene;
    PlayerRotate playerRotate;
    TouchCheckByJson touchCheck;
    UI_GameScene ui_GameScene;

    public enum Buttons
    {
        Quit,
        Return,
        Replay
    }
    public enum Sliders
    {
        MasterSlider,
        BgmSlider,
        SfxSlider
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init(); 
        gameScene = FindAnyObjectByType<GameScene>();
        playerRotate = FindAnyObjectByType<PlayerRotate>();
        touchCheck = FindAnyObjectByType<TouchCheckByJson>();
        ui_GameScene = FindAnyObjectByType<UI_GameScene>();
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        Bind<Button>(typeof(Buttons));
        Bind<Slider>(typeof(Sliders));
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClick);
        GetButton((int)Buttons.Return).gameObject.AddUIEvent(ReturnClick);
        GetButton((int)Buttons.Replay).gameObject.AddUIEvent(ReplayClick);
        _MasterSlider = Get<Slider>((int)Sliders.MasterSlider);
        _BGMSlider = Get<Slider>((int)Sliders.BgmSlider);
        _SFXSlider = Get<Slider>((int)Sliders.SfxSlider);
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
    public void QuitClick(PointerEventData data)
    {
        ClosePopUPUI();
        Managers.Scene.LoadScene(Define.Scene.StageSelect);
        Time.timeScale = 1f;
    }
    public void ReturnClick(PointerEventData data)
    {
        _bgm.UnPause();
        ClosePopUPUI();
        Time.timeScale = 1f;
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
        if (DataManager.singleTon.wholeGameData._masterVolume <= -40f)
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
        if (DataManager.singleTon.wholeGameData._masterVolume <= -40f)
        {
            Managers.Sound.audioMixer.SetFloat("SFX", -80);
        }
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_SFXSlider.value) * 20);
        Managers.Sound._audioSources[(int)Define.Sound.SFX].volume = _SFXSlider.value;
    }

    public void ReplayClick(PointerEventData data)
    {
        ui_GameScene.Clear();
        gameScene.Clear();
        gameScene.ResetScene();
        playerRotate.Init();
        touchCheck.Init();
        ClosePopUPUI();
        Managers.Sound.PlayDelayed(_bgm.clip, 3.0f, Define.Sound.BGM);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
