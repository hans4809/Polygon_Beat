using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GamePause : UI_Popup
{
    Slider _masterSlider;
    Slider _bgmSlider;
    Slider _sfxSlider;
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
        _masterSlider = Get<Slider>((int)Sliders.MasterSlider);
        _bgmSlider = Get<Slider>((int)Sliders.BgmSlider);
        _sfxSlider = Get<Slider>((int)Sliders.SfxSlider);
        _masterSlider.value = DataManager.singleTon.wholeGameData._masterVolume;
        _bgmSlider.value = DataManager.singleTon.wholeGameData._bgmVolume;
        _sfxSlider.value = DataManager.singleTon.wholeGameData._sfxVolume;
        _masterSlider.gameObject.AddUIEvent(MasterVolume, Define.UIEvent.Slider);
        _bgmSlider.gameObject.AddUIEvent(BGMVolume, Define.UIEvent.Slider);
        _sfxSlider.gameObject.AddUIEvent(SFXVolume, Define.UIEvent.Slider);
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
        DataManager.singleTon.wholeGameData._masterVolume = _masterSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("Master", Mathf.Log10(_masterSlider.value) * 20);
    }
    public void BGMVolume(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._bgmVolume = _bgmSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("BGM", Mathf.Log10(_bgmSlider.value) * 20);
    }
    public void SFXVolume(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._sfxVolume = _sfxSlider.value;
        DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
        Managers.Sound.audioMixer.SetFloat("SFX", Mathf.Log10(_sfxSlider.value) * 20);
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
