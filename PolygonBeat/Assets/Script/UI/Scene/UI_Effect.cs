using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Effect : UI_Scene
{
    [SerializeField] Animator effectAnimator = null;
    [SerializeField] Animator perfectAnimator = null;
    [SerializeField] Animator missAnimator = null;
    [SerializeField] List<Sprite> groundGlow;
    [SerializeField] List<Sprite> groundGray;
    [SerializeField] GameScene gameScene;
    string hit = "Hit";
    public enum Effects
    {
        Perfect,
        Miss,
        Effect
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        gameScene = FindAnyObjectByType<GameScene>();
        Bind<Animator>(typeof(Effects));
        perfectAnimator = Get<Animator>((int)Effects.Perfect);
        missAnimator = Get<Animator>((int)Effects.Miss);
        effectAnimator = Get<Animator>((int)Effects.Effect);
        if (DataManager.singleTon.wholeGameData._currentSong == 5)
        {
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow02"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow02"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow03"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow04"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b01"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b02"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b03"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b04"));
        }
        else
        {
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow01"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow02"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow03"));
            groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow04"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w01"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w02"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w03"));
            groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w04"));
        }
    }
    public void HitEffect(int position)
    {
        switch (gameScene.grounds[position].name)
        {
            case "2":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGlow[1];
                break;
            case "3":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGlow[2];
                break;
            case "4":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGlow[3];
                break;
            default:
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGlow[0];
                break;
        }
        effectAnimator.transform.localPosition = new Vector3(position, 0, 0);
        effectAnimator.SetTrigger(hit);
        switch (gameScene.grounds[position].name)
        {
            case "2":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGray[1];
                break;
            case "3":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGray[2];
                break;
            case "4":
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGray[3];
                break;
            default:
                gameScene.grounds[position].GetComponent<SpriteRenderer>().sprite = groundGray[0];
                break;
        }
    }
    public void Perfect(int postion)
    {
        perfectAnimator.transform.localPosition = new Vector3(postion, 2, 0);
        perfectAnimator.SetTrigger(hit);
    }
    public void Miss(int postion)
    {
        missAnimator.transform.localPosition = new Vector3(postion, 2, 0);
        missAnimator.SetTrigger(hit);
    }
}
