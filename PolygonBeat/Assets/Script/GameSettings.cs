using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Button settingsButton;
    public GameObject settingCanvas;
    bool settingstate;


    // Start is called before the first frame update
    void Start()
    {
         settingCanvas.SetActive(false);
         settingstate = false;
    }

    void SoundSettings() 
    {
        settingCanvas.SetActive(true);
        settingstate = true;
        settingsButton.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        settingsButton.onClick.AddListener(SoundSettings);
    }
}
