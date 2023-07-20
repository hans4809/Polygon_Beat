using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init();  return s_instance; } }

    UI_Manager _ui = new UI_Manager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    InputManager _input = new InputManager();
    SoundManager _sound = new SoundManager();
    MapManager _map = new MapManager();
    public static UI_Manager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static InputManager Input { get { return Instance._input; } }
    public static SoundManager Sound { get { return Instance._sound;  } }
    public static MapManager Map { get { return Instance._map; } }
    void Start() 
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
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

        s_instance._sound.Init();
    }
    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
    }
}
