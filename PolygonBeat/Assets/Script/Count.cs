using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[AddComponentMenu("UI/DebugTextComponentName", 11)]
public class Count : MonoBehaviour
{
    public TextMeshProUGUI tmpUgui;
    public TMP_Text tmp_Text;
    public AudioSource bgmPlayer;
    float time;
    [SerializeField] GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        tmp_Text.text = "3";
        bgmPlayer = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        myGameObject = GameObject.Find("Count");
    }

    // Update is called once per frame
    void Update()
    {
        if(bgmPlayer.time == 0)
        {
            time += Time.deltaTime;
            if(time >= 0 && time < 1)
            {
                tmp_Text.text = "3";
            }
            if(time >= 1 && time < 2)
            {
                tmp_Text.text = "2";
            }
            if(time >= 2 && time < 3)
            {
                tmp_Text.text = "1";
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
