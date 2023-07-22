using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_GameScene : UI_Scene
{
    [SerializeField] List<Image> lives = new List<Image>();
    [SerializeField] Text coinText;
    [SerializeField] Text count;
    [SerializeField] AudioSource _bgm;
    [SerializeField] Animator effectAnimator = null;
    [SerializeField] Animator perfectAnimator = null;
    [SerializeField] Animator missAnimator = null;
    [SerializeField] List<Sprite> groundGlow;
    [SerializeField] List<Sprite> groundGray;
    [SerializeField] GameScene gameScene;
    [SerializeField] UI_GameOver gameOver;
    [SerializeField] public int life = 3;
    [SerializeField] public float time = 0;
    string hit = "Hit";

    public enum Buttons
    {
        PauseButton,
    }
    public enum Images
    {
        life0,
        life1,
        life2
    }
    public enum Texts
    {
        CoinText,
        Count
    }
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
    public void Clear()
    {
        lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        time = 0f;
        life = 3;
    }
    public override void Init()
    {
        base.Init();
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        gameScene = FindAnyObjectByType<GameScene>();
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        Bind<Animator>(typeof(Effects));
        GetButton((int)Buttons.PauseButton).gameObject.AddUIEvent(PauseClick);
        lives.Add(GetImage((int)Images.life0));
        lives.Add(GetImage((int)Images.life1));
        lives.Add(GetImage((int)Images.life2));
        coinText = GetText((int)Texts.CoinText);
        count = GetText((int)Texts.Count);
        perfectAnimator = Get<Animator>((int)Effects.Perfect);
        missAnimator = Get<Animator>((int)Effects.Miss);
        effectAnimator = Get<Animator>((int)Effects.Effect);
        lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        coinText.text = $" : {DataManager.singleTon.wholeGameData._coin}";
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
    public void PauseClick(PointerEventData data)
    {
        _bgm.Pause();
        Time.timeScale = 0f;
        Managers.UI.ShowPopUpUI<UI_GamePause>();
    }
    public void LifeReduce()
    {
        life--;

        switch (life)
        {
            case 2:
                lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_gray");
                break;
            case 1:
                lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_gray");
                break;
            case 0:
                lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_gray");
                break;
        }
    }
    public void Count()
    {
        if (_bgm.time == 0)
        {
            time += Time.deltaTime;
            if (time >= 0 && time < 1)
            {
                count.text = "3";
            }
            if (time >= 1 && time < 2)
            {
                count.text = "2";
            }
            if (time >= 2 && time < 3)
            {
                count.text = "1";
            }
        }
        if (_bgm.time > 0)
        {
            count.text = "";
        }
    }
    private void Update()
    {
        if (life <= 0)
        {
            Time.timeScale = 0;
            Managers.Sound.Stop(_bgm);
            if (gameOver == null)
            {
                gameOver = Managers.UI.ShowPopUpUI<UI_GameOver>();
            }
        }
        coinText.text = $" : {DataManager.singleTon.wholeGameData._coin}";
        Count();
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
