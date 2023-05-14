using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public int life = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            life--;
        }
        if(life == 0)
        {
            GameOver();
        }
    }
}
