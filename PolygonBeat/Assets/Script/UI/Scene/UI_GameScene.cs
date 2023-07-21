using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UI_GameScene : UI_Scene
{
    public List<Image> lives = new List<Image>();
    public Text coinText;
    public Text count;
    int life = 3;
    float time = 0;
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
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        GetButton((int)Buttons.PauseButton).gameObject.AddUIEvent(PauseClick);
        lives.Add(GetImage((int)Images.life0));
        lives.Add(GetImage((int)Images.life0));
        lives.Add(GetImage((int)Images.life0));
        coinText = GetText((int)Texts.CoinText);
        count = GetText((int)Texts.Count);
        lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        coinText.text = $": {DataManager.singleTon.wholeGameData._coin}";
    }
    public void PauseClick(PointerEventData data)
    {
        Managers.UI.ShowPopUpUI<UI_GamePause>();
    }
    public void LifeReduce()
    {
        life--;

        switch (life)
        {
            case 2:
                lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_grey");
                break;
            case 1:
                lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_grey");
                break;
            case 0:
                lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_grey");
                break;
        }
    }
    private void Update()
    {
        if (life <= 0)
        {
            Time.timeScale = 0;
            Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
            Managers.UI.ShowPopUpUI<UI_GameOver>();
        }
        //coinText.text = $": {DataManager.singleTon.wholeGameData._coin}";
        if(Managers.Sound._audioSources[(int)Define.Sound.BGM].time == 0)
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
    }
}
