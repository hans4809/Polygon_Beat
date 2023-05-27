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
    public bool isPause;
    public void Resume()
    {
        audioSource.UnPause();
        pauseMenuCanvas.SetActive(false);
        pauseButton.SetActive(true);
        isPause = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        audioSource.Pause();
        pauseMenuCanvas.SetActive(true);
        pauseButton.SetActive(false);
        isPause = true;
        Time.timeScale = 0f;
    }
    public void Start()
    {
        isPause = false;
        pauseButton.SetActive(true);
        pauseMenuCanvas.SetActive(false);
        buttonList[0].onClick.AddListener(Pause);
        buttonList[1].onClick.AddListener(Resume);
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
