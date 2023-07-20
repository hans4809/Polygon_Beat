using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetting : MonoBehaviour
{
    public Button triangleButton;
    public Button squareButton;
    public GameObject triangleCanvas;
    public GameObject squareCanvas;
    bool settingstate;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void TriangleSetting() 
    { 
        triangleCanvas.SetActive(true);
        squareCanvas.SetActive(false);
    }

    void SquareSetting()
    {
        triangleCanvas.SetActive(false);
        squareCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        triangleButton.onClick.AddListener(TriangleSetting);
        squareButton.onClick.AddListener(SquareSetting);
    }
}
