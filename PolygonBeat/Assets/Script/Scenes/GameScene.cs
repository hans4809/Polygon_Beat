using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Clear() 
    {

    }
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.GameScene;
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
