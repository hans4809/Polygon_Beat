using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        Debug.Log("게임 실행 후 경과 시간: " + elapsedTime.ToString("F2") + "초");
    }


}
