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
        DataManager.singleTon.saveData._changeSprite = _changeImage.sprite;
    }
    private void Update()
    {
        if (_changeImage.color != Color.gray)
            this.GetComponent<Button>().gameObject.AddUIEvent(ChangeImage);
    }
}
