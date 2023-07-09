using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using RhythmTool;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseButton;
    public List<Button> buttonList;
    public GameObject pauseMenuCanvas;
    public AudioSource audioSource;
    public GameObject Coin;
    public GameObject Count;
    public bool isPause;
    public void Resume()
    {
        audioSource.UnPause();
        pauseMenuCanvas.SetActive(false);
        pauseButton.SetActive(true);
        Coin.SetActive(true);
        Count.SetActive(true);
        isPause = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        audioSource.Pause();
        pauseMenuCanvas.SetActive(true);
        pauseButton.SetActive(false);
        Coin.SetActive(false);
        Count.SetActive(false);
        isPause = true;
        Time.timeScale = 0f;
    }
    void Start()
    {
        isPause = false;
        pauseButton.SetActive(true);
        Coin.SetActive(true);
        Count.SetActive(true);
        pauseMenuCanvas.SetActive(false);
        buttonList[0].onClick.AddListener(Pause);
        buttonList[1].onClick.AddListener(Resume);
    }

    public void Init()
    {
        isPause = false;
        pauseButton.SetActive(true);
        Coin.SetActive(true);
        Count.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
                Resume();
            else
                Pause();
        }
    }
}
