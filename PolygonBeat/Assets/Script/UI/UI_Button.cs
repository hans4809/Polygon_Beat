using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    
    public enum Buttons // ���������� ��ư�� �̸� ����
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

    enum Texts // ���������� �ؽ�Ʈ�� �̸� ����
    {

    }
    
    enum Images // ���������� �̹����� �̸� ����
    {

    }
    enum GameObjects // ���������� ���� ������Ʈ�� �̸� ����
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
        //ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* ���� �ϰ��� �ϴ� �Լ� */ }, UI_Define.UIEvent.Click);
        GetButton((int)Buttons.CharacterButton0).gameObject.AddUIEvent(OnButtonClicked);
        //GetImage((int)Images.Character1);
    }
    private void Start()
    {
        Init();
    }

    public void OnButtonClicked(PointerEventData data)
    {
        // ���� �ϰ��� �ϴ� ��
        Debug.Log("CharacterButton Clicked !");
        // �ؽ�Ʈ�� ���� ���� �ϰ��� �ϸ� $"�ƹ��ų� {���� �̸�}"
    }
}
