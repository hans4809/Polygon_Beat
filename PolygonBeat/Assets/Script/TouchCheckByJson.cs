using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchCheckByJson : MonoBehaviour
{
    [SerializeField] int beatIndex = 0;
    int position = 1;
    float clickedTime;
    float leastTime;
    float maxTime;
    float preMaxTime;
    [SerializeField] float boundary = 0.15f;
    bool clicked;
    bool cleared;
    bool missed;
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField] UI_GameScene ui_GameScene;
    [SerializeField] UI_Effect ui_Effect;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        bgmPlayer = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        playerRotate = FindObjectOfType<PlayerRotate>();
        ui_GameScene = FindAnyObjectByType<UI_GameScene>();
        ui_Effect = FindAnyObjectByType<UI_Effect>();

    }
    public void Init()
    {
        beatIndex = 0;
        clicked = false;
        cleared = false;
        missed = false;
        leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
    }
    private void Update()
    {
        OnMouseClick();
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
    public void OnMouseClick()
    {
        if (bgmPlayer.time == 0 || Managers.UI.Root.transform.childCount != 2)
        {
            return;
        }
        if ((!clicked) && (!cleared) && (!missed))
        {
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            if (Input.GetMouseButtonDown(0))
            {
                clickedTime = bgmPlayer.time;
                if (clickedTime >= leastTime && clickedTime <= maxTime)
                {
                    clicked = true;
                    cleared = true;
                    position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
                    ui_Effect.HitEffect(position/2);
                    ui_Effect.Perfect(position);
                    Managers.Sound.Play("Sounds/SFX/Touch");
                }
                else
                {
                    clicked = true;
                    missed = true;
                    position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
                    ui_Effect.Miss(position);
                    Managers.Sound.Play("Sounds/SFX/Touch");
                    ui_GameScene.LifeReduce();
                }
                preMaxTime = maxTime;
                beatIndex++;
                leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
                maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            }
        }
        if (bgmPlayer.time <= maxTime && clicked)
        {
            clicked = false;
            missed = false;
            cleared = false;
        }
        if (bgmPlayer.time >= maxTime && (!clicked))
        {
            missed = true;
            position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
            ui_Effect.Miss(position);
            ui_GameScene.LifeReduce();
            preMaxTime = maxTime;
            beatIndex++;
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            if (bgmPlayer.time <= maxTime)
            {
                clicked = false;
                missed = false;
                cleared = false;
            }
        }

        //if (missed)
        //{
        //  ui_GameScene.LifeReduce();
        //missed = false;
        //preMaxTime = maxTime;
        //beatIndex++;
        //leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        //maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
        //if (bgmPlayer.time <= maxTime)
        //{
        //clicked = false;
        //missed = false;
        //cleared = false;
        //}
        //}
    }
}
