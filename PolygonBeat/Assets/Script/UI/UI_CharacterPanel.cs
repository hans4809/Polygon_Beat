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
    [SerializeField] List<GameObject> character;
    [SerializeField] string spritePath;
    [SerializeField] int count;
    [SerializeField] float pos;
    [SerializeField] float movepos;
    [SerializeField] bool isScroll;
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
        isScroll = false;
        count = DataManager.singleTon.userCharacterData.characters.Count;
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
                character.Add(Managers.Resource.Instantiate("UI/UI_CharacterButton"));
                character[i].transform.SetParent(content.transform);
                spritePath = $"Character/{userCharacterData.characters[i]._rarity}/{userCharacterData.characters[i]._rarity}{userCharacterData.characters[i]._index}_square";
                character[i].GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>(spritePath);
                character[i].transform.localScale = new Vector3(1.25f , 1.25f, 1.25f);
                if (!userCharacterData.characters[i]._isHave)
                {
                    character[i].GetComponent<Image>().color = Color.gray;
                }
            }
        }
        else
        {
            for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
            {
                character.Add(Managers.Resource.Instantiate("UI/UI_CharacterButton"));
                character[i].transform.SetParent(content.transform);
                spritePath = $"Character/{userCharacterData.characters[i]._rarity}/{userCharacterData.characters[i]._rarity}{userCharacterData.characters[i]._index}_triangle";
                character[i].GetComponent<Image>().sprite = Managers.Resource.Load<Sprite>(spritePath);
                character[i].transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                if (!userCharacterData.characters[i]._isHave)
                {
                    character[i].GetComponent<Image>().color = Color.gray;
                }
            }
        }
        pos = contentRect.localPosition.x;
        movepos = contentRect.rect.xMax - contentRect.rect.xMax / count;
    }
    IEnumerator Scroll()
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
            StartCoroutine(Scroll());
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
            StartCoroutine(Scroll());

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent.GetComponent<UI_CharacterSquare>())
        {
            for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
            {
                if (userCharacterData.characters[i]._isHave && character[i].GetComponent<Image>().color == Color.gray)
                {
                    character[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
                
            }
        }
        else
        {
            for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
            {
                if (userCharacterData.characters[i]._isHave && character[i].GetComponent<Image>().color == Color.gray)
                {
                    character[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                }
            }
        }
    }
}
