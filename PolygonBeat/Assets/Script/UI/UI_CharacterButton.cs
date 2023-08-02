using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterButton : UI_Base
{
    Image _changeImage;
    Image _currentImage;
    public override void Init()
    {
        _changeImage = this.GetComponent<Image>();
        _currentImage = GameObject.Find("CurrentCharacter").GetComponent<Image>();
        if(_changeImage.color != Color.gray)
            this.GetComponent<Button>().gameObject.AddUIEvent(ChangeImage);
    }
    void Start()
    {
        Init();
    }
    public void ChangeImage(PointerEventData data)
    {
        Managers.Sound.Play("Sounds/SFX/Select");
        _currentImage.sprite = _changeImage.sprite;
        if (_changeImage.sprite.name.Contains("default"))
        {
            DataManager.singleTon.saveData._rarity = "default";
            DataManager.singleTon.saveData._currentCharacter = _changeImage.sprite.name.Substring(0, _changeImage.sprite.name.IndexOf("_"));
        }
        else if(_changeImage.sprite.name.Contains("normal"))
        {
            DataManager.singleTon.saveData._rarity = "normal";
            DataManager.singleTon.saveData._currentCharacter = _changeImage.sprite.name.Substring(0, _changeImage.sprite.name.IndexOf("_"));
        }
        else if (_changeImage.sprite.name.Contains("rare"))
        {
            DataManager.singleTon.saveData._rarity = "rare";
            DataManager.singleTon.saveData._currentCharacter = _changeImage.sprite.name.Substring(0, _changeImage.sprite.name.IndexOf("_"));
        }
        else if (_changeImage.sprite.name.Contains("epic"))
        {
            DataManager.singleTon.saveData._rarity = "epic";
            DataManager.singleTon.saveData._currentCharacter = _changeImage.sprite.name.Substring(0, _changeImage.sprite.name.IndexOf("_"));
        }
    }
    private void Update()
    {
        if (_changeImage.color != Color.gray)
            this.GetComponent<Button>().gameObject.AddUIEvent(ChangeImage);
    }
}
