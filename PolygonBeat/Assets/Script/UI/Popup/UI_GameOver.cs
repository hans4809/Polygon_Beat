using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
    ReplayManager replay = new ReplayManager();
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
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Return).gameObject.AddUIEvent(ReturnClick);
        GetButton((int)Buttons.Replay).gameObject.AddUIEvent(ReplayClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReturnClick(PointerEventData data)
    {
        ClosePopUPUI();
    }
    public void ReplayClick(PointerEventData data)
    {
        ClosePopUPUI();
        replay.Replay();
        Time.timeScale = 1f;
    }
}
