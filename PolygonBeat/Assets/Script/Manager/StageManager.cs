using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Define;


public class SongManager : MonoBehaviour
{
    public List<Button> buttonList;

    public void FirstSong()
    {
        DataManager.singleTon.wholeGameData._currentSong = 0;
        SceneManager.LoadScene("GameScene");    
    }

    public void SecondSong()
    {
        DataManager.singleTon.wholeGameData._currentSong = 1;
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    public void Awake()
    {
        buttonList[0].onClick.AddListener(FirstSong);
        buttonList[1].onClick.AddListener(SecondSong);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
