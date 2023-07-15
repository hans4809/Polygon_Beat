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
    public List<string> blockResourceString;
    public string coinResourceString;
    public GameObject coin;
    public GameObject savePoint;
    public int savePosition;
    public int[] coinIndex;
    private void InstantiateGround(int index, Vector3 position) // 게임오브젝트 복제하는 함수
    {
        GameObject myGameObject;
        if (index >= DataManager.singleTon.currentMusic.data.Count)
        {
            return;
        }
        switch(DataManager.singleTon.currentMusic.data[index].count)
        {
            case 2:
                myGameObject = Managers.Resource.Instantiate(blockResourceString[1], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            case 3:
                myGameObject = Managers.Resource.Instantiate(blockResourceString[2], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            case 4:
                myGameObject = Managers.Resource.Instantiate(blockResourceString[3], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
            default:
                myGameObject = Managers.Resource.Instantiate(blockResourceString[0], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                ground.Add(myGameObject);
                break;
        }
    }
    public void Start()
    {
        if (DataManager.singleTon.wholeGameData._currentSong == 0)
        {
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg1_defualt01"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg1_defualt02"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg1_defualt03"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg1_defualt04"));
            blockResourceString.Add("Block/bg1_defualt01");
            blockResourceString.Add("Block/bg1_defualt02");
            blockResourceString.Add("Block/bg1_defualt03");
            blockResourceString.Add("Block/bg1_defualt04");
        }
        else 
        {
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg2_defualt01"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg2_defualt02"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg2_defualt03"));
            groundList.Add(Managers.Resource.Load<GameObject>("Block/bg2_defualt04"));
            blockResourceString.Add("Block/bg2_defualt01");
            blockResourceString.Add("Block/bg2_defualt01");
            blockResourceString.Add("Block/bg2_defualt01");
            blockResourceString.Add("Block/bg2_defualt01");
        }
        coin = Managers.Resource.Load<GameObject>("Icon/coin");
        coinResourceString = "Icon/coin";
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
            InstantiateGround(i + 1, new Vector3(i + 1, 0, 0));
            if (coinNum >= DataManager.singleTon.currentMusic.data.Count / 10)
            {
                coinNum = DataManager.singleTon.currentMusic.data.Count / 10;
                continue;
            }
            else
            {
                if (i == coinIndex[coinNum])
                {
                    Managers.Resource.Instantiate(coinResourceString, new Vector3(i, 0.7f, 0), ground[i].transform);
                    coinNum++;
                } 
            }
        }
    }
}
