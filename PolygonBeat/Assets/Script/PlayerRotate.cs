using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.AnnotationUtility;

public class PlayerRotate : MonoBehaviour
{  
    public Vector3 rotation;
    public List<GameObject> parentObject;
    public Vector3 parentPosition;
    public GameObject childObject;
    public AnalyzeExample analyzeExample;
    float rotateSpeed;
    float time = 0f;
    int i = 0;
    void SwapParent(GameObject childObject, GameObject preParentObject, GameObject nextParentObject)
    {
        parentPosition.x += 1;
        nextParentObject.transform.SetParent(null);
        nextParentObject.transform.localEulerAngles = Vector3.zero;
        childObject.transform.SetParent(nextParentObject.transform);
        preParentObject.transform.SetParent(childObject.transform);
        childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, 0.11f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // parent 오차 수정
        childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // child 오차 수정
    }
    void SetRotation(GameObject childObject)
    {
        for(int i=0; i < 3; i++)
            childObject.transform.GetChild(i).localEulerAngles = Vector3.zero;
    }
    void Start()
    {
        parentObject[0].transform.SetParent(null);
        parentPosition = parentObject[0].transform.localPosition;
        childObject.transform.SetParent(parentObject[0].transform);
        childObject.transform.parent.localEulerAngles = Vector3.zero;
        childObject.transform.localEulerAngles = Vector3.zero;
        childObject.transform.parent.localPosition = parentPosition;
        childObject.transform.localPosition = new Vector3(-5, 5, 0);
        rotateSpeed = analyzeExample.beats[0].bpm;
    }
    private float GetRotateSpeed(int index)
    {
        return 1 / (analyzeExample.beats[index + 1].timestamp - analyzeExample.beats[index].timestamp);
    }
    void Update()
    {
        rotation = Vector3.Lerp(new Vector3(0,0,0), new Vector3(0,0,-90), time);
        childObject.transform.parent.transform.localEulerAngles = rotation;
        time += Time.deltaTime * rotateSpeed; 
        if (time >= 1)
        {
            time = 0f;
            if (i >= analyzeExample.beats.Count) 
            {
                rotateSpeed = 0;
                Debug.Log(i);
                Debug.Log("END");
            }
            else 
            {
                rotateSpeed = GetRotateSpeed(i);
                i++;
                Debug.Log(i);
            }
            if (childObject.transform.parent == parentObject[0].transform)
            {
                SwapParent(childObject, parentObject[0], parentObject[1]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[1].transform)
            {
                SwapParent(childObject, parentObject[1], parentObject[2]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[2].transform)
            {
                SwapParent(childObject, parentObject[2], parentObject[3]);
                SetRotation(childObject);
            }
            else if (childObject.transform.parent == parentObject[3].transform)
            {
                SwapParent(childObject, parentObject[3], parentObject[0]);
                SetRotation(childObject);
            }
        }
    }
}
