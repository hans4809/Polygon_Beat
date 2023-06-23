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
    //Queue<float> Boundary = new Queue<float>();
    //Queue<float> CorrectArea = new Queue<float>();
    //Queue<float> BeatsStamp = new Queue<float>();
    [SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;
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
        player = GameObject.Find("Player");
        leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
        maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
    }
    /*private void BeatTimeInform()
    {
        for (i = 0; i < DataManager.singleTon.currentMusic.beatData.Count - 1; i++)
        {
            Boundary.Enqueue((DataManager.singleTon.currentMusic.beatData[i+1].touchTime + DataManager.singleTon.currentMusic.beatData[i].touchTime) / 2f); //경계값 설정
        }

        for (i = 0; i < DataManager.singleTon.currentMusic.beatData.Count - 1; i++)
        {
            CorrectArea.Enqueue((DataManager.singleTon.currentMusic.beatData[i+1].touchTime - DataManager.singleTon.currentMusic.beatData[i].touchTime) * 0.45f); //오차허용범위.마지막 비트는 오차범위없음
        }

        for (i = 0; i < DataManager.singleTon.currentMusic.beatData.Count; i++)
        {
            BeatsStamp.Enqueue(DataManager.singleTon.currentMusic.beatData[i].touchTime);
        }
    }*/
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
            position = (int)(player.transform.position.x + 0.1);
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (clickedtime >= leastTime && clickedtime <= maxTime)
                {
                    clicked = true;
                    cleared = true;
                    Debug.Log("CLEAR");
                    effectManager.HitEffect(position);
                    StartCoroutine(touchDelay());
                }
                else
                {
                    clicked = true;
                    missed = true;
                    Debug.LogError("MISS");
                }
            }
        }
        if (bgmPlayer.time >= maxTime&&(!clicked))
        {
            missed = true;
            Debug.LogError("MISS");
        }
        if(missed)
        {
            lifeManager.LifeReduce();
            missed = false;
            StartCoroutine(touchDelay());
        }
    }
            /*if (clickedtime >= BeforeBoundary && bgmPlayer.time < Boundary.Peek())
            {
                if (!clicked)
                {
                    if (clickedtime >= BeforeBoundary && clickedtime < BeatsStamp.Peek() - CorrectArea.Peek())
                    {
                        Debug.Log("Miss");
                        lifeManager.LifeReduce();
                        clicked = true;
                        missed = true;
                    }

                    else if (clickedtime >= BeatsStamp.Peek() - CorrectArea.Peek() && clickedtime < BeatsStamp.Peek() + CorrectArea.Peek())
                    {
                        Debug.Log("Clear");
                        cleared = true;
                        clicked = true;
                    }
                    else if (clickedtime >= BeatsStamp.Peek() + CorrectArea.Peek() && bgmPlayer.time < Boundary.Peek())
                    {
                        Debug.Log("Miss");
                        lifeManager.LifeReduce();
                        clicked = true;
                        missed = true;
                    }
                }
            }*/

        /*if (bgmPlayer.time >= Boundary.Peek())
        {
            if (!clicked && !cleared && !missed)
            {
                Debug.Log("Miss");
                lifeManager.LifeReduce();
            }
            cleared = false;
            clicked = false;
            missed = false;
            BeforeBoundary = Boundary.Dequeue();
            BeatsStamp.Dequeue();
            CorrectArea.Dequeue();
        }*/

}
