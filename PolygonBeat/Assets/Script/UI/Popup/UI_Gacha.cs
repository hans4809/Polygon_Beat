using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Gacha : UI_Popup
{
    [SerializeField] Animator anim;
    [SerializeField] bool allGet;
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
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClick);
        anim = Get<GameObject>((int)GameObjects.Gacha).GetComponent<Animator>();
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
        DataManager.singleTon.wholeGameData._coin -= 100;
        for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
        {
            if (DataManager.singleTon.userCharacterData.characters[i]._isHave)
            {
                allGet = true;
            }
            else
            {
                allGet= false;
            }
        }
        if (allGet)
        {
            Managers.UI.ShowPopUpUI<UI_AllGet>();
        }
        if (DataManager.singleTon.wholeGameData._coin >= 100)
        {
            DataManager.singleTon.jsonManager.Save<DataDefine.WholeGameData>(DataManager.singleTon.wholeGameData);
            Managers.Sound.Play("Sounds/SFX/Gacha");
            anim.SetTrigger("Click");
        }
    }
    
}
