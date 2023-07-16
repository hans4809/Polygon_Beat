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
    public void StopBGM(string bgmName) 
    {
        bgmPlayer.Stop();
    }

    public AudioSource GetBGMPlayer()
    {
        return bgmPlayer;
    }
    public void PlaySFX(string sfxName) 
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            for (int j = 0; j < sfxPlayer.Length; j++)
            {
                if (!sfxPlayer[j].isPlaying)
                {
                    sfxPlayer[j].clip = sfx[i].audioClip;
                    sfxPlayer[j].Play();
                    return;
                }
            }
            Debug.Log("모든 오디오 플레이어가 재생중입니다.");
            return;
        }
        Debug.Log(sfxName + "해당 효과음이 없습니다.");
    }
    void Start()
    {
        Instance = this;
    }
    private void Awake()
    {
        PlayBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
    }
}
