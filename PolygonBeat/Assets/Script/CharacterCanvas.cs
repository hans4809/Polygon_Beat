using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CharacterCanvas : MonoBehaviour
{
    public Button characterButton;
    public Button settingButton;
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

       // GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        characterButton.onClick.AddListener(CharacterSetting);
    }
}



    
   
