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
    public List<Onset> onsets;
    public List<Chroma> chromas;
    private float endTime;
    void Start()
    {
        rhythmData = analyzer.Analyze(audioClip); //�����Ŭ���� �ִ� �뷡�� �м��ؼ� ���뵥���ͷ� ��ȯ
    }
    void Awake()
    {
        endTime = audioClip.length;
        Track<Beat> track = rhythmData.GetTrack<Beat>(); // ���� �����Ϳ� ��Ʈ Ʈ�� ����?
        beats = new List<Beat>(); // ��Ʈ ����Ʈ ����
        rhythmData.GetFeatures<Beat>(beats, startTime, endTime);// ��Ʈ ����Ʈ�� ��Ʈ�� Ư¡ ����
        Track<Onset> track1 = rhythmData.GetTrack<Onset>();
        onsets = new List<Onset>();
        rhythmData.GetFeatures<Onset>(onsets, startTime, endTime);
        Track<Chroma> track2 = rhythmData.GetTrack<Chroma>();
        chromas = new List<Chroma>();
        rhythmData.GetFeatures<Chroma>(chromas, startTime, endTime);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
