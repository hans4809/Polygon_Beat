using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init();  return s_instance; } }
    UI_Manager _ui = new UI_Manager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    DataManagerEx _data = new DataManagerEx();
    //CheckManager _checkManager = new CheckManager();
    //MapManager _mapManager = new MapManager();
    public static UI_Manager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    //public static CheckManager CheckManager { get { return Instance._checkManager; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static DataManagerEx Data { get { return Instance._data; } }
    //public static MapManager Map { get { return Instance._mapManager; } }
    void Start() 
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        //_checkManager.OnUpdate();
        //_mapManager.OnUpdate();
    }
    static void Init()
    {
        GameObject go = GameObject.Find("@Manager");
        if (go == null)
        {
            go = new GameObject { name = "@Manager" };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<Managers>();
    }
}