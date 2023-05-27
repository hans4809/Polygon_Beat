using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using static Define;

public class CreateGroundByJson : MonoBehaviour
{
    public JsonManager testJson;
    public Transform transformParent;
    public Music currentMusic;
    public MusicData musicData;
    public WholeGameData wholeGameData;
    public SongManager songManager;
    public DataManager dataManager;
    public List<GameObject> ground;

    private void InstantiateGround(int index, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
    {
        if (index >= currentMusic.data.Count)
        {
            return;
        }
        if (currentMusic.data[index].count != 1)
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
        for(int i = 0; i < currentMusic.data.Count; i++)
        {
            InstantiateGround(currentMusic.data[i].index, currentMusic.data[i].index.ToString(), new Vector3(currentMusic.data[i].index, 0, 0));
        }
    }
    private void Awake()
    {
        testJson = new JsonManager();
        musicData = testJson.LoadMusicData();
        wholeGameData = testJson.LoadWholeGameData();
        switch(wholeGameData._currentSong)
        {
            case (0):
                currentMusic = musicData.music[0];
                break;
            case (1):
                currentMusic = musicData.music[1];
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
