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
    [SerializeField] MusicPlayerManager musicPlayerManager;
    [SerializeField] LifeManager lifeManager;
    [SerializeField] Count count;
    [SerializeField] TouchCheckByJson touchCheckByJson;
    [SerializeField] GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        buttonList[0].onClick.AddListener(Replay);
        buttonList[1].onClick.AddListener(ChangetoSelectScene);
        buttonList[2].onClick.AddListener(Replay);
        pauseManager = FindAnyObjectByType<PauseManager>();
        createGroundByJson = FindAnyObjectByType<CreateGroundByJson>();
        playerRotate = FindAnyObjectByType<PlayerRotate>();
        musicPlayerManager = FindAnyObjectByType<MusicPlayerManager>();
        lifeManager = FindAnyObjectByType<LifeManager>();
        count = FindAnyObjectByType<Count>();
        touchCheckByJson = FindAnyObjectByType<TouchCheckByJson>();
    }

    void Replay()
    {
        gameOverPanel.SetActive(false);
        ResetAll();
        musicPlayerManager.StopBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        musicPlayerManager.PlayBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        Time.timeScale = 1f;
    }
    private void ResetAll()
    {
        pauseManager.Init();
        createGroundByJson.Init();
        playerRotate.Init();
        count.Setting();
        touchCheckByJson.Init();
        lifeManager.Init();
    }
    public void ChangetoSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
