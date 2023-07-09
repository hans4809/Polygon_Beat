using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Define;

public class DataManager : MonoBehaviour
{
    public static DataManager singleTon;
    public WholeGameData wholeGameData;
    public UserCharacterData userCharacterData;
    public IndividualCharacter individualCharacterData;
    public SaveData saveData;
    public MusicData musicData;
    public Music currentMusic;
    public JsonManager jsonManager;
    public List<GameObject> gameObjects;
    public Sprite defaultSprite;
    // Start is called before the first frame update


    public void Awake()
    {
        jsonManager = new JsonManager();
        saveData = new SaveData();
        saveData._sprite = defaultSprite;
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
        jsonManager.Save(userCharacterData);
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
            case (2):
                currentMusic = musicData.music[2];
                break;
        }
    }
}
