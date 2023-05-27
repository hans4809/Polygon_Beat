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
        
    }

    void GameFinish() 
    { 
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        quitButton.onClick.AddListener(GameFinish);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameFinish();
        }
    }
}
