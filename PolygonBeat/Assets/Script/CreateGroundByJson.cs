using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using static Define;

public class CreateGroundByJson : MonoBehaviour
{
    public Transform transformParent;
    public List<GameObject> groundList;
    public List<GameObject> ground;
    public GameObject coin;
    public GameObject savePoint;
    public int savePosition;
    public int[] coinIndex;
    private void InstantiateGround(int index, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
    {
        GameObject myGameObject;
        if (index >= DataManager.singleTon.currentMusic.data.Count)
        {
            return;
        }
        switch(DataManager.singleTon.currentMusic.data[index].count)
        {
            case 2:
                myGameObject = Instantiate(groundList[1], vector3, Quaternion.identity, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            case 3:
                myGameObject = Instantiate(groundList[2], vector3, Quaternion.identity, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            case 4:
                myGameObject = Instantiate(groundList[3], vector3, Quaternion.identity, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            default:
                myGameObject = Instantiate(groundList[0], vector3, Quaternion.identity, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
        }
    }
    public void Start()
    {
        if (DataManager.singleTon.wholeGameData._currentSong == 0)
        {
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg1_defualt01"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg1_defualt02"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg1_defualt03"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg1_defualt04"));
        }
        else 
        {
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg2_defualt01"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg2_defualt02"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg2_defualt03"));
            groundList.Add(Resources.Load<GameObject>("Prefebs/bg2_defualt04"));
        }

        coin = Resources.Load<GameObject>("UI/Icon/coin");
        savePoint = Resources.Load<GameObject>("UI/Icon/save_point");
        savePosition = DataManager.singleTon.currentMusic.data.Count / 50;
        CreateGround();
    }
    public void CreateGround()
    {
        coinIndex = new int[DataManager.singleTon.currentMusic.data.Count / 10];
        int coinNum = 0;
        for (int j = 0; j < DataManager.singleTon.currentMusic.data.Count / 10; j++)
        {
            coinIndex[j] = UnityEngine.Random.Range(j * 10, j * 10 + 10);
        }

        for (int i = -1; i < DataManager.singleTon.currentMusic.data.Count + 1; i++)
        {
            InstantiateGround(i + 1, (i + 1).ToString(), new Vector3(i + 1, 0, 0));
            if (coinNum >= DataManager.singleTon.currentMusic.data.Count / 10)
            {
                coinNum = DataManager.singleTon.currentMusic.data.Count / 10;
                continue;
            }
            else
            {
                if (i == coinIndex[coinNum])
                {
                    Instantiate(coin, new Vector3(i, 0.7f, 0), Quaternion.identity, ground[i].transform);
                    coinNum++;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
