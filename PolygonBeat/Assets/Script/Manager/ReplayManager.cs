using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{   
    public PauseManager pauseManager;
    public CreateGroundByJson createGroundByJson;
    public PlayerRotate playerRotate;
    public Button replayButton;
    //public AudioSource audioSource;
    public MusicPlayerManager musicPlayerManager;
    public LifeManager lifeManager;
    public Count count;
    
    // Start is called before the first frame update
    void Awake()
    {
        replayButton.onClick.AddListener(Replay);
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
        pauseManager.Start();
        createGroundByJson.Start();
        playerRotate.Setting();
        lifeManager.Start();
        count.Setting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
