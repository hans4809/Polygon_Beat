using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TouchCheck;

public class TimeCheck : MonoBehaviour
{
    //�ϴ� ��ġ üũ Stack<TimeRange> timeRangeStack = new Stack<TimeRange>();
    int i; 

    Stack<List<TimeRange>> timeRangeStack = new Stack<List<TimeRange>>();

    public class TimeRange
    {
        //public float start;
        public float end;

        List<TimeRange> rangeList = new List<TimeRange>();

        // �ð� ���� 1 �߰�
        //for ( int = 0; i<analyzeExample.beats.Count; i++)
        //{    
         //   TimeRange range1 = new TimeRange();
           // rangei.start = timestamp-check_range1;
          //  rangei.end = timestamp-check_range1;
           // rangeList.Add(rangei);
        }
        
// �ð� ���� 2 �߰�

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0)) 
       // {
         //   Debug.Log(Time.deltaTime);
       // }
    }
}
