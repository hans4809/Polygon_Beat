using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("UI/DebugTextComponentName", 11)]
public class Count : MonoBehaviour
{
    public Count Instance;
    public TextMeshProUGUI tmpUgui;
    public TMP_Text tmp_Text;
    //public MusicPlayerManager musicPlayerManager;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        Setting();
    }

    public void Setting()
    {
        this.gameObject.SetActive(true);
        time = 0f;
        tmp_Text.text = "3";
        //musicPlayerManager = FindAnyObjectByType<MusicPlayerManager>();
    }
    public void Counting()
    {
        if (/*musicPlayerManager.GetBGMPlayer().time*/ Managers.Sound._audioSources[(int)Define.Sound.BGM].time == 0)
        {
            time += Time.deltaTime;
            if (time >= 0 && time < 1)
            {
                tmp_Text.text = "3";
            }
            if (time >= 1 && time < 2)
            {
                tmp_Text.text = "2";
            }
            if (time >= 2 && time < 3)
            {
                tmp_Text.text = "1";
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Counting();
    }
}
