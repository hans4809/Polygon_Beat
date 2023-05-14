using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour // ���� �� �� ����
{
    public static DataManager singleTon;
    public PlayerData playerData;
    public JsonManager testJson;
    public List<GameObject> gameObject;
    public AnalyzeExample analyzeExample;
    private Vector3 savePosition;
    // Start is called before the first frame update
    private void Awake()
    {
        testJson = new JsonManager();
        if (singleTon == null)
        {
            singleTon = this;
            DontDestroyOnLoad(gameObject[0]);
        }
        else if (singleTon != this)
            Destroy(singleTon.gameObject[0]);
        playerData = new PlayerData();
        playerData = testJson.LoadSaveData();
        if (playerData != null)
        {
            gameObject[1].transform.SetPositionAndRotation(playerData.playerSavePosition, Quaternion.identity);
        }
        savePosition = new Vector3((int)(analyzeExample.beats.Count / 2), 0.6f,0);
        Debug.Log(analyzeExample.beats.Count);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject[1].transform.parent.position.x >= savePosition.x)
        {
            playerData = new PlayerData(savePosition, 0);
            testJson.Save(playerData);
        }
    }
}