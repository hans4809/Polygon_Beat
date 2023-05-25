using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour // 여긴 볼 거 없음
{
    public static DataManager singleTon;
    public PlayerData playerData;
    public JsonManager testJson;
    public List<GameObject> gameObjects;
    public AnalyzeExample analyzeExample;
    private Vector3 savePosition;
    // Start is called before the first frame update
    private void Awake()
    {
        testJson = new JsonManager();
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(gameObjects[0]);
        }
        else if (singleTon != this)
            Destroy(singleTon.gameObjects[0]);
        playerData = new PlayerData();
        playerData = testJson.LoadSaveData();
        if (playerData != null)
        {
            //gameObjects[1].transform.SetPositionAndRotation(playerData.playerSavePosition, Quaternion.identity);
        }
        savePosition = new Vector3((int)(analyzeExample.beats.Count / 2), 0.6f,0);
        Debug.Log(analyzeExample.beats.Count);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
