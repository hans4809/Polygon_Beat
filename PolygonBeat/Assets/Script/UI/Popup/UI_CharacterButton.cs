using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterButton : UI_Button
{
    Image _image;
    // Start is called before the first frame update
    public override void Init()
    {
        _image = this.GetComponent<Image>();
        //GetButton((int)Buttons.Character1).gameObject.ADDUIEvent(OnButtonClicked);
    }
    void Start()
    {
        Init();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
