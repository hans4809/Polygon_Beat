using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public List<GameObject> lives;
    public int life = 3;
    public TouchCheck touchcheck;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject lifeObject in lives)
        {
            lifeObject.SetActive(true);
        }
    }

    public void LifeReduce()
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
                GameOver();
                break;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void Update()
    {
            
    }
}
