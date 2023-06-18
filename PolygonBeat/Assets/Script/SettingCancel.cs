using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCancel : MonoBehaviour
{
    public Button quitButton;
    public GameObject settingCanvas;
    bool settingstate;

    void QuitSetting()
    {
        settingCanvas.SetActive(false);
        settingstate = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        settingCanvas.SetActive(true);
        settingstate = true;
    }

    // Update is called once per frame
    void Update()
    {
        quitButton.onClick.AddListener(QuitSetting);
    }
}
