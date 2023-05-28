using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.UI;

public class TouchCheckByJson : MonoBehaviour
{
    int beatIndex;
    float time;
    float clickedtime;
    float leastTime;
    float maxTime;
    float boundary;
    bool clicked;
    //bool cleared;
    //bool missed;
    //Queue<float> Boundary = new Queue<float>();
    //Queue<float> CorrectArea = new Queue<float>();
    //Queue<float> BeatsStamp = new Queue<float>();
    [SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;

    // Start is called before the first frame update
    void Start()
    {
        beatIndex = 0;
        boundary = 0.2f;
        clicked = false;
        //cleared = false;
        //missed = false;
        //BeatTimeInform();
        lifeManager = GameObject.Find("GameOverManager").GetComponent<LifeManager>();
        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
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
        yield return new WaitForSeconds(DataManager.singleTon.currentMusic.beatData[beatIndex+1].touchTime - DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime);
        clicked = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (bgmPlayer.time == 0)
        {
            return;
        }
        if (!clicked)
        {
            clicked = true;
            clickedtime = bgmPlayer.time;
            Debug.Log(beatIndex);
            leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
            maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
            beatIndex++;
            if (Input.GetMouseButtonDown(0))
            {
                clicked = true;
                clickedtime = bgmPlayer.time;
                Debug.Log(beatIndex);
                leastTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime - boundary;
                maxTime = DataManager.singleTon.currentMusic.beatData[beatIndex].touchTime + boundary;
                beatIndex++;
                if (clickedtime >= leastTime && clickedtime <= maxTime)
                {
                    Debug.Log("CORRECT");
                }
                else
                {
                    Debug.Log("MISS");
                    lifeManager.LifeReduce();
                }
                StartCoroutine(touchDelay());
            }
            else
            {
                if (bgmPlayer.time >= maxTime)
                {
                    Debug.Log(maxTime);
                    Debug.LogError("MISS");
                    lifeManager.LifeReduce();
                }
                StartCoroutine(touchDelay());
            }
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
