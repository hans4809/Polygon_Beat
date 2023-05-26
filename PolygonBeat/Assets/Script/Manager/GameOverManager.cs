using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public List<GameObject> lives;
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
            switch (life)
            {
                case 2:
                    lives[2].SetActive(false);
                    break;
                case 1:
                    lives[1].SetActive(false);
                    break;
                case 0:
                    lives[0].SetActive(false); 
                    break;
            }
        }
        if(life == 0)
        {
            GameOver();
        }
    }
}
