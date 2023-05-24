using UnityEngine;
using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;

public class TouchCheck : MonoBehaviour
{
    float clickedtime;
    bool clicked;
    bool cleared;
    Queue<float> Boundary = new Queue<float>();
    float BeforeBoundary;
    public AnalyzeExample analyzeExample;
    int i;
    float time;


    private void Start()
    {
        time = 0.0f;
        BeforeBoundary = 0.0f;
        clicked = false;
        cleared = false;
        BeatTimeInform();
        

        

    }

    private void BeatTimeInform() //비트 받아오기
    {

        
        for (i = 0; i < analyzeExample.beats.Count - 1; i++)
        {
            Boundary.Enqueue((analyzeExample.beats[i].timestamp + analyzeExample.beats[i + 1].timestamp) / 2); //경계값 설정
        }

     
    }



    private void Update()
    {
        BeatTimeInform();

        time += Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) 
        {
            clickedtime = time;
            if (clickedtime >= BeforeBoundary && time < Boundary.Peek()) 
            {
                if (!clicked) 
                {
                    Debug.Log("Clear");
                    cleared = true;
                    clicked = true;
                }
            }
        }

        if (time >= Boundary.Peek()) 
        {
            if (!clicked && !cleared) 
            {
                Debug.Log("Miss");
                
            }

            cleared = false;
            clicked = false;
            BeforeBoundary = Boundary.Dequeue();
            Boundary.Dequeue();
        }




       

    }
}
