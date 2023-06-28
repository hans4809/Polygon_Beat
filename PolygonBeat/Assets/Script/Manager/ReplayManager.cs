using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{   
    [SerializeField] PauseManager pauseManager;
    [SerializeField] CreateGroundByJson createGroundByJson;
    [SerializeField] PlayerRotate playerRotate;
    [SerializeField] public Button replayButton;
    //public AudioSource audioSource;
    [SerializeField] MusicPlayerManager musicPlayerManager;
    [SerializeField] LifeManager lifeManager;
    [SerializeField] Count count;
    [SerializeField] TouchCheckByJson touchCheckByJson;
    
    // Start is called before the first frame update
    void Awake()
    {
        replayButton.onClick.AddListener(Replay);
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
        ResetAll();
        musicPlayerManager.StopBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        musicPlayerManager.PlayBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
        Time.timeScale = 1f;
    }
    private void ResetAll()
    {
        pauseManager.Init();
        createGroundByJson.CreateGround();
        playerRotate.Init();
        count.Setting();
        touchCheckByJson.Init();
        lifeManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
