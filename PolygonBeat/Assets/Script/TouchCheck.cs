using UnityEngine;
using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;

public class TouchCheck : MonoBehaviour
{
    Queue<float> Boundary = new Queue<float>();
    Queue<float> CorrectArea = new Queue<float>();
    float BeforeBoundary;
    public AnalyzeExample analyzeExample;
    int i;
    float range;
    float time;
      

    private void Start()
    {
        time = 0.0f;
        BeforeBoundary= 0.0f;
        i = 0;
        BeatTimeInform();
        
    }

    private void BeatTimeInform() //비트 받아오기
    {
        

        for (i = 0; i < analyzeExample.beats.Count - 1; i++)
        {
            Boundary.Enqueue((analyzeExample.beats[i].timestamp + analyzeExample.beats[i + 1].timestamp) / 2); //경계값 설정
        }


        for (i = 0; i < analyzeExample.beats.Count - 1; i++)
        {
            CorrectArea.Enqueue((analyzeExample.beats[i].timestamp + analyzeExample.beats[i + 1].timestamp) *9 / 20); //오차허용범위
        }
    }

    
    
    private void Update()
    {
        BeatTimeInform();

        time += Time.deltaTime;

        while (time >= BeforeBoundary && time < Boundary.Peek()) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (time < analyzeExample.beats[i].timestamp - CorrectArea.Peek())
                {
                    Debug.Log("Miss"); //-하트
                }

                else if (time >= analyzeExample.beats[i].timestamp - CorrectArea.Peek() && time <= analyzeExample.beats[i].timestamp + CorrectArea.Peek())
                {
                    Debug.Log("Clear");
                }

                else if (time > analyzeExample.beats[i].timestamp + CorrectArea.Peek())
                {
                    Debug.Log("Miss"); //-하트
                }

                BeforeBoundary = Boundary.Dequeue();
                CorrectArea.Dequeue();
            }

            else 
            {
                Debug.Log("Miss"); //-하트
                BeforeBoundary = Boundary.Dequeue();
                CorrectArea.Dequeue();
            }


        }
        
        
    }
}

