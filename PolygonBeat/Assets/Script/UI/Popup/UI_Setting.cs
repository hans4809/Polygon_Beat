using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Popup
{
    [SerializeField] AudioMixer audioMixer;
    private Slider masterSlider;
    private Slider bgmSlider;
    private Slider sfxSlider;

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
        masterSlider = Get<GameObject>((int)GameObjects.MasterSlider).GetComponent<Slider>();
        bgmSlider = Get<GameObject>((int)GameObjects.BgmSlider).GetComponent<Slider>();
        sfxSlider = Get<GameObject>((int)GameObjects.SfxSlider).GetComponent<Slider>();
        masterSlider.value = DataManager.singleTon.wholeGameData._masterVolume;
        bgmSlider.value = DataManager.singleTon.wholeGameData._bgmVolume;
        sfxSlider.value = DataManager.singleTon.wholeGameData._sfxVolume;
        masterSlider.gameObject.AddUIEvent(SetMaster);
        bgmSlider.gameObject.AddUIEvent(SetBgm);
        sfxSlider.gameObject.AddUIEvent(SetSfx);
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
    public void SetBgm(PointerEventData data)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }

    public void SetSfx(PointerEventData data)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
    }
    public void SetMaster(PointerEventData data)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
    }
}
