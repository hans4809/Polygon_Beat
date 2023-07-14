using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    
    enum Buttons // 열거형으로 버튼들 이름 저장
    {
        Character1,
        Character2,
    }

    enum Texts // 열거형으로 텍스트들 이름 저장
    {

    }
    
    enum Images // 열거형으로 이미지들 이름 저장
    {

    }
    enum GameObjects // 열거형으로 게임 오브젝트들 이름 저장
    {

    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GameObject go = Get<Button>((int)Buttons.Character1).gameObject;

        UI_EventHandler _event = go.GetComponent<UI_EventHandler>();
        ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* 실행 하고자 하는 함수 */ }, UI_Define.UIEvent.Click);
        //또는 GetButton((int)Buttons.Character1).gameObject.ADDUIEvent(OnButtonClicked);
        //GetImage((int)Images.Character1);
    }
    private void Start()
    {
        Init();
    }
    //private void Start()
    //{
    //    Bind<Button>(typeof(Buttons));
    //    Bind<Text>(typeof(Texts));
    //    Bind<Image>(typeof(Images));
    //    Bind<GameObject>(typeof(GameObjects));

    //    GameObject go = Get<Button>((int)Buttons.Character1).gameObject;

    //    UI_EventHandler _event = go.GetComponent<UI_EventHandler>();
    //    ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* 실행 하고자 하는 함수 */ }, UI_Define.UIEvent.Click);
    //    //또는 GetButton((int)Buttons.Character1).gameObject.ADDUIEvent(OnButtonClicked);
    //    //GetImage((int)Images.Character1);
    //}

    public void OnButtonClicked(PointerEventData data)
    {
        // 실행 하고자 하는 것
        // 텍스트에 변수 적용 하고자 하면 $"아무거나 {변수 이름}"
    }
}
