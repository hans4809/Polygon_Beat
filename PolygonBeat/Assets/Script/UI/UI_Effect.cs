using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Effect : UI_Base
{
    [SerializeField] Animator effectAnimator = null;
    [SerializeField] Animator perfectAnimator = null;
    [SerializeField] Animator missAnimator = null;
    [SerializeField] List<Sprite> groundGlow;
    [SerializeField] List<Sprite> groundGray;
    [SerializeField] GameScene gameScene;
    [SerializeField] Canvas effectCanvas;
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
        gameScene = FindAnyObjectByType<GameScene>();
        effectCanvas = this.GetComponent<Canvas>();
        effectCanvas.renderMode = RenderMode.WorldSpace;
        effectCanvas.worldCamera = Camera.main;
        effectCanvas.sortingOrder = 5;
        Bind<Animator>(typeof(Effects));
        perfectAnimator = Get<Animator>((int)Effects.Perfect);
        missAnimator = Get<Animator>((int)Effects.Miss);
        effectAnimator = Get<Animator>((int)Effects.Effect);
        effectAnimator.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 2);
        effectAnimator.gameObject.transform.localScale = new Vector3(1.5f, 1, 1);
        if(groundGray.Count == 0 && groundGlow.Count == 0)
        {
            InsertSprties();
        }
        else
        {
            groundGlow.RemoveRange(0, groundGlow.Count);
            groundGray.RemoveRange(0, groundGray.Count);
            InsertSprties();
        }
    }
    public void InsertSprties()
    {
        switch (DataManager.singleTon.wholeGameData._currentSong)
        {
            case 5:
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow02"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow02"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow03"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg1/bg1_glow04"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b01"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b02"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b03"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_b04"));
                break;
            case 7:
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow01"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow02"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow03"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg2/bg2_glow04"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w01"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w02"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w03"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w04"));
                break;
            case 9:
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg3/bg3_glow01"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg3/bg3_glow02"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg3/bg3_glow03"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg3/bg3_glow04"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w01"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w02"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w03"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w04"));
                break;
            case 10:
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg4/bg4_glow01"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg4/bg4_glow02"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg4/bg4_glow03"));
                groundGlow.Add(Managers.Resource.Load<Sprite>("block/bg4/bg4_glow04"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w01"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w02"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w03"));
                groundGray.Add(Managers.Resource.Load<Sprite>("block/gray/gray_w04"));
                break;
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
        effectAnimator.transform.localPosition = new Vector3(2 * position, 0, 0);
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
        perfectAnimator.transform.localPosition = new Vector3(postion, 3.5f, 0);
        perfectAnimator.SetTrigger(hit);
    }
    public void Miss(int postion)
    {
        missAnimator.transform.localPosition = new Vector3(postion, 3.5f, 0);
        missAnimator.SetTrigger(hit);
    }
}
