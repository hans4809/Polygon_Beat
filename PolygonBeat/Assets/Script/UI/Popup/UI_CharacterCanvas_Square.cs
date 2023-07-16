using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterCanvas_Square : UI_Popup
{
    enum GameObjects
    {
        CharacterPanel
    }
    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject characterPanel = Get<GameObject>((int)GameObjects.CharacterPanel);
        List<Button> buttons = new List<Button>();
        buttons.AddRange(characterPanel.GetComponentsInChildren<Button>()) ;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
