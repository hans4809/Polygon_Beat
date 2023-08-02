using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static DataDefine;

public class UI_CharacterTri : UI_Popup
{
    [SerializeField] Image _currentCharacter;
    [SerializeField] SaveData saveData;
    enum Buttons
    {
        Change,
        Back,
        Close,
        Gacha
    }
    enum Images
    {
        CurrentCharacter
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        saveData = DataManager.singleTon.saveData;
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        GetButton((int)Buttons.Change).gameObject.AddUIEvent(ChangeClick);
        GetButton((int)Buttons.Back).gameObject.AddUIEvent(BackClick);
        GetButton((int)Buttons.Close).gameObject.AddUIEvent(CloseClick);
        GetButton((int)Buttons.Gacha).gameObject.AddUIEvent(GachaClick);
        _currentCharacter = GetImage((int)Images.CurrentCharacter);
        _currentCharacter.sprite = Managers.Resource.Load<Sprite>($"Character/{saveData._rarity}/{saveData._currentCharacter}_triangle");
    }
    public void ChangeClick(PointerEventData data)
    {
        ClosePopUPUI();
        Managers.UI.ShowPopUpUI<UI_CharacterSquare>();
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
