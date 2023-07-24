using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static DataDefine;

public class UI_CharacterPanel : UI_Base 
{
    [SerializeField] GameObject content;
    [SerializeField] RectTransform contentRect;
    [SerializeField] UserCharacterData userCharacterData;
    [SerializeField] string spritePath;
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
        userCharacterData = DataManager.singleTon.userCharacterData;
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        content = Get<GameObject>((int)GameObjects.Content);
        contentRect = content.GetComponent<RectTransform>();
        GetButton((int)Buttons.Right).gameObject.AddUIEvent(RightClick);
        GetButton((int)Buttons.Left).gameObject.AddUIEvent(LeftClick);
        foreach(Transform child in content.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        if (this.transform.parent.GetComponent<UI_CharacterSquare>())
        {
            for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
            {
                GameObject go = Managers.Resource.Instantiate("UI/UI_CharacterButton");
                go.transform.SetParent(content.transform);
                spritePath = $"Character/{userCharacterData.characters[i]._rarity}/{userCharacterData.characters[i]._rarity}{userCharacterData.characters[i]._index}_square";
                go.GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>(spritePath);
                if (!userCharacterData.characters[i]._isHave)
                {
                    go.GetComponent<Image>().color = Color.gray;
                }
            }
        }
        else
        {
            for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
            {
                GameObject go = Managers.Resource.Instantiate("UI/UI_CharacterButton");
                go.transform.SetParent(content.transform);
                spritePath = $"Character/{userCharacterData.characters[i]._rarity}/{userCharacterData.characters[i]._rarity}{userCharacterData.characters[i]._index}_triangle";
                go.GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>(spritePath);
                if (!userCharacterData.characters[i]._isHave)
                {
                    go.GetComponent<Image>().color = Color.gray;
                }
            }
        }
        pos = contentRect.localPosition.x;
        movepos = contentRect.rect.xMax - contentRect.rect.xMax / count;
    }
    IEnumerator scroll()
    {
        while (isScroll)
        {
            contentRect.localPosition = Vector2.Lerp(contentRect.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if(Vector2.Distance(contentRect.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                isScroll = false;
            }
            yield return null;
        }
    }
    public void RightClick(PointerEventData data)
    {
        if(contentRect.rect.xMin + contentRect.rect.xMax/count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos - contentRect.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }
    public void LeftClick(PointerEventData data)
    {
        if (contentRect.rect.xMax - contentRect.rect.xMax / count == movepos)
        {

        }
        else
        {
            isScroll = true;
            movepos = pos + contentRect.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
