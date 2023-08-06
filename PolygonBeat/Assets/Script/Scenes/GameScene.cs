using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public List<GameObject> grounds;
    public List<GameObject> backGround;
    public List<string> blockResourceString;
    public List<string> bgResourceString;
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
            ResourceString();
            coinResourceString = "Icon/coin";
            Managers.Map.CreateGround(blockResourceString, grounds, coinResourceString, root.transform);
        }
        else
        {
            blockResourceString.RemoveRange(0, blockResourceString.Count);
            ResourceString();
            Managers.Map.CreateGround(blockResourceString, grounds, coinResourceString, root.transform);
            return;
        }
        Managers.Sound.PlayDelayed($"BGM/{DataManager.singleTon.wholeGameData._currentSong}", 3.0f, Define.Sound.BGM);
    }
    public void ResourceString()
    {
        switch (DataManager.singleTon.wholeGameData._currentSong)
        {
            case 5:
                blockResourceString.Add("Block/bg1/bg1_defualt01");
                blockResourceString.Add("Block/bg1/bg1_defualt02");
                blockResourceString.Add("Block/bg1/bg1_defualt03");
                blockResourceString.Add("Block/bg1/bg1_defualt04");
                bgResourceString.Add("BackGround/5/bg1");
                break;
            case 7:
                blockResourceString.Add("Block/bg2/bg2_defualt01");
                blockResourceString.Add("Block/bg2/bg2_defualt02");
                blockResourceString.Add("Block/bg2/bg2_defualt03");
                blockResourceString.Add("Block/bg2/bg2_defualt04");
                bgResourceString.Add("BackGround/7/bg2");
                break;
            case 9:
                blockResourceString.Add("Block/bg3/bg3_defualt01");
                blockResourceString.Add("Block/bg3/bg3_defualt02");
                blockResourceString.Add("Block/bg3/bg3_defualt03");
                blockResourceString.Add("Block/bg3/bg3_defualt04");
                bgResourceString.Add("BackGround/9/9_1");
                bgResourceString.Add("BackGround/9/9_2");
                bgResourceString.Add("BackGround/9/9_3");
                bgResourceString.Add("BackGround/9/9_4");
                bgResourceString.Add("BackGround/9/9_5");
                bgResourceString.Add("BackGround/9/9_6");
                break;
            case 10:
                blockResourceString.Add("Block/bg4/bg4_defualt01");
                blockResourceString.Add("Block/bg4/bg4_defualt02");
                blockResourceString.Add("Block/bg4/bg4_defualt03");
                blockResourceString.Add("Block/bg4/bg4_defualt04");
                bgResourceString.Add("BackGround/10/10_1");
                bgResourceString.Add("BackGround/10/10_2");
                bgResourceString.Add("BackGround/10/10_2_1");
                bgResourceString.Add("BackGround/10/10_3");
                bgResourceString.Add("BackGround/10/10_3_1");
                bgResourceString.Add("BackGround/10/10_3_2");
                bgResourceString.Add("BackGround/10/10_4");
                bgResourceString.Add("BackGround/10/10_4_1");
                bgResourceString.Add("BackGround/10/10_4_2");
                bgResourceString.Add("BackGround/10/10_5");
                bgResourceString.Add("BackGround/10/10_5_1");
                bgResourceString.Add("BackGround/10/10_5_2");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
