using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterSquare : UI_Popup
{
    enum Buttons
    {
        Change,
        Back,
        Close,
        Gacha,
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Change).gameObject.AddUIEvent(ChangeClick);
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(BackClick);
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClick);
        GetButton((int)Buttons.Gacha).gameObject.AddUIEvent(GachaClick);
    }
    public void ChangeClick(PointerEventData data)
    {
        ClosePopUPUI();
        Managers.UI.ShowPopUpUI<UI_CharacterTri>();
    }
    public void BackClick(PointerEventData data)
    {
        ClosePopUPUI();
    }
    public void CloseClick(PointerEventData data)
    {
        Managers.UI.CloseAllPopUPUI();
    }
    public void GachaClick(PointerEventData data)
    {
        Managers.UI.ShowPopUpUI<UI_Gacha>();
    }
}
