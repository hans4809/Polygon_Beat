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
    ReplayManager replay = new ReplayManager();
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
        Bind<Button>(typeof(Buttons));
        Bind<Slider>(typeof(Sliders));
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClick);
        GetButton((int)Buttons.Return).gameObject.AddUIEvent(ReturnClick);
        GetButton((int)Buttons.Replay).gameObject.AddUIEvent(ReplayClick);
        _masterSlider = Get<Slider>((int)Sliders.MasterSlider);
        _bgmSlider = Get<Slider>((int)Sliders.BgmSlider);
        _sfxSlider = Get<Slider>((int)Sliders.SfxSlider);
    }
    public void QuitClick(PointerEventData data)
    {
        ClosePopUPUI();
        Managers.Scene.LoadScene(Define.Scene.StageSelect);
    }
    public void ReturnClick(PointerEventData data)
    {
        ClosePopUPUI();
        replay.Replay();
        Time.timeScale = 1f;
    }
    public void ReplayClick(PointerEventData data)
    {
        ClosePopUPUI();
        replay.Replay();
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
