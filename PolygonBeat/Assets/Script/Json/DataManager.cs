using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class DataManager : MonoBehaviour // 여긴 볼 거 없음
{
    public static DataManager singleTon;
    public WholeGameData wholeGameData;
    public CharacterData characterData;
    public MusicData musicData;
    public JsonManager testJson;
    public List<GameObject> gameObjects;
    // Start is called before the first frame update


    private void Awake()
    {
        testJson = new JsonManager();
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(gameObjects[0]);
        }
        else if (singleTon != this)
            Destroy(singleTon.gameObjects[0]);
        wholeGameData = testJson.LoadWholeGameData();
    }

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
}
