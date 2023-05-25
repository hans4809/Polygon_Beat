using UnityEngine;
using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class TouchCheck : MonoBehaviour
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
    public AnalyzeExample analyzeExample;
    public LifeManager lifeManager;
    


    private void Start()
    {
        
        time = 0.0f;
        BeforeBoundary = 0.0f;
        clicked = false;
        cleared = false;
        missed = false;
        BeatTimeInform();
        analyzeExample = new AnalyzeExample();
        lifeManager = new LifeManager();
        lifeManager = FindObjectOfType<LifeManager>();
    }

    private void BeatTimeInform() 
    {        
        for (i = 0; i < analyzeExample.beats.Count - 1; i++)
        {
            Boundary.Enqueue((analyzeExample.beats[i].timestamp + analyzeExample.beats[i + 1].timestamp) / 2f); //경계값 설정
        }

        for (i = 0; i < analyzeExample.beats.Count - 1; i++)
        {
           CorrectArea.Enqueue((analyzeExample.beats[i+1].timestamp - analyzeExample.beats[i].timestamp) *0.45f); //오차허용범위.마지막 비트는 오차범위없음
        }

        for (i = 0; i < analyzeExample.beats.Count; i++) 
        {
            BeatsStamp.Enqueue(analyzeExample.beats[i].timestamp);
        }
    }



    private void Update()
    {
        

        time += Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) 
        {
            clickedtime = time;
            if (clickedtime >= BeforeBoundary && time < Boundary.Peek()) 
            {
                if (!clicked)
                {
                    if(clickedtime >= BeforeBoundary && clickedtime < BeatsStamp.Peek() - CorrectArea.Peek())
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
                    

                    else if (clickedtime >= BeatsStamp.Peek() + CorrectArea.Peek() && time < Boundary.Peek()) 
                    {
                        Debug.Log("Miss");
                        lifeManager.LifeReduce();
                        clicked = true;
                        missed = true;
                    }
                }
            }
        }

        if (time >= Boundary.Peek()) 
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
