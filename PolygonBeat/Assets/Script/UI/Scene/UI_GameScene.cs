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
    [SerializeField] List<Sprite> groundGlow;
    [SerializeField] List<Sprite> groundGray;
    [SerializeField] UI_GameOver gameOver;
    [SerializeField] public int life = 3;
    [SerializeField] public float time = 0;

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
        transform.GetComponent<Canvas>().sortingOrder = 5;
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        GetButton((int)Buttons.PauseButton).gameObject.AddUIEvent(PauseClick);
        lives.Add(GetImage((int)Images.life0));
        lives.Add(GetImage((int)Images.life1));
        lives.Add(GetImage((int)Images.life2));
        coinText = GetText((int)Texts.CoinText);
        count = GetText((int)Texts.Count);
        lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        coinText.text = $" : {DataManager.singleTon.wholeGameData._coin}";
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
            if (!count.isActiveAndEnabled)
                count.gameObject.SetActive(true);
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
            if(count.isActiveAndEnabled)
                count.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _bgm.Pause();
            Time.timeScale = 0f;
            Managers.UI.ShowPopUpUI<UI_GamePause>();
        }
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
}
