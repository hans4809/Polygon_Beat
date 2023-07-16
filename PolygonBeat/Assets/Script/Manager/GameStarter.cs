using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using RhythmTool;

using UnityEngine.SceneManagement;




public class GameStarter : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
