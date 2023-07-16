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
    }

    public void CreditClicked(PointerEventData data)
    {
        Debug.Log("CreditButton Clicked !");
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
        Managers.Scene.LoadScene(Define.Scene.StageSelect);
    }

}