using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public List<Button> buttonList;
    // Start is called before the first frame update
    void Start()
    {
        buttonList[0].onClick.AddListener(ChangetoSelectScene);
        buttonList[1].onClick.AddListener(ChangetoplayScene);
    }
    public void ChangetoplayScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ChangetoSelectScene()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
