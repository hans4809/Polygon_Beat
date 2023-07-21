using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Gacha : UI_Popup
{
    GameObject anim;
    public enum Buttons
    {
        Back,
        Close,
        GachaButton,
    }
    public enum GameObjects
    {
        Gacha
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(BackClick);
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(CloseClick);
        anim = Get<GameObject>((int)GameObjects.Gacha);
        GetButton((int)Buttons.GachaButton).gameObject.AddUIEvent(GachaClick);
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
        Debug.Log("GachaButton Clicked !");
        anim.GetComponent<Animator>().SetTrigger("Click");
    }
}
