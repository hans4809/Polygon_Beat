using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundSetting : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider BgmSlider;
    public Slider SfxSlider;

    public void SetBgm() 
    {
        audioMixer.SetFloat("Bgm", Mathf.Log10(BgmSlider.value) * 20);
    }

    public void SetSfx()
    {
        audioMixer.SetFloat("Sfx", Mathf.Log10(SfxSlider.value) * 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
