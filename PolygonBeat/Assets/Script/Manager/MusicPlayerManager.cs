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
    public JsonManager testJson;
    //public AudioClip audioClip;
    //public AudioSource audioSource;
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
                bgmPlayer.Play();
            }
        }
    }
    void Start()
    {
        Instance = this;
        
    }
    private void Awake()
    {
        testJson = new JsonManager();
        rhythmPlayer = new RhythmPlayer();
        wholeGameData = testJson.LoadWholeGameData();
        PlayBGM(wholeGameData._currentSong.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
