using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { /*Init();*/ return s_instance; } }
    // Start is called before the first frame update
    UI_Manager ui = new UI_Manager();
    public static UI_Manager UI { get { return Instance.ui; } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}