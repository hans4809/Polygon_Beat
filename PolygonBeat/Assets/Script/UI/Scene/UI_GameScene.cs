using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    public Image[] lives;
    public Text coinText;
    int life = 3;
    float time = 0;
    public enum GameObjects
    {
        PauseButton,
        life0,
        life1,
        life2,
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
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.PauseButton).AddUIEvent(PauseClick);
        coinText = Get<GameObject>((int)GameObjects.CoinText).GetComponent<Text>();
        coinText.text = $": {DataManager.singleTon.wholeGameData._coin}";
        Managers.Sound.Play($"Sounds/BGM/{DataManager.singleTon.wholeGameData._currentSong}");
        lives[0] = Get<GameObject>((int)GameObjects.life0).GetComponent<Image>();
        lives[0].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[1] = Get<GameObject>((int)GameObjects.life1).GetComponent<Image>();
        lives[1].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
        lives[2] = Get<GameObject>((int)GameObjects.life2).GetComponent<Image>();
        lives[2].sprite = Managers.Resource.Load<Sprite>("UI/Icon/heart_red");
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
        coinText.text = $": {DataManager.singleTon.wholeGameData._coin}";
        if(Managers.Sound._audioSources[(int)Define.Sound.BGM].time == 0)
        {
            time += Time.deltaTime;
            if (time >= 0 && time < 1)
            {
                GetText((int)GameObjects.Count).text = "3";
            }
            if (time >= 1 && time < 2)
            {
                GetText((int)GameObjects.Count).text = "2";
            }
            if (time >= 2 && time < 3)
            {
                GetText((int)GameObjects.Count).text = "1";
            }
        }
    }
}
