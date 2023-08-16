using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : BaseScene
{
    public override void Clear() { }
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.StageSelect;
        Managers.UI.ShowSceneUI<UI_StageSelect>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
