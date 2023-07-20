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
    [SerializeField] TMP_Text tmp_Text;
    [SerializeField] List<GameObject> parentObject;
    [SerializeField] GameObject childObject;
    [SerializeField] GameObject clearPanel;
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
    void SwapParent(GameObject preParentObject, GameObject nextParentObject) // 결론 부모를 바꿈
    {
        if(DataManager.singleTon.wholeGameData._currentSong == 0 || DataManager.singleTon.wholeGameData._currentSong == 1)
        {
            parentPosition.x += 1;
            nextParentObject.transform.SetParent(null); //다음에 부모가 될 오브젝트 종속성 없게 만듬
            nextParentObject.transform.localEulerAngles = Vector3.zero;//부모로 만들기 전에 rotation 초기화
            childObject.transform.SetParent(nextParentObject.transform); //위에서 종속성 없엔 오브젝트 부모로 만듬
            preParentObject.transform.SetParent(childObject.transform); //그 전에 부모 였던 오브젝트 자식으로 만듬
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //parent 오차 수정
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child 오차 수정
        }
        else if(DataManager.singleTon.wholeGameData._currentSong == 2)
        {
            parentPosition.x += 1;
            nextParentObject.transform.SetParent(null); //다음에 부모가 될 오브젝트 종속성 없게 만듬
            nextParentObject.transform.localEulerAngles = Vector3.zero;//부모로 만들기 전에 rotation 초기화
            childObject.transform.SetParent(nextParentObject.transform); //위에서 종속성 없엔 오브젝트 부모로 만듬
            preParentObject.transform.SetParent(childObject.transform); //그 전에 부모 였던 오브젝트 자식으로 만듬
            childObject.transform.parent.SetLocalPositionAndRotation(new Vector3(parentPosition.x, parentPosition.y, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //parent 오차 수정
            childObject.transform.SetLocalPositionAndRotation(new Vector3(-5, 4.5f, 0), Quaternion.Euler(new Vector3(0, 0, 0))); //child 오차 수정
        }
    }
    void SetRotation() //결론 오차 수정을 위한 작업
    {
        if (DataManager.singleTon.wholeGameData._currentSong == 0 || DataManager.singleTon.wholeGameData._currentSong == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; //90도 돌고 오차 수정을 위해 전부 rotation 초기화
            }
        }
        else if (DataManager.singleTon.wholeGameData._currentSong == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                childObject.transform.GetChild(i).localEulerAngles = Vector3.zero; //90도 돌고 오차 수정을 위해 전부 rotation 초기화
            }
        }
    }
    void setObject()
    {
 
        if (DataManager.singleTon.wholeGameData._currentSong == 0 || DataManager.singleTon.wholeGameData._currentSong == 1)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = DataManager.singleTon.saveData._squareSprite;
            parentObject[0].transform.SetParent(null);
            parentPosition = new Vector3(0.5f, 0.2f, 0);
            childObject.transform.SetParent(parentObject[0].transform);
            childObject.transform.parent.localEulerAngles = Vector3.zero;
            childObject.transform.localEulerAngles = Vector3.zero;
            childObject.transform.parent.localPosition = parentPosition;
            childObject.transform.localPosition = new Vector3(-5, 5, 0);
            rotateSpeed = (DataManager.singleTon.currentMusic.data[1].bpm / 60);
        }
        else if(DataManager.singleTon.wholeGameData._currentSong == 2)
        {
            childObject.GetComponent<SpriteRenderer>().sprite = DataManager.singleTon.saveData._triangleSprite;
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
        if (DataManager.singleTon.wholeGameData._currentSong == 0 || DataManager.singleTon.wholeGameData._currentSong == 1)
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
        else if (DataManager.singleTon.wholeGameData._currentSong == 2)
        {
            if (childObject.transform.parent == null)
            {
                setObject();
            }
            else
            {
                childObject.transform.SetParent(null);
                childObject.transform.position = new Vector3(0, 0.68f, 0);
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
    private float GetRotateSpeed(int index) // 로테이션 속도 계산
    {
        return ((DataManager.singleTon.currentMusic.data[index].bpm) / 60);
    }
    public void Init()
    {
        Setting();
        time = 0;
        beatIndex = 0;
    }
    void Start() // 처음 상태에 필요한 것들 초기화
    {
        if(DataManager.singleTon.wholeGameData._currentSong == 5 || DataManager.singleTon.wholeGameData._currentSong == 7)
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
        else if (DataManager.singleTon.wholeGameData._currentSong == 9)
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
        //musicPlayerManager = FindAnyObjectByType<MusicPlayerManager>();
    }
    void Update()
    {
        if(/*musicPlayerManager.GetBGMPlayer().time*/Managers.Sound._audioSources[(int)Define.Sound.BGM].time == 0)
        {
            return;
        }
        if (DataManager.singleTon.wholeGameData._currentSong == 0 || DataManager.singleTon.wholeGameData._currentSong == 1)
        {
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), time); //time이 0 ~ 1 갈 동안 로테이션도 (0,0,0)에서 (0,0,-90)으로 변함
        }  
        else if (DataManager.singleTon.wholeGameData._currentSong == 2)
        {
            rotation = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -120), time); //time이 0 ~ 1 갈 동안 로테이션도 (0,0,0)에서 (0,0,-120)으로 변함
        }
        childObject.transform.parent.transform.localEulerAngles = rotation; //부모 오브젝트 돌림
        time += Time.deltaTime * rotateSpeed; // 한 프레임당 얼만큼 돌릴 건지 결정
        if (time >= 1) //90도 돌고나면 부모를 바꿔서 다시 돌려야 제대로 돌아감
        {       
            time = 0f; //time을 0으로 초기화시켜야 Lerp가 작동함
            if(beatIndex >= DataManager.singleTon.currentMusic.data.Count -1)
            {
                rotateSpeed = 0;
                tmp_Text.text = "CLEAR";
                clearPanel.SetActive(true);
            }
            //else // 그 외에 로테이션 속도 계산
            {
                rotateSpeed = GetRotateSpeed(beatIndex);
                beatIndex++;
                if (rotateSpeed == 0) 
                {
                    tmp_Text.text = "CLEAR";
                    clearPanel.SetActive(true);
                }
            }
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
            else if (DataManager.singleTon.wholeGameData._currentSong == 9)
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
