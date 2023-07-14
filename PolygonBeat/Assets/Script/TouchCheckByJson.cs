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
    [SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] MusicPlayerManager musicPlayerManager;
    [SerializeField] EffectManager effectManager;
    [SerializeField] PlayerRotate playerRotate;

    // Start is called before the first frame update
    void Start()
    {
        //Managers.CheckManager.KeyAction += OnKeyboard;
        //Managers.CheckManager.KeyAction -= OnKeyboard;
        beatIndex = 0;
        boundary = DataManager.singleTon.currentMusic.beatData[beatIndex + 1].touchTime - DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime;
        clicked = false;
        cleared = false;
        missed = false;
        //BeatTimeInform();
        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        lifeManager = FindObjectOfType<LifeManager>();
        effectManager = FindObjectOfType<EffectManager>();
        musicPlayerManager = FindObjectOfType<MusicPlayerManager>();
        playerRotate = FindObjectOfType<PlayerRotate>();
        leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
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
    IEnumerator touchDelay()
    {
        boundary = DataManager.singleTon.currentMusic.beatData[beatIndex + 1].touchTime - DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime;
        beatIndex++;
        clicked = false;
        missed = false;
        cleared = false;
        yield return new WaitForSeconds(boundary * 2);
    }
    // Update is called once per frame
    void Update()
    {
        OnKeyboard();
    }

    void OnKeyboard()
    {
        if (musicPlayerManager.GetBGMPlayer().time == 0)
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
                    effectManager.HitEffect(position);
                    effectManager.Perfect(position);
                    musicPlayerManager.PlaySFX("touch");
                    StartCoroutine(touchDelay());
                }
                else
                {
                    clicked = true;
                    missed = true;
                    position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
                    effectManager.Miss(position);
                    musicPlayerManager.PlaySFX("touch");
                }
            }
        }
        if (bgmPlayer.time >= maxTime && (!clicked))
        {
            missed = true;
            position = (int)(playerRotate.GetPlayer().transform.position.x + 0.5);
            effectManager.Miss(position);
        }
        if (missed)
        {
            lifeManager.LifeReduce();
            missed = false;
            StartCoroutine(touchDelay());
        }
    }
}
