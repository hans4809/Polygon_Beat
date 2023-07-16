using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    
    public enum Buttons // 열거형으로 버튼들 이름 저장
    {
        Credit,
        Character,
        Setting,
        Quit,
        Tutorial,
        Start,
        Close,
        Back,
        Machine,
        Triangle,
        GachaMachine,
        CharacterButton0,
        CharacterButton1,
        CharacterButton2,
        CharacterButton3,
        CharacterButton4,
    }

    enum Texts // 열거형으로 텍스트들 이름 저장
    {

    }
    
    enum Images // 열거형으로 이미지들 이름 저장
    {

    }
    enum GameObjects // 열거형으로 게임 오브젝트들 이름 저장
    {
        MainPanel,
        CreditCanvas,
        SettingCanvas,
        SoundOptions,
        CharacterCanvas_Square,
        CharacterPanel,
        GachaCanvas
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GameObject go = Get<Button>((int)Buttons.CharacterButton0).gameObject;

        UI_EventHandler _event = go.GetComponent<UI_EventHandler>();
        //ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* 실행 하고자 하는 함수 */ }, UI_Define.UIEvent.Click);
        GetButton((int)Buttons.CharacterButton0).gameObject.AddUIEvent(OnButtonClicked);
        //GetImage((int)Images.Character1);
    }
    private void Start()
    {
        Init();
    }

    public void OnButtonClicked(PointerEventData data)
    {
        // 실행 하고자 하는 것
        Debug.Log("CharacterButton Clicked !");
        // 텍스트에 변수 적용 하고자 하면 $"아무거나 {변수 이름}"
    }
}
