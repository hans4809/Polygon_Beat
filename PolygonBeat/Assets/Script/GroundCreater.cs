using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCreater : MonoBehaviour
{
    public AnalyzeExample analyzeExample;
    public List<GameObject> myGameObject;
    public Transform transformParent;
    public int slowIndex = 15;
    public int fastIndex = 15 + 6;
    public int[] coinIndex;
    // Start is called before the first frame update
    private void CreateObject(GameObject gameObject, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
    {
        GameObject obj = Instantiate(gameObject, vector3, Quaternion.identity, transformParent);
        obj.name = name;
    }

    public void Start()
    {
        coinIndex = new int[analyzeExample.beats.Count / 10];
        int coinNum = 0;
        for(int j = 0; j < analyzeExample.beats.Count / 10; j++)
        {
            coinIndex[j] = UnityEngine.Random.Range(j * 10, j * 10 + 10);
        }
        for (int i = 0; i <= analyzeExample.beats.Count + (fastIndex - slowIndex); i++)
        {
            if (i == slowIndex)
            {
                CreateObject(myGameObject[2], "slow", new Vector3(i, 0.6f, 0));//느려지는 거 생성
            }
            else if (i == fastIndex)
            {
                CreateObject(myGameObject[3], "fast", new Vector3(i, 0.6f, 0));//빨라지는 거 생성
            }
            else
            {
                if (coinNum >= analyzeExample.beats.Count / 10)
                {
                    coinNum = analyzeExample.beats.Count / 10;
                    continue;
                }
                else
                {
                    if (i == coinIndex[coinNum])
                    {
                        CreateObject(myGameObject[4], "coin", new Vector3(i, 0.6f, 0));
                        coinNum++;
                    }
                }
                //CreateObject(myGameObject[1], "flag", new Vector3((int)analyzeExample.beats.Count / 2, 0.6f, 0)); // 세이브포인트?
            }
            CreateObject(myGameObject[0], i.ToString(), new Vector3(i, 0, 0)); //비트 갯수만큼 바닥만듬 
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
