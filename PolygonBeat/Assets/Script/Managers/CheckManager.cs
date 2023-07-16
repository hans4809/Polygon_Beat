using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckManager : MonoBehaviour
{
    public Action KeyAction = null;
    void Start()
    {
    }
    public void Init()
    {
    }
    public void OnUpdate()
    {
        if(Input.anyKey == false)
        {
            return;
        }
        if (KeyAction != null)
            KeyAction.Invoke();
    }
}
