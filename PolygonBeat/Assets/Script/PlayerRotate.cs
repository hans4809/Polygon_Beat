using RhythmTool;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static Define;
using UnityEngine.UI;
using TMPro;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] GameObject childObject;
    [SerializeField] AudioSource _bgm; 
    [SerializeField] UI_Clear clear;
    Vector3 initParentPostion;
    Vector3 parentPosition;
    Vector3 rotation;
    public float rotateSpeed;
    float time;
    public int beatIndex = 0;

    public GameObject GetPlayer()
    {
        return childObject;
    }
    void ParentSet()
    {
        beatIndex++;
        parentPosition.x += 1;
        childObject.transform.SetParent(null);
        parentObject.transform.SetPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        childObject.transform.SetParent(parentObject.transform);
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            if (beatIndex % 4 == 1)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, -90))); //child ���� ����
            }
            if (beatIndex % 4 == 2)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, -180))); //child ���� ����
            }
            if (beatIndex % 4 == 3)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, -270))); //child ���� ����
            }
            if (beatIndex % 4 == 0)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child ���� ����
            }
        }
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            if (beatIndex % 3 == 1)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-3.7f, 2.3f, 0), Quaternion.Euler(new Vector3(0, 0, -120))); //child ���� ����
            }
            if (beatIndex % 3 == 2)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-6.2f, 2.4f, 0), Quaternion.Euler(new Vector3(0, 0, -240))); //child ���� ����
            }
            if (beatIndex % 3 == 0)
            {
                childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child ���� ����
            }
        }
        rotateSpeed = GetRotateSpeed(beatIndex);
    }
    void setObject()
    {
 
        if (DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = Managers.Resource.Load<Sprite>($"Character/{DataManager.singleTon.saveData._rarity}/{DataManager.singleTon.saveData._currentCharacter}_square");
            parentObject.transform.SetParent(null);
            parentPosition = new Vector3(0.5f, 0.2f, 0);
            childObject.transform.SetParent(parentObject.transform);
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            rotateSpeed = (DataManager.singleTon.currentMusic.data[0].bpm / 60);
        }
        else if(DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = Managers.Resource.Load<Sprite>($"Character/{DataManager.singleTon.saveData._rarity}/{DataManager.singleTon.saveData._currentCharacter}_triangle");
            parentObject.transform.SetParent(null);
            parentPosition = new Vector3(0.5f, 0.23f, 0);
            childObject.transform.SetParent(parentObject.transform);
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            rotateSpeed = (DataManager.singleTon.currentMusic.data[0].bpm / 60);
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
                parentObject.transform.SetParent(childObject.transform);
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
                parentObject.transform.SetParent(childObject.transform);
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
            parentObject = GameObject.Find("Parent");

        }
        else if (DataManager.singleTon.wholeGameData._currentSong == 9 || DataManager.singleTon.wholeGameData._currentSong == 10)
        {
            GameObject.Find("PlayerSquare").SetActive(false);
            childObject = GameObject.Find("PlayerTriangle");
            parentObject = GameObject.Find("Parent");

        }
        Setting();
        initParentPostion = childObject.transform.parent.localPosition;
        Time.timeScale = 1.0f;
        time = 0f;
    }
    void Update()
    {
        if (rotateSpeed == 0)
        {
            if (clear == null)
            {
                clear = Managers.UI.ShowPopUpUI<UI_Clear>();
            }
        }
        if (_bgm.time == 0)
        {
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
            ParentSet();
        }    
    }
}
