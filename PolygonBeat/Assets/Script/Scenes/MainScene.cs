using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    public override void Clear() { }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.MainScene;
        Managers.Sound.Play("Sounds/BGM/Main_Menu", Define.Sound.BGM);
        Managers.UI.ShowSceneUI<UI_MainScene>();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}