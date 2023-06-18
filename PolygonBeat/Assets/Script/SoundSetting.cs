using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundSetting : MonoBehaviour
{
    public AudioMixer mixer;

    [Range(-80, 0)]
    public float master = 0;

    [Range(-80, 0)]
    public float bgm = 0;

    [Range(-80, 0)]
    public float sfx = 0;

    public void SoundControl()
    {
        mixer.SetFloat(nameof(master), master);
        mixer.SetFloat(nameof(bgm), bgm);
        mixer.SetFloat(nameof(sfx), sfx);


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundControl();
    }
}
