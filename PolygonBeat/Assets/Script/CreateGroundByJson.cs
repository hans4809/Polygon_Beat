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
    public List<GameObject> ground;
    public GameObject coin;
    public GameObject savePoint;
    public int savePosition;
    public int[] coinIndex;
    private void InstantiateGround(int index, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
    {
        if (index >= DataManager.singleTon.currentMusic.data.Count)
        {
            return;
        }
        
        if (DataManager.singleTon.currentMusic.data[index].count != 1)
        {   
            Instantiate(ground[1], vector3, Quaternion.identity).name = "ground" + name;
        }
        else
        {
            Instantiate(ground[0], vector3, Quaternion.identity).name = "ground" + name;
        }
    }
    public void Start()
    {
        ground.Add(Resources.Load<GameObject>("UI/block1"));
        ground.Add(Resources.Load<GameObject>("UI/block2"));
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
            if (i == savePosition)
            {
                Instantiate(savePoint, new Vector3(i + 1, 0.8f, 0), Quaternion.identity);
            }
            if (coinNum >= DataManager.singleTon.currentMusic.data.Count / 10)
            {
                coinNum = DataManager.singleTon.currentMusic.data.Count / 10;
                continue;
            }
            else
            {
                if (i == coinIndex[coinNum])
                {
                    Instantiate(coin, new Vector3(i + 1, 0.7f, 0), Quaternion.identity);
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
