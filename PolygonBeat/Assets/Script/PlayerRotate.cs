using RhythmTool;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.AnnotationUtility;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField][Range(0.01f, 10f)] float delayTime = 0.1f;
    [SerializeField] AnalyzeExample analyzeExample;
    [SerializeField] RhythmPlayer rhythmPlayer;
    [SerializeField] GroundCreater groundCreater;
    [SerializeField] List<GameObject> parentObject;
    [SerializeField] GameObject childObject;
    Vector3 initParentPostion;
    Vector3 parentPosition;
    Vector3 rotation;
    bool isRotate;
    float rotateSpeed;
    float time = 0f;
    int beatIndex = 0;
    /*IEnumerator RotateDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isRotate = true;
    }*/
    void SwapParent(GameObject preParentObject, GameObject nextParentObject) // 결론 부모를 바꿈
    {
        parentPosition.x += 1;
        nextParentObject.transform.SetParent(null); // 다음에 부모가 될 오브젝트 종속성 없게 만듬
        nextParentObject.transform.localEulerAngles = Vector3.zero;// 부모로 만들기 전에 rotation 초기화
        childObject.transform.SetParent(nextParentObject.transform); // 위에서 종속성 없엔 오브젝트 부모로 만듬
        preParentObject.transform.SetParent(childObject.transform); // 그 전에 부모 였던 오브젝트 자식으로 만듬
        childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, 0.11f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // parent 오차 수정
        childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // child 오차 수정
    }
    void SetRotation() // 결론 오차 수정을 위한 작업
    {
        for (int i = 0; i < 3; i++)
        {
            childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; // 90도 돌고 오차 수정을 위해 전부 rotation 초기화
        }
    }
    void setObject()
    {
        parentObject[0].transform.SetParent(null);
        parentPosition = parentObject[0].transform.localPosition;
        childObject.transform.SetParent(parentObject[0].transform);
        childObject.transform.parent.localEulerAngles = Vector3.zero;
        childObject.transform.localEulerAngles = Vector3.zero;
        childObject.transform.parent.localPosition = parentPosition;
        childObject.transform.localPosition = new Vector3(-5, 5, 0);
        rotateSpeed = 1 / analyzeExample.beats[0].timestamp;
    }

    public void Setting()
    {
        if (childObject.transform.parent == null)
        {
           setObject();
        }
        else
        {
           childObject.transform.SetParent(null);
           childObject.transform.position = new Vector3(0,0.6f,0);
           for (int j = 0; j < 4; j++)
           {
               parentObject[j].transform.localEulerAngles = Vector3.zero;
           }
            for (int i = 0; i < 4; i++)
           {
                parentObject[i].transform.SetParent(childObject.transform);
                switch (i)
                {
                    case 0:
                        childObject.transform.GetChild(0).localPosition = new Vector3(0.5f, -0.5f, 0);
                        break;
                    case 1:
                        childObject.transform.GetChild(1).localPosition = new Vector3(0.5f, 0.5f, 0);
                        break;
                    case 2:
                        childObject.transform.GetChild(2).localPosition = new Vector3(-0.5f, 0.5f, 0);
                        break;
                    case 3:
                        childObject.transform.GetChild(3).localPosition = new Vector3(-0.5f, -0.5f, 0);
                        break;
                }
            }
            setObject();
            parentPosition = initParentPostion;
            childObject.transform.parent.localPosition = parentPosition;
        }
    }

    void Start() // 처음 상태에 필요한 것들 초기화
    {
        Setting();
        initParentPostion = childObject.transform.parent.localPosition;
        //isRotate = true;
    }
    private float GetRotateSpeed(int index) // 로테이션 속도 계산
    {
        /*if(groundCreater.slowIndex <= index + 1  && index + 1 < groundCreater.fastIndex)
        {
            return (1 / (analyzeExample.beats[index + 1].timestamp - analyzeExample.beats[index].timestamp))/2;
        }*/
        return (1 / (analyzeExample.beats[index+1].timestamp - (analyzeExample.beats[index].timestamp /*- delayTime*/)));
    }
    void Update()
    {
        //if (isRotate) 
        {
            /*if (rhythmPlayer.time <= analyzeExample.beats[0].timestamp)
            {
                return;
            }*/
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), time); // time이 0 ~ 1 갈 동안 로테이션도 (0,0,0)에서 (0,0,-90)으로 변함
            childObject.transform.parent.transform.localEulerAngles = rotation; // 부모 오브젝트 돌림
            time += Time.deltaTime * rotateSpeed; // 한 프레임당 얼만큼 돌릴 건지 결정
            if (time >= 1) //90도 돌고나면 부모를 바꿔서 다시 돌려야 제대로 돌아감
            {
                //isRotate = false;
                time = 0f; // time을 0으로 초기화시켜야 Lerp가 작동함
                if (beatIndex >= analyzeExample.beats.Count) // 맵 끝에 도달했을 때 멈춤
                {
                    rotateSpeed = 0;
                    return;
                }
                else // 그 외에 로테이션 속도 계산
                {
                    rotateSpeed = GetRotateSpeed(beatIndex);
                    Debug.Log("인덱스 : " + beatIndex.ToString() + "속도 : " + rotateSpeed.ToString());
                    beatIndex++;
                }
                if (childObject.transform.parent == parentObject[0].transform)
                {
                    SwapParent(parentObject[0], parentObject[1]);
                    SetRotation();
                    //StartCoroutine(RotateDelay());
                }
                else if (childObject.transform.parent == parentObject[1].transform)
                {
                    SwapParent(parentObject[1], parentObject[2]);
                    SetRotation();
                    //StartCoroutine(RotateDelay());
                }
                else if (childObject.transform.parent == parentObject[2].transform)
                {
                    SwapParent(parentObject[2], parentObject[3]);
                    SetRotation();
                    //StartCoroutine(RotateDelay());
                }
                else if (childObject.transform.parent == parentObject[3].transform)
                {
                    SwapParent(parentObject[3], parentObject[0]);
                    SetRotation();
                    //StartCoroutine(RotateDelay());
                }
            }
        }
    }
}