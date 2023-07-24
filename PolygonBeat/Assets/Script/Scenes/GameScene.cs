using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public List<GameObject> grounds;
    public List<string> blockResourceString;
    public string coinResourceString;
    public int[] coinIndex;
    [SerializeField] AudioSource _bgm;
    public override void Clear()
    {
        Managers.Sound.Stop(_bgm);
        for(int i =0; i < grounds.Count; i++)
        {
           Managers.Resource.Destroy(grounds[i]);
        }
        Managers.Map.Clear(grounds);

    }
    protected override void Init()
    {
        base.Init();
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        Managers.UI.ShowSceneUI<UI_GameScene>();
        Managers.UI.ShowAnyUI<UI_Effect>();
        ResetScene();
    }
    public void ResetScene()
    {
        SceneType = Define.Scene.GameScene;
        GameObject root = GameObject.Find("@Ground");
        if (root == null)
        {
            root = new GameObject { name = "@Ground" };
        }
        if (blockResourceString.Count == 0)
        {
            if (DataManager.singleTon.wholeGameData._currentSong == 5)
            {
                blockResourceString.Add("Block/bg1/bg1_defualt01");
                blockResourceString.Add("Block/bg1/bg1_defualt02");
                blockResourceString.Add("Block/bg1/bg1_defualt03");
                blockResourceString.Add("Block/bg1/bg1_defualt04");
            }
            else
            {
                blockResourceString.Add("Block/bg2/bg2_defualt01");
                blockResourceString.Add("Block/bg2/bg2_defualt02");
                blockResourceString.Add("Block/bg2/bg2_defualt03");
                blockResourceString.Add("Block/bg2/bg2_defualt04");
            }
            coinResourceString = "Icon/coin";
            Managers.Map.CreateGround(blockResourceString, grounds, coinResourceString, root.transform);
        }
        else
        {
            Managers.Map.CreateGround(blockResourceString, grounds, coinResourceString, root.transform);
            return;
        }
        Managers.Sound.PlayDelayed($"BGM/{DataManager.singleTon.wholeGameData._currentSong}", 3.0f, Define.Sound.BGM);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
