using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init();  return s_instance; } }
    UI_Manager ui = new UI_Manager();
    ResourceManager _resource = new ResourceManager();
    DataManager _data = new DataManager();
    CheckManager _checkManager = new CheckManager();
    MapManager _mapManager = new MapManager();
    public static UI_Manager UI { get { return Instance.ui; } }
    public static CheckManager CheckManager { get { return Instance._checkManager; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static DataManager Data { get { return Instance._data; } }
    public static MapManager Map { get { return Instance._mapManager; } }
    void Start() 
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        _checkManager.OnUpdate();
        //_mapManager.OnUpdate();
    }
    static void Init()
    {
        GameObject go = GameObject.Find("@Manager");
        if (s_instance == null)
        {
            go = new GameObject { name = "@Manager" };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<Managers>();
    }
}
