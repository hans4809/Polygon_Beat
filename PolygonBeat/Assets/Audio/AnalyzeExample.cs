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

    private float prevTime;
    private List<Beat> beats;
    void Start()
    {
        //Start analyzing a song.
        rhythmData = analyzer.Analyze(audioClip);

        //Find a track with Beats.
        Track<Beat> track = rhythmData.GetTrack<Beat>();
    }
    void Awake()
    {
        beats = new List<Beat>();
    }
    // Update is called once per frame
    void Update()
    {
        //Get the current playback time of the AudioSource.
        float time = audioSource.time;

        //Clear the list.
        beats.Clear();

        //Find all beats for the part of the song that is currently playing.
        rhythmData.GetFeatures<Beat>(beats, prevTime, time);

        //Do something with the Beats here.
        foreach (Beat beat in beats)
        {
            Debug.Log("A beat occurred at " + beat.timestamp);
        }

        //Keep track of the previous playback time of the AudioSource.
        prevTime = time;
    }
}
