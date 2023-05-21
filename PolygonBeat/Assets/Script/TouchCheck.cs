using UnityEngine;
using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;

public class TouchCheck : MonoBehaviour
{
    public AnalyzeExample analyzeExample;
    int i;
    float range;
    float time;
    Queue<float> StartArea = new Queue<float>();
    Queue<float> EndArea = new Queue<float>();
    float startPoint;
    float endPoint;
    float startarea;   
    float endarea;    

    private void Start()
    {
        time = 0.0f;
        Init();
    }

    private void BeatTimeInform() //��Ʈ �޾ƿ���
    {
        if (analyzeExample != null)
        {
            List<Beat> beats_ = analyzeExample.beats;
            range = analyzeExample.beats[1].timestamp - analyzeExample.beats[0].timestamp; //�������� ����
            range = range * 9 / 20; 
            
        }
    }

    
    private void Init()
    {
        BeatTimeInform();

        for (i = 0; i < analyzeExample.beats.Count; i++)
        {
            startarea = analyzeExample.beats[i].timestamp-range;
            StartArea.Enqueue(analyzeExample.beats[i].timestamp - range);
        }

        for (i = 0; i < analyzeExample.beats.Count; i++)
        {
            endarea = analyzeExample.beats[i].timestamp-range;
            EndArea.Enqueue(endarea);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = StartArea.Dequeue();
            endPoint = EndArea.Dequeue();

            if (time >= startPoint && time <= endPoint)
            {
                Debug.Log(time + "clear");
                Debug.Log(startPoint+ " " + endPoint);  
            }

            else
            {
                Debug.Log(time + "miss"); // ��Ʈ �ϳ� ����
                Debug.Log(startPoint+ " " + endPoint);  
            }
        }
    }
}

