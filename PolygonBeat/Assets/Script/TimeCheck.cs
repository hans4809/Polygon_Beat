using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TouchCheck;

public class TimeCheck : MonoBehaviour
{
    //일단 터치 체크 Stack<TimeRange> timeRangeStack = new Stack<TimeRange>();
    int i; 

    Stack<List<TimeRange>> timeRangeStack = new Stack<List<TimeRange>>();

    public class TimeRange
    {
        //public float start;
        public float end;

        List<TimeRange> rangeList = new List<TimeRange>();

        // 시간 범위 1 추가
        //for ( int = 0; i<analyzeExample.beats.Count; i++)
        //{    
         //   TimeRange range1 = new TimeRange();
           // rangei.start = timestamp-check_range1;
          //  rangei.end = timestamp-check_range1;
           // rangeList.Add(rangei);
        }
        
// 시간 범위 2 추가

    

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
