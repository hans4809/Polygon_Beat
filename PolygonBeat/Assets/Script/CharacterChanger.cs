using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;
using static Define;


public class CharacterChanger : MonoBehaviour
{
    public Image changeImage;
    public Sprite changeSprite;
    public Button changeButton;
    public void OnCharacterSelected()
    {
        if(changeImage != null||changeSprite != null)
        {
            DataManager.singleTon.playerSprite._image = changeImage;
            DataManager.singleTon.playerSprite._sprite = changeSprite;
        }
        return;
    }



    // Start is called before the first frame update
    void Start()
    {
        changeImage = GetComponent<Image>();
        changeSprite = changeImage.sprite;
        changeButton = GetComponent<Button>();
        changeButton.onClick.AddListener(OnCharacterSelected);
    }

    // Update is called once per frame
    void Update()
    {

    }
}