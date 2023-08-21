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
        Managers.UI.ShowSceneUI<UI_MainScene>();
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}