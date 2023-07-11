using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    private static SoundManager instance;

    private float savedMasterVolume = 1f; 
    private float savedBGMVolume = 1f; 
    private float savedSFXVolume = 1f; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void SetMasterVolume(float volume)
    {
        savedMasterVolume = volume;
    }

    
    public void SetBGMVolume(float volume)
    {
        savedBGMVolume = volume;
    }

    
    public void SetSFXVolume(float volume)
    {
        savedSFXVolume = volume;
    }

    
    public float GetMasterVolume()
    {
        return savedMasterVolume;
    }

    
    public float GetBGMVolume()
    {
        return savedBGMVolume;
    }

 
    public float GetSFXVolume()
    {
        return savedSFXVolume;
    }

  
    public static SoundManager Instance
    {
        get { return instance; }
    }
}
