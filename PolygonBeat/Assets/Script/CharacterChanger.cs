using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;


public class CharacterChanger : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] CharacterSprites;


    public void OnCharacterSelected(int characterIndex)
    {
        characterImage.sprite = CharacterSprites[characterIndex];     
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}