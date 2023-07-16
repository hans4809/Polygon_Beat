using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();
    protected void Bind<T>(Type type) where T : UnityEngine.Object // 타입에 맞는 열거형들 전부 _objects 배열에 바인딩
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            if(objects[i] == null)
            {
                Debug.Log($"Failed to bind{names[i]}");
            }
        }
    } 

    protected T Get<T>(int index) where T : UnityEngine.Object //바인딩 된 _objects 배열에서 원하는 것 Get해옴
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        return objects[index] as T;
    }

    protected Text GetText(int index) { return Get<Text>(index); }
    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }

    public static void ADDUIEvent(GameObject go, Action<PointerEventData> action, UI_Define.UIEvent type = UI_Define.UIEvent.Click)
    {
        UI_EventHandler _event = Util.GetOrAddComponent<UI_EventHandler>(go);
        switch (type)
        {
            case UI_Define.UIEvent.Click:
                _event.OnClickHandler += action;
                _event.OnClickHandler -= action;
                break;
            case UI_Define.UIEvent.Drag:
                break;
        }
        
    }
}
