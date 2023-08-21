using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GachaGet : UI_Popup
{
    [SerializeField] Gacha Gacha;
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
        Gacha = FindObjectOfType<Gacha>();
        Get<GameObject>((int)GameObjects.Character).GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>($"Character/{Gacha.selectCharacter._rarity}/{Gacha.selectCharacter._rarity}{Gacha.selectCharacter._index}_square");
        Get<GameObject>((int)GameObjects.OK).AddUIEvent(OKClick);
    }
    public void OKClick(PointerEventData data)
    {
        ClosePopUPUI();
    }
}
