using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    
    enum Buttons // ���������� ��ư�� �̸� ����
    {
        Character1,
        Character2,
    }

    enum Texts // ���������� �ؽ�Ʈ�� �̸� ����
    {

    }
    
    enum Images // ���������� �̹����� �̸� ����
    {

    }
    enum GameObjects // ���������� ���� ������Ʈ�� �̸� ����
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
        ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* ���� �ϰ��� �ϴ� �Լ� */ }, UI_Define.UIEvent.Click);
        //�Ǵ� GetButton((int)Buttons.Character1).gameObject.ADDUIEvent(OnButtonClicked);
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
    //    ADDUIEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position;/* ���� �ϰ��� �ϴ� �Լ� */ }, UI_Define.UIEvent.Click);
    //    //�Ǵ� GetButton((int)Buttons.Character1).gameObject.ADDUIEvent(OnButtonClicked);
    //    //GetImage((int)Images.Character1);
    //}

    public void OnButtonClicked(PointerEventData data)
    {
        // ���� �ϰ��� �ϴ� ��
        // �ؽ�Ʈ�� ���� ���� �ϰ��� �ϸ� $"�ƹ��ų� {���� �̸�}"
    }
}
