using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using static Define;

public class CreateGroundByJson : MonoBehaviour
{
    public JsonManager testJson;
    public Transform transformParent;
    public Music currentMusic;
    public MusicData musicData;
    //public List<Music> music;
    //public List<Data> currentMusicData;
    public List<GameObject> ground;
    public int currentMusicIndex;
    private void CreateObject(int index, string name, Vector3 vector3) // 게임오브젝트 복제하는 함수
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
    void Start()
    {
        for(int i = 0; i < currentMusic.data.Count; i++)
        {
            Debug.Log(currentMusic.data.Count);
            CreateObject(currentMusic.data[i].index, currentMusic.data[i].index.ToString(), new Vector3(currentMusic.data[i].index, 0, 0));
        }
    }
    private void Awake()
    {
        testJson = new JsonManager();
        musicData = testJson.LoadMusicData();
        currentMusic = musicData.music[0];       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
