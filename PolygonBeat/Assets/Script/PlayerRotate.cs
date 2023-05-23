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
    void SwapParent(GameObject preParentObject, GameObject nextParentObject) // ��� �θ� �ٲ�
    {
        parentPosition.x += 1;
        nextParentObject.transform.SetParent(null); // ������ �θ� �� ������Ʈ ���Ӽ� ���� ����
        nextParentObject.transform.localEulerAngles = Vector3.zero;// �θ�� ����� ���� rotation �ʱ�ȭ
        childObject.transform.SetParent(nextParentObject.transform); // ������ ���Ӽ� ���� ������Ʈ �θ�� ����
        preParentObject.transform.SetParent(childObject.transform); // �� ���� �θ� ���� ������Ʈ �ڽ����� ����
        childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, 0.11f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // parent ���� ����
        childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); // child ���� ����
    }
    void SetRotation() // ��� ���� ������ ���� �۾�
    {
        for (int i = 0; i < 3; i++)
        {
            childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; // 90�� ���� ���� ������ ���� ���� rotation �ʱ�ȭ
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

    void Start() // ó�� ���¿� �ʿ��� �͵� �ʱ�ȭ
    {
        Setting();
        initParentPostion = childObject.transform.parent.localPosition;
        //isRotate = true;
    }
    private float GetRotateSpeed(int index) // �����̼� �ӵ� ���
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
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), time); // time�� 0 ~ 1 �� ���� �����̼ǵ� (0,0,0)���� (0,0,-90)���� ����
            childObject.transform.parent.transform.localEulerAngles = rotation; // �θ� ������Ʈ ����
            time += Time.deltaTime * rotateSpeed; // �� �����Ӵ� ��ŭ ���� ���� ����
            if (time >= 1) //90�� ������ �θ� �ٲ㼭 �ٽ� ������ ����� ���ư�
            {
                //isRotate = false;
                time = 0f; // time�� 0���� �ʱ�ȭ���Ѿ� Lerp�� �۵���
                if (beatIndex >= analyzeExample.beats.Count) // �� ���� �������� �� ����
                {
                    rotateSpeed = 0;
                    return;
                }
                else // �� �ܿ� �����̼� �ӵ� ���
                {
                    rotateSpeed = GetRotateSpeed(beatIndex);
                    Debug.Log("�ε��� : " + beatIndex.ToString() + "�ӵ� : " + rotateSpeed.ToString());
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