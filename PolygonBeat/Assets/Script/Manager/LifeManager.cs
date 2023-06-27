using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] List<Sprite> lifeSprite;
    [SerializeField] List<Image> lifeImage;

    // Start is called before the first frame update
    public void Start()
    {
        for(int i = 0; i < lifeImage.Count; i++)
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
        SceneManager.LoadScene("GameOver");
    }

    private void Update()
    {
        if (life <= 0)
            GameOver();
    }
}
