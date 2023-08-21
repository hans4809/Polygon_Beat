using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static DataDefine;

public class UI_StageSelect : UI_Scene
{
    public enum Buttons
    {
        Back,
        BackGround1,
        BackGround2,
        BackGround3,
        BackGround4,
        Play
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(BackClicked);
        GetButton((int)Buttons.BackGround1).gameObject.AddUIEvent(FirstClicked);
        GetButton((int)Buttons.BackGround2).gameObject.AddUIEvent(SecondClicked);
        GetButton((int)Buttons.BackGround3).gameObject.AddUIEvent(ThirdClicked);
        GetButton((int)Buttons.BackGround4).gameObject.AddUIEvent(ForthClicked);
        GetButton((int)Buttons.Play).gameObject.AddUIEvent(PlayClicked);

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
        DataManager.singleTon.currentMusic = DataManager.singleTon.musicData.music[0]; 
        Managers.Sound.Play($"Sounds/BGM/{DataManager.singleTon.wholeGameData._currentSong}", Define.Sound.BGM);
    }
    public void SecondClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 7;
        DataManager.singleTon.currentMusic = DataManager.singleTon.musicData.music[1];
        Managers.Sound.Play($"Sounds/BGM/{DataManager.singleTon.wholeGameData._currentSong}", Define.Sound.BGM);
    }
    public void ThirdClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 9;
        DataManager.singleTon.currentMusic = DataManager.singleTon.musicData.music[2];
        Managers.Sound.Play($"Sounds/BGM/{DataManager.singleTon.wholeGameData._currentSong}", Define.Sound.BGM);
    }
    public void ForthClicked(PointerEventData data)
    {
        DataManager.singleTon.wholeGameData._currentSong = 10;
        DataManager.singleTon.currentMusic = DataManager.singleTon.musicData.music[3];
        Managers.Sound.Play($"Sounds/BGM/{DataManager.singleTon.wholeGameData._currentSong}", Define.Sound.BGM);
    }
    public void PlayClicked(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.GameScene);
    }
}
