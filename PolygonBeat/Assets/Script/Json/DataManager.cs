using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    public static DataManager singleTon;
    public PlayerData playerData;
    public JsonManager testJson;
    public GameObject gameObject;
    public AnalyzeExample analyzeExample;
    private Vector3 savePosition;
    // Start is called before the first frame update
    private void Start()
    {
        testJson = new JsonManager();
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (singleTon != this)
            Destroy(singleTon.gameObject);
        playerData = new PlayerData();
        playerData = testJson.LoadSaveData();
        if (playerData != null)
        {
            gameObject.transform.position = playerData.playerSavePosition;
        }
        savePosition = new Vector3((int)(analyzeExample.beats.Count / 2), 0.6f,0);
        Debug.Log(analyzeExample.beats.Count);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.position.x >= savePosition.x)
        {
            playerData = new PlayerData(savePosition, 0);
            testJson.Save(playerData);
        }
    }
}
