using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_StageSelect : UI_Scene
{
    public enum Buttons
    {
        Back,
        Stage1,
        Stage2,
        Stage3
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(BackClicked);
        GetButton((int)Buttons.Stage1).gameObject.AddUIEvent(FirstClicked);
        GetButton((int)Buttons.Stage2).gameObject.AddUIEvent(SecondClicked);
        GetButton((int)Buttons.Stage3).gameObject.AddUIEvent(ThirdClicked);

    }
    void Start()
    {
        Init();
    }

    public void BackClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.MainScene);
    }
    public void FirstClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 5;
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }

    public void SecondClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 7;
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }
    public void ThirdClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 9;
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }
    public void ForthClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 10;
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }
}
