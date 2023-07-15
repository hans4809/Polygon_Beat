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
    public static UI_Manager UI { get { return Instance.ui; } }

    CheckManager checkManager = new CheckManager();
    public static CheckManager CheckManager { get { return Instance.checkManager; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    public static DataManager Data { get { return Instance._data; } }
    void Start() 
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        checkManager.OnUpdate();
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
