using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayManager : MonoBehaviour
{   
    public PauseManager pauseManager;
    //public GroundCreater groundCreater;
    public GameOverManager gameOverManager;
    public CreateGroundByJson createGroundByJson;
    public PlayerRotate playerRotate;
    public Button replayButton;
    public AudioSource audioSource;
    public List<Vector3> gameObjectInitPosition;

    // Start is called before the first frame update
    void Awake()
    {
        replayButton.onClick.AddListener(Replay);
    }

    void Replay()
    {
        audioSource.Stop();
        audioSource.Play();
        ResetAll();
        Time.timeScale = 1f;
    }
    private void ResetAll()
    {
        pauseManager.Start();
        createGroundByJson.Start();
        gameOverManager.Start();
        playerRotate.Setting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
