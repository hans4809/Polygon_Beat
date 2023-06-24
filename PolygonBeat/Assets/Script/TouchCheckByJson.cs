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
    float boundary = 0.2f;
    bool clicked;
    bool cleared;
    bool missed;
    [SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] MusicPlayerManager musicPlayerManager;
    [SerializeField] EffectManager effectManager;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
        cleared = false;
        missed = false;
        //BeatTimeInform();
        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        lifeManager = FindObjectOfType<LifeManager>();
        effectManager = FindObjectOfType<EffectManager>();
        musicPlayerManager = FindObjectOfType<MusicPlayerManager>();
        player = GameObject.Find("Player");
        leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
    }

    IEnumerator touchDelay()
    {
        beatIndex++;
        clicked = false;
        missed = false;
        cleared = false;
        yield return new WaitForSeconds(boundary*2);
    }
    // Update is called once per frame
    void Update()
    {
        if (bgmPlayer.time == 0)
        {
            return;
        }
        if ((!clicked)&&(!cleared)&&(!missed))
        {
            clickedtime = bgmPlayer.time;
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (clickedtime >= leastTime && clickedtime <= maxTime)
                {
                    clicked = true;
                    cleared = true;
                    position = (int)(player.transform.position.x + 0.5);
                    effectManager.HitEffect(position);
                    effectManager.Perfect(position);
                    musicPlayerManager.PlaySFX("touch");
                    StartCoroutine(touchDelay());
                }
                else
                {
                    clicked = true;
                    missed = true;
                    position = (int)(player.transform.position.x + 0.5);
                    effectManager.Miss(position);
                    musicPlayerManager.PlaySFX("touch");
                    Debug.LogError("MISS");
                }
            }
        }
        if (bgmPlayer.time >= maxTime&&(!clicked))
        {
            missed = true;
            position = (int)(player.transform.position.x + 0.5);
            effectManager.Miss(position);
            Debug.LogError("MISS");
        }
        if(missed)
        {
            lifeManager.LifeReduce();
            missed = false;
            StartCoroutine(touchDelay());
        }
    }
}
