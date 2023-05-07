using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float time;
    int correct;
    int correct_average;
    int key_count;
    int sum;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        correct = 0;    
        correct_average = 0;
        key_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
     

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(time);
           

            if (time % 1.0 == 0.0) {
                Debug.Log("perfect");
                correct = 100;
            }
            if (time % 1.0 <= 0.1 || time % 1.0 >= 0.9)
            {
                Debug.Log("great");
                correct = 90;
            }

            else {
                Debug.Log("fail");
                correct = 0;
            }

            sum += correct;
            key_count++;

            correct_average = sum / key_count;

        }
    }
}
