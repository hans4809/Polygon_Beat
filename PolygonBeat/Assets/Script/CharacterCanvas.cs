using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCanvas : MonoBehaviour
{
    public Button characterButton;
    public GameObject characterCanvas;
    bool characterstate;
    // Start is called before the first frame update
    void Start()
    {
        characterCanvas.SetActive(false);
        characterstate = false;
    }

    void CharacterSetting()
    {
        characterCanvas.SetActive(true); 
        characterstate = true;
    }

    // Update is called once per frame
    void Update()
    {
        characterButton.onClick.AddListener(CharacterSetting);
    }
}



    
   
