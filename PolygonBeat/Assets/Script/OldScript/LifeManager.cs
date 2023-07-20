using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] GameObject gameOverPanel;

    public void LifeReduce()
    {
        Debug.Log("Life Reduce");
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
}
