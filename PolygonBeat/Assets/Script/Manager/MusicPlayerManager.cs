using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;
}
public class MusicPlayerManager : MonoBehaviour
{
    public static MusicPlayerManager Instance;
    public RhythmPlayer rhythmPlayer;
    public WholeGameData wholeGameData;
    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;
    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;
    // Start is called before the first frame update
    public void PlayBGM(string bgmName)
    {
        for(int i=0; i < bgm.Length; i++)
        {
            if(bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].audioClip;
                bgmPlayer.PlayDelayed(3.0f);
            }
        }
    }
    void Start()
    {
        Instance = this;
    }
    private void Awake()
    {
        //dataManager = GameObject.Find("DataManger").AddComponent<DataManager>() as DataManager;
        //testJson = new JsonManager();
        PlayBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Debug.Log(bgmPlayer.time);
    }
}
