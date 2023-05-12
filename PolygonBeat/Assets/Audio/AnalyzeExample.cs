using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzeExample : MonoBehaviour
{
    // Start is called before the first frame update
    public RhythmAnalyzer analyzer;

    public AudioClip audioClip;

    public RhythmData rhythmData;

    public AudioSource audioSource;

    private float startTime = 0;
    public List<Beat> beats;
    private float endTime;
    void Start()
    {
        rhythmData = analyzer.Analyze(audioClip); //오디오클립에 있는 노래를 분석해서 리듬데이터로 반환
    }
    void Awake()
    {
        endTime = audioClip.length;
        Track<Beat> track = rhythmData.GetTrack<Beat>(); // 리듬 데이터에 비트 트랙 구현?
        beats = new List<Beat>(); // 비트 리스트 만듬
        rhythmData.GetFeatures<Beat>(beats, startTime, endTime); // 비트 리스트에 비트의 특징 저장
    }
    // Update is called once per frame
    void Update()
    {
    }
}
