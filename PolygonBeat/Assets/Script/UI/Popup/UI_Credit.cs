using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Credit : UI_Popup
{
    public enum Buttons
    {
        Close
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClicked);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void CloseClicked(PointerEventData data)
    {
        ClosePopUPUI();
    }
}
