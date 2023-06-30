using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Image characterImage;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = CharacterData.SelectedCharacterSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
