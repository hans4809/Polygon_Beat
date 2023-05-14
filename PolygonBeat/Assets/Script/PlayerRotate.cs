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
            childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; // 90�� ���� ���� ������ ���� ���� rotation �ʱ�ȭ
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
        rotateSpeed = analyzeExample.beats[0].bpm;
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
           childObject.transform.localPosition = new Vector3(0,0.6f,0);
           for(int i = 0; i < 4; i++)
           {
                parentObject[i].transform.SetParent(childObject.transform);
                childObject.transform.GetChild(i).localEulerAngles = Vector3.zero;
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
        }
    }

    void Start() // ó�� ���¿� �ʿ��� �͵� �ʱ�ȭ
    {
         Setting();
    }
    private float GetRotateSpeed(int index) // �����̼� �ӵ� ���
    {
        return 1 / (analyzeExample.beats[index + 1].timestamp - analyzeExample.beats[index].timestamp);
    }
    void Update()
    {
        rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), time); // time�� 0 ~ 1 �� ���� �����̼ǵ� (0,0,0)���� (0,0,-90)���� ����
        childObject.transform.parent.transform.localEulerAngles = rotation; // �θ� ������Ʈ ����
        time += Time.deltaTime * rotateSpeed; // �� �����Ӵ� ��ŭ ���� ���� ����
        if (time >= 1) //90�� ������ �θ� �ٲ㼭 �ٽ� ������ ����� ���ư�
        {
            time = 0f; // time�� 0���� �ʱ�ȭ���Ѿ� Lerp�� �۵���
            if (i >= analyzeExample.beats.Count) // �� ���� �������� �� ����
            {
                rotateSpeed = 0;
            }
            else // �� �ܿ� �����̼� �ӵ� ���
            {
               rotateSpeed = GetRotateSpeed(i);
               i++;
            }
            if (childObject.transform.parent == parentObject[0].transform)
            {
            SwapParent(parentObject[0], parentObject[1]);
            SetRotation();
            }
            else if (childObject.transform.parent == parentObject[1].transform)
            {
            SwapParent(parentObject[1], parentObject[2]);
            SetRotation();
            }
            else if (childObject.transform.parent == parentObject[2].transform)
            {
            SwapParent(parentObject[2], parentObject[3]);
            SetRotation();
            }
            else if (childObject.transform.parent == parentObject[3].transform)
            {
            SwapParent(parentObject[3], parentObject[0]);
            SetRotation();
            }
        }

    }
}