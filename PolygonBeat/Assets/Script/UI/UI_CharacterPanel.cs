using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CharacterPanel : UI_Base 
{
    [SerializeField] RectTransform content;
    [SerializeField] int count = 29;
    [SerializeField] float pos;
    [SerializeField] float movepos;
    [SerializeField] bool isScroll = false;
    public enum GameObjects
    {
        Content
    }
    public enum Buttons
    {
        Right,
        Left
    }
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        content = Get<GameObject>((int)GameObjects.Content).GetComponent<RectTransform>();
        GetButton((int)Buttons.Right).gameObject.AddUIEvent(RightClick);
        GetButton((int)Buttons.Left).gameObject.AddUIEvent(LeftClick);
        pos = content.localPosition.x;
        movepos = content.rect.xMax - content.rect.xMax / count;
    }
    IEnumerator scroll()
    {
        while (isScroll)
        {
            content.localPosition = Vector2.Lerp(content.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if(Vector2.Distance(content.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                isScroll = false;
            }
            yield return null;
        }
    }
    public void RightClick(PointerEventData data)
    {
        if(content.rect.xMin + content.rect.xMax/count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos - content.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }
    public void LeftClick(PointerEventData data)
    {
        if (content.rect.xMax - content.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos + content.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
