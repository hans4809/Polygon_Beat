using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using static Define;

public class CreateGroundByJson : MonoBehaviour
{
    public Transform transformParent;
    public SongManager songManager;
    public List<GameObject> ground;

    private void InstantiateGround(int index, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
    {
        if (index >= DataManager.singleTon.currentMusic.data.Count)
        {
            return;
        }
        if (DataManager.singleTon.currentMusic.data[index].count != 1)
        {   
            Instantiate(ground[1], vector3, Quaternion.identity, transformParent).name = "ground" + name;
        }
        else
        {
            Instantiate(ground[0], vector3, Quaternion.identity, transformParent).name = "ground" + name;
        }
    }
    public void Start()
    {
        for(int i = 0; i < DataManager.singleTon.currentMusic.data.Count; i++)
        {
            InstantiateGround(DataManager.singleTon.currentMusic.data[i].index, DataManager.singleTon.currentMusic.data[i].index.ToString(), new Vector3(DataManager.singleTon.currentMusic.data[i].index, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
