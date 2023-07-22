using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TouchCheckByJson : MonoBehaviour
{
    int beatIndex = 0;
    int position = 1;
    float clickedtime;
    float leastTime;
    float maxTime;
    [SerializeField] float boundary;
    bool clicked;
    bool cleared;
    bool missed;
    //[SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;
    //[SerializeField] MusicPlayerManager musicPlayerManager;
    //[SerializeField] EffectManager effectManager;
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField] UI_GameScene ui_GameScene;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        bgmPlayer = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        playerRotate = FindObjectOfType<PlayerRotate>();
        ui_GameScene = FindObjectOfType<UI_GameScene>();
    }
    public void Init()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;
        beatIndex = 0;
        clicked = false;
        cleared = false;
        missed = false;
        leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
    }
    private void Update()
    {
        OnKeyboard();
    }
    IEnumerator touchDelay()
    {
        boundary = DataManager.singleTon.currentMusic.beatData[beatIndex + 1].touchTime - DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime;
        beatIndex++;
        clicked = false;
        missed = false;
        cleared = false;
        yield return new WaitForSeconds(boundary * 2);
    }

    void OnKeyboard()
    {
        if (bgmPlayer.time == 0)
        {
            return;
        }
        if ((!clicked) && (!cleared) && (!missed))
        {
            clickedtime = bgmPlayer.time;
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            if (Input.anyKeyDown)
            {
                if (clickedtime >= leastTime && clickedtime <= maxTime)
                {
                    clicked = true;
                    cleared = true;
                    position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
                    //effectManager.HitEffect(position);
                    //effectManager.Perfect(position);
                    //musicPlayerManager.PlaySFX("touch");
                    ui_GameScene.HitEffect(position);
                    ui_GameScene.Perfect(position);
                    Managers.Sound.Play("Sounds/SFX/Touch");
                    StartCoroutine(touchDelay());
                }
                else
                {
                    clicked = true;
                    missed = true;
                    position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
                    //effectManager.Miss(position);
                    ui_GameScene.Miss(position);
                    Managers.Sound.Play("Sounds/SFX/Touch");
                    //musicPlayerManager.PlaySFX("touch");
                }
            }
        }
        if (bgmPlayer.time >= maxTime && (!clicked))
        {
            missed = true;
            position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
            //effectManager.Miss(position);
            ui_GameScene.Miss(position);

        }
        if (missed)
        {
            ui_GameScene.LifeReduce();
            missed = false;
            StartCoroutine(touchDelay());
        }
    }
}
