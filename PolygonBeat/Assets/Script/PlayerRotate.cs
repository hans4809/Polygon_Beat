using RhythmTool;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.AnnotationUtility;
using UnityEngine.SceneManagement;
using static Define;
using UnityEngine.UI;
using TMPro;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] List<GameObject> parentObject;
    [SerializeField] GameObject childObject;
    [SerializeField] AudioSource _bgm;
    Vector3 initParentPostion;
    Vector3 parentPosition;
    Vector3 rotation;
    float rotateSpeed;
    float time;
    public int beatIndex = 0;

    public GameObject GetPlayer()
    {
        return childObject;
    }
    void SwapParent(GameObject preParentObject, GameObject nextParentObject) // ��� �θ� �ٲ�
    {
        if(DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            parentPosition.x += 1;
            nextParentObject.transform.SetParent(null); //������ �θ� �� ������Ʈ ���Ӽ� ���� ����
            nextParentObject.transform.localEulerAngles = Vector3.zero;//�θ�� ����� ���� rotation �ʱ�ȭ
            childObject.transform.SetParent(nextParentObject.transform); //������ ���Ӽ� ���� ������Ʈ �θ�� ����
            preParentObject.transform.SetParent(childObject.transform); //�� ���� �θ� ���� ������Ʈ �ڽ����� ����
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //parent ���� ����
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child ���� ����
        }
        else if(DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            parentPosition.x += 1;
            nextParentObject.transform.SetParent(null); //������ �θ� �� ������Ʈ ���Ӽ� ���� ����
            nextParentObject.transform.localEulerAngles = Vector3.zero;//�θ�� ����� ���� rotation �ʱ�ȭ
            childObject.transform.SetParent(nextParentObject.transform); //������ ���Ӽ� ���� ������Ʈ �θ�� ����
            preParentObject.transform.SetParent(childObject.transform); //�� ���� �θ� ���� ������Ʈ �ڽ����� ����
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //parent ���� ����
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child ���� ����
        }
    }
    void SetRotation() //��� ���� ������ ���� �۾�
    {
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            for (int i = 0; i < 3; i++)
            {
                childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; //90�� ���� ���� ������ ���� ���� rotation �ʱ�ȭ
            }
        }
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            for (int i = 0; i < 2; i++)
            {
                childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; //90�� ���� ���� ������ ���� ���� rotation �ʱ�ȭ
            }
        }
    }
    void setObject()
    {
 
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = Managers.Resource.Load<Sprite>($"Character/{DataManager.singleTon.saveData._rarity}/{DataManager.singleTon.saveData._currentCharacter}_square");
            parentObject[0].transform.SetParent(null);
            parentPosition = new Vector3(0.5f, 0.2f, 0);
            childObject.transform.SetParent(parentObject[0].transform);
            childObject.transform.parent.localEulerAngles = Vector3.zero;
            childObject.transform.localEulerAngles = Vector3.zero;
            childObject.transform.parent.localPosition = parentPosition;
            childObject.transform.localPosition = new Vector3(-5, 5, 0);
            rotateSpeed = (DataManager.singleTon.currentMusic.data[1].bpm / 60);
        }
        else if(DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = Managers.Resource.Load<Sprite>($"Character/{DataManager.singleTon.saveData._rarity}/{DataManager.singleTon.saveData._currentCharacter}_triangle");
            parentObject[0].transform.SetParent(null);
            parentPosition = new Vector3(0.5f, 0.23f, 0);
            childObject.transform.SetParent(parentObject[0].transform);
            childObject.transform.parent.localEulerAngles = Vector3.zero;
            childObject.transform.localEulerAngles = Vector3.zero;
            childObject.transform.parent.localPosition = parentPosition;
            childObject.transform.localPosition = new Vector3(-5, 4.5f, 0);
            rotateSpeed = (DataManager.singleTon.currentMusic.data[1].bpm / 60);
        }
    }

    public void Setting()
    {
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            if (childObject.transform.parent == null)
            {
                setObject();
            }
            else
            { 
                childObject.transform.SetParent(null);
                childObject.transform.position = new Vector3(0, 0.7f, 0);
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
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            if (childObject.transform.parent == null)
            {
                setObject();
            }
            else
            {
                childObject.transform.SetParent(null);
                childObject.transform.position = new Vector3(0, 0.68f, 0);
                for (int j = 0; j < 3; j++)
                {
                    parentObject[j].transform.localEulerAngles = Vector3.zero;
                }
                for (int i = 0; i < 3; i++)
                {
                    parentObject[i].transform.SetParent(childObject.transform);
                    switch (i)
                    {
                        case 0:
                            childObject.transform.GetChild(0).localPosition = new Vector3(0.5f, -0.45f, 0);
                            break;
                        case 1:
                            childObject.transform.GetChild(1).localPosition = new Vector3(0, 0.45f, 0);
                            break;
                        case 2:
                            childObject.transform.GetChild(2).localPosition = new Vector3(-0.5f, -0.45f, 0);
                            break;
                    }
                }
                setObject();
                parentPosition = initParentPostion;
                childObject.transform.parent.localPosition = parentPosition;
            }
        }
    }
    private float GetRotateSpeed(int index) // �����̼� �ӵ� ���
    {
        return ((DataManager.singleTon.currentMusic.data[index].bpm) / 60);
    }
    public void Init()
    {
        Setting();
        time = 0;
        beatIndex = 0;
    }
    void Start() // ó�� ���¿� �ʿ��� �͵� �ʱ�ȭ
    {
        _bgm = Managers.Sound._audioSources[(int)Define.Sound.BGM];
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            GameObject.Find("PlayerTriangle").SetActive(false);
            childObject = GameObject.Find("PlayerSquare");
            parentObject.Add(GameObject.Find("Parent0"));
            parentObject.Add(GameObject.Find("Parent1"));
            parentObject.Add(GameObject.Find("Parent2"));
            parentObject.Add(GameObject.Find("Parent3"));
            for(int i = 0; i < 4; i++)
            {
                parentObject[i].transform.SetParent(childObject.transform);
            }
        }
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            GameObject.Find("PlayerSquare").SetActive(false);
            childObject = GameObject.Find("PlayerTriangle");
            parentObject.Add(GameObject.Find("Parent0"));
            parentObject.Add(GameObject.Find("Parent1"));
            parentObject.Add(GameObject.Find("Parent2"));
            for (int i = 0; i < 3; i++)
            {
                parentObject[i].transform.SetParent(childObject.transform);
            }
        }
        Setting();
        initParentPostion = childObject.transform.parent.localPosition;
        Time.timeScale = 1.0f;
        time = 0f;
    }
    void Update()
    {
        if(/*musicPlayerManager.GetBGMPlayer().time*/_bgm.time == 0)
        {
            Debug.Log(_bgm.time);
            return;
        }
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), time); //time�� 0 ~ 1 �� ���� �����̼ǵ� (0,0,0)���� (0,0,-90)���� ����
        }  
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -120), time); //time�� 0 ~ 1 �� ���� �����̼ǵ� (0,0,0)���� (0,0,-120)���� ����
        }
        childObject.transform.parent.transform.localEulerAngles = rotation; //�θ� ������Ʈ ����
        time += Time.deltaTime * rotateSpeed; // �� �����Ӵ� ��ŭ ���� ���� ����
        if (time >= 1) //90�� ������� �θ� �ٲ㼭 �ٽ� ������ ����� ���ư�
        {       
            time = 0f; //time�� 0���� �ʱ�ȭ���Ѿ� Lerp�� �۵���
            if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
            {
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
            else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
            {
                if (childObject.transform.parent == parentObject[0].transform)
                {
                    SwapParent(parentObject[0], parentObject[0]);
                    SetRotation();
                }
                else if (childObject.transform.parent == parentObject[1].transform)
                {
                    SwapParent(parentObject[1], parentObject[1]);
                    SetRotation();
                }
                else if (childObject.transform.parent == parentObject[2].transform)
                {
                    SwapParent(parentObject[2], parentObject[2]);
                    SetRotation();
                }
            }
        }    
    }
}
