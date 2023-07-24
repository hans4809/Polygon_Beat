using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GachaGet : UI_Popup
{
    [SerializeField] UI_Gacha ui_Gacha;
    public enum GameObjects
    {
        Character,
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
        ui_Gacha = FindObjectOfType<UI_Gacha>();
        Get<GameObject>((int)GameObjects.Character).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>($"Character/{ui_Gacha.selectCharacter._rarity}/{ui_Gacha.selectCharacter._rarity}{ui_Gacha.selectCharacter._index}_square");
        Get<GameObject>((int)GameObjects.OK).AddUIEvent(OKClick);
    }
    public void OKClick(PointerEventData data)
    {
        ClosePopUPUI();
    }
}
