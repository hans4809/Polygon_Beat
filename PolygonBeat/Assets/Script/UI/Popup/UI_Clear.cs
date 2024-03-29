using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Clear : UI_Popup
{
    [SerializeField] AudioSource _bgm;
    [SerializeField] GameScene gameScene;
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField] TouchCheckByJson touchCheck;
    [SerializeField] UI_GameScene ui_GameScene;
    // Start is called before the first frame update
    public enum Buttons
    {
        Return,
        Replay
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        gameScene = FindAnyObjectByType<GameScene>();
        playerRotate = FindAnyObjectByType<PlayerRotate>();
        touchCheck = FindAnyObjectByType<TouchCheckByJson>();
        ui_GameScene = FindAnyObjectByType<UI_GameScene>();
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Return).gameObject.AddUIEvent(QuitClick);
        GetButton((int)Buttons.Replay).gameObject.AddUIEvent(ReplayClick);
    }
    public void QuitClick(PointerEventData data)
    {
        Managers.Scene.LoadScene(Define.Scene.StageSelect);
    }
    public void ReplayClick(PointerEventData data)
    {
        ui_GameScene.Clear();
        gameScene.Clear();
        gameScene.ResetScene();
        playerRotate.Init();
        touchCheck.Init();
        Time.timeScale = 1f;
        ClosePopUPUI();
        Managers.Sound.PlayDelayed(_bgm.clip, 3.0f, Define.Sound.BGM);

    }
}
