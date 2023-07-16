using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuit : MonoBehaviour
{
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(GameFinish);
    }

    void GameFinish() 
    { 
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameFinish();
        }
    }
}
