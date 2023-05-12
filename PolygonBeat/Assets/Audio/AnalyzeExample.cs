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
        rhythmData = analyzer.Analyze(audioClip); //�����Ŭ���� �ִ� �뷡�� �м��ؼ� ���뵥���ͷ� ��ȯ
    }
    void Awake()
    {
        endTime = audioClip.length;
        Track<Beat> track = rhythmData.GetTrack<Beat>(); // ���� �����Ϳ� ��Ʈ Ʈ�� ����?
        beats = new List<Beat>(); // ��Ʈ ����Ʈ ����
        rhythmData.GetFeatures<Beat>(beats, startTime, endTime); // ��Ʈ ����Ʈ�� ��Ʈ�� Ư¡ ����
    }
    // Update is called once per frame
    void Update()
    {
    }
}
