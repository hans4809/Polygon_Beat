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
    public Music currentMusic;
    public JsonManager jsonManager;
    public List<GameObject> gameObjects;
    // Start is called before the first frame update


    public void Awake()
    {
        jsonManager = new JsonManager();
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(gameObjects[0]);
        }
        else if (singleTon != this)
            Destroy(singleTon.gameObjects[0]);
        wholeGameData = jsonManager.LoadWholeGameData();
        musicData = jsonManager.LoadMusicData();
        switch (wholeGameData._currentSong)
        {
            case (0):
                currentMusic = musicData.music[0];
                break;
            case (1):
                currentMusic = musicData.music[1];
                break;
        }
    }

    private void Start()
    {
        jsonManager.Save(wholeGameData);
    }
    // Update is called once per frame
    void Update()
    {
        switch (wholeGameData._currentSong)
        {
            case (0):
                currentMusic = musicData.music[0];
                break;
            case (1):
                currentMusic = musicData.music[1];
                break;
        }
    }
}
