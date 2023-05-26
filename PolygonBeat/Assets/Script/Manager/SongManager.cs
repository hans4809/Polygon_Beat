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
    public DataManager dataManager;
    public JsonManager jsonManager;
    public WholeGameData wholeGameData;

    public void FirstSong()
    {
        wholeGameData._currentSong = 0;
        Debug.Log(wholeGameData._currentSong);
        jsonManager.Save(wholeGameData);
        SceneManager.LoadScene("GameScene");    
    }

    public void SecondSong()
    {
        wholeGameData._currentSong = 1;
        Debug.Log(wholeGameData._currentSong);
        jsonManager.Save(wholeGameData);
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        buttonList[0].onClick.AddListener(FirstSong);
        buttonList[1].onClick.AddListener(SecondSong);
        jsonManager = new JsonManager();
        wholeGameData = jsonManager.LoadWholeGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
