using RhythmTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProviderExample : MonoBehaviour
{
    public RhythmEventProvider eventProvider;
    // Start is called before the first frame update
    void Start()
    {
        eventProvider.Register<Beat>(OnBeat);
    }
    private void OnBeat(Beat beat)
    {
        //Do something when a Beat occurs.
        Debug.Log("A beat occurred at " + beat.timestamp);
    }
    void OnDestroy()
    {
        eventProvider.Unregister<Beat>(OnBeat);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
