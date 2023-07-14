using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    int _order = 10;

    Stack<UI_Popup> _popUpStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@ui_root");
            if (root == null)
            {
                root = new GameObject { name = "@ui_root" };
            }
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    public T ShowPopUpUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        //GameObject go = Managers.Resource.Instantiate($"UI/PopUP/{name}");
        //T popUp = Util.GetOrAddComponent<T>(go);
        //_popUpStack.Push(popUp);
        //gameobject root = gameobject.Find("@ui_root");
        //if (root == null)
        //{
        //    root = new gameobject { name = "@ui_root"};
        //};
        //go.transform.SetParent(root.transform);
        //return popUP;
        return null;
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        //GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        //T sceneUI = Util.GetOrAddComponent<T>(go);
        //_sceneUI = sceneUI;
        //GameObject root = GameObject.Find("@UI_Root");
        //if(root == null)
        //{
        //    root = new GameObject { name = "@UI_Root"; };
        //}
        //go.transform.SetParent(root.transform);
        //return sceneUI;
        return null;
    }

    public void ClosePopUpUI()
    {
        if(_popUpStack.Count == 0)
        {
            return;
        }
        UI_Popup popuUP = _popUpStack.Pop();
        //Managers.Resource.Destroy(popuUP.gameObject);
        popuUP = null;

        _order--;
    }
    public void ClosePopUpUI(UI_Popup popUp)
    {
        if (_popUpStack.Count == 0)
        {
            return;
        }
        if(_popUpStack.Peek() != popUp)
        {
            Debug.Log("Close PopUp Failed");
            return;
        }
        ClosePopUpUI();

    }

    public void CloseAllPopUPUI()
    {
        while (_popUpStack.Count > 0)
        {
            ClosePopUpUI();
        }
    }
}
