using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    void BackButton() 
    {
        SceneManager.LoadScene("MainScene");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
