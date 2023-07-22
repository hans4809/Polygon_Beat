using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataDefine;

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
    public GameObject _gameObject;
    // Start is called before the first frame update


    public void Awake()
    {
        jsonManager = new JsonManager();
        saveData = new SaveData();
        saveData._squareSprite = Resources.Load<Sprite>("Character/default/default01_square");
        saveData._triangleSprite = Resources.Load<Sprite>("Character/default/default01_triangle");
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(_gameObject);
        }
        else if (singleTon != this)
            Destroy(singleTon._gameObject);
        //wholeGameData = jsonManager.LoadWholeGameData();
        wholeGameData = jsonManager.Load<WholeGameData>();
        //musicData = jsonManager.LoadMusicData();
        musicData = jsonManager.Load<MusicData>();
        switch (wholeGameData._currentSong)
        {
            case 5:
                currentMusic = musicData.music[0];
                break;
            case 7:
                currentMusic = musicData.music[1];
                break;
            case 9:
                currentMusic = musicData.music[2];
                break;
        }
    }

    private void Start()
    {
        //jsonManager.Save(wholeGameData);
        jsonManager.Save<WholeGameData>(wholeGameData);
        //jsonManager.Save(userCharacterData);
        jsonManager.Save<UserCharacterData>(userCharacterData);
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
