using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{   
    [SerializeField] PauseManager pauseManager;
    [SerializeField] CreateGroundByJson createGroundByJson;
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField] List<Button> buttonList;
    //[SerializeField] MusicPlayerManager musicPlayerManager;
    [SerializeField] Count count;
    [SerializeField] TouchCheckByJson touchCheckByJson;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] UI_GameScene ui_GameScene;
    
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void Replay()
    {
        ResetAll();
        //musicPlayerManager.StopBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        //musicPlayerManager.PlayBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        Managers.Sound.Stop(Managers.Sound._audioSources[(int)Define.Sound.BGM]);
        Managers.Sound.Play(DataManager.singleTon.wholeGameData._currentSong.ToString());
        Time.timeScale = 1f;
    }
    private void ResetAll()
    {
        pauseManager.Init();
        createGroundByJson.Init();
        playerRotate.Init();
        count.Setting();
        touchCheckByJson.Init();
        ui_GameScene.Init();
    }
}
