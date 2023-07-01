using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] List<Sprite> lifeSprite;
    [SerializeField] List<UnityEngine.UI.Image> lifeImage;
    [SerializeField] List<UnityEngine.UI.Button> buttonList;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] MusicPlayerManager musicPlayerManager;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayerManager = FindAnyObjectByType<MusicPlayerManager>();
        life = 3;
        for(int i = 0; i < life; i++)
        {
            lifeImage[i].sprite = lifeSprite[0];
        }
        buttonList[0].onClick.AddListener(ChangetoSelectScene);
        buttonList[1].onClick.AddListener(Replay);
    }
    public void Init()
    {
        life = 3;
        for (int i = 0; i < life; i++)
        {
            lifeImage[i].sprite = lifeSprite[0];
        }
    }

    public void LifeReduce()
    {
        life--;

        switch (life)
        {
            case 2:
                lifeImage[2].sprite = lifeSprite[1];
                break;
            case 1:
                lifeImage[1].sprite = lifeSprite[1];
                break;
            case 0:
                lifeImage[0].sprite = lifeSprite[1];
                break;
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        musicPlayerManager.StopBGM(DataManager.singleTon.wholeGameData._currentSong.ToString());

    }
    public void ChangetoSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void Replay()
    {

    }
    private void Update()
    {
        if (life <= 0)
            GameOver();
    }
}
