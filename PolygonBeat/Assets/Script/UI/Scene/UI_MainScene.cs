using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_MainScene : UI_Scene
{
    public enum Buttons
    {
        Credit,
        Character,
        Setting,
        Quit,
        Tutorial,
        Start
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Credit).gameObject.AddUIEvent(CreditClicked);
        //GameObject go = GetButton((int)Buttons.Credit).gameObject;
        //AddUIEvent(go, (PointerEventData data) => { /*실행 하고자 하는 것;*/ }, Define.UIEvent.Click);
        GetButton((int)Buttons.Character).gameObject.AddUIEvent(CharacterClicked);
        GetButton((int)Buttons.Setting).gameObject.AddUIEvent(SettingClicked);
        GetButton((int)Buttons.Quit).gameObject.AddUIEvent(QuitClicked);
        GetButton((int)Buttons.Tutorial).gameObject.AddUIEvent(TutorialClicked);
        GetButton((int)Buttons.Start).gameObject.AddUIEvent(StartClicked);
    }

    public void CreditClicked(PointerEventData data)
    {
        // 실행 하고자 하는 것
        Debug.Log("CreditButton Clicked !");
        // 텍스트에 변수 적용 하고자 하면 $"아무거나 {변수 이름}"
    }
    public void CharacterClicked(PointerEventData data)
    {
        Debug.Log("CharacterButton Clicked !");
    }
    public void SettingClicked(PointerEventData data)
    {
        Debug.Log("SettingButton Clicked !");
    }
    public void QuitClicked(PointerEventData data)
    {
        Debug.Log("QuitButton Clicked !");
    }
    public void TutorialClicked(PointerEventData data)
    {
        Debug.Log("TutorialButton Clicked !");
    }
    public void StartClicked(PointerEventData data)
    {
        Debug.Log("StartButton Clicked !");
    }

}
