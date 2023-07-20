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
    public enum GameObjects
    {
        Quit,
        Return,
        Replay,
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
        Bind<GameObject>(typeof(GameObjects));
        GetButton((int)GameObjects.Quit).gameObject.AddUIEvent(QuitClick);
        GetButton((int)GameObjects.Return).gameObject.AddUIEvent(ReturnClick);
        GetButton((int)GameObjects.Replay).gameObject.AddUIEvent(ReplayClick);
        _masterSlider = Get<Slider>((int)GameObjects.MasterSlider);
        _bgmSlider = Get<Slider>((int)GameObjects.BgmSlider);
        _sfxSlider = Get<Slider>((int)GameObjects.SfxSlider);
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
