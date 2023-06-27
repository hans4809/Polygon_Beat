using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGacha : MonoBehaviour
{
    public Button machineButton;
    public GameObject characterCanvas;
    bool characterstate;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void CharacterMachine() 
    { 
        
    }
    // Update is called once per frame
    void Update()
    {
        machineButton.onClick.AddListener(CharacterMachine);
    }
}
