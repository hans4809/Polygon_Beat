using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false) // 게임오브젝트 자체를 반환
    {
        Transform transfrom = FindChild<Transform>(go, name, recursive);
        if (transfrom == null)
        {
            return null;
        }
        return transfrom.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object // 게임 오브젝트의 자식들의 T의 컴포넌트 반환
    {
        if (go == null)
            return null;
        if(recursive == false) // 직속 자식일 경우
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }

        }
        else // 직속 자식이 아닌 경우
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if(string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }

            }
        }
        return null;
    }

}
