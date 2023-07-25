using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_AllGet : UI_Popup
{
    public enum GameObjects
    {
        OK
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.OK).AddUIEvent(OKClick);
    }
    public void OKClick(PointerEventData data)
    {
        ClosePopUPUI();
    }
}
