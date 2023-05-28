using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchCheckByJson : MonoBehaviour
{
    int i;
    float time;
    float clickedtime;
    float BeforeBoundary;
    bool clicked;
    bool cleared;
    bool missed;
    Queue<float> Boundary = new Queue<float>();
    Queue<float> CorrectArea = new Queue<float>();
    Queue<float> BeatsStamp = new Queue<float>();
    [SerializeField] LifeManager lifeManager;
    [SerializeField] AudioSource bgmPlayer;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        BeforeBoundary = 0.0f;
        clicked = false;
        cleared = false;
        missed = false;
        BeatTimeInform();
        lifeManager = GameObject.Find("GameOverManager").GetComponent<LifeManager>();
        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();

    }
    private void BeatTimeInform()
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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            clickedtime = time;
            if (clickedtime >= BeforeBoundary && bgmPlayer.time < Boundary.Peek())
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
            }
        }
        if (bgmPlayer.time >= Boundary.Peek())
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
        }
    }
}
