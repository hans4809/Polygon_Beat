using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [SerializeField] int totalWeight;
    [SerializeField] int normalWeight;
    [SerializeField] int rareWeight;
    [SerializeField] int epicWeight;
    [SerializeField] int weightRandom;
    [SerializeField] List<DataDefine.Characters> normalList = new List<DataDefine.Characters>();
    [SerializeField] List<DataDefine.Characters> rareList = new List<DataDefine.Characters>();
    [SerializeField] List<DataDefine.Characters> epicList = new List<DataDefine.Characters>();
    [SerializeField] public DataDefine.Characters selectCharacter;
    [SerializeField] Dictionary<string, List<DataDefine.Characters>> dic = new Dictionary<string, List<DataDefine.Characters>>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DataManager.singleTon.userCharacterData.characters.Count; i++)
        {
            switch (DataManager.singleTon.userCharacterData.characters[i]._rarity)
            {
                case "normal":
                    if (!DataManager.singleTon.userCharacterData.characters[i]._isHave)
                    {
                        normalList.Add(DataManager.singleTon.userCharacterData.characters[i]);
                        normalWeight += DataManager.singleTon.userCharacterData.characters[i]._weight;
                    }
                    break;
                case "rare":
                    if (!DataManager.singleTon.userCharacterData.characters[i]._isHave)
                    {
                        rareList.Add(DataManager.singleTon.userCharacterData.characters[i]);
                        rareWeight += DataManager.singleTon.userCharacterData.characters[i]._weight;
                    }
                    break;
                case "epic":
                    if (!DataManager.singleTon.userCharacterData.characters[i]._isHave)
                    {
                        epicList.Add(DataManager.singleTon.userCharacterData.characters[i]);
                        epicWeight += DataManager.singleTon.userCharacterData.characters[i]._weight;
                    }
                    break;
            }
        }
        totalWeight = normalWeight + rareWeight + epicWeight;
    }

    public void FGacha()
    {
        weightRandom = Random.Range(0, totalWeight);
        if (weightRandom < normalWeight)
        {
            int index = (int)Random.Range(0, normalList.Count);
            selectCharacter = normalList[index];
            normalWeight -= normalList[index]._weight;
            normalList.RemoveAt(index);
            selectCharacter._isHave = true;
            DataManager.singleTon.jsonManager.Save<DataDefine.UserCharacterData>(DataManager.singleTon.userCharacterData);
            Managers.UI.ShowPopUpUI<UI_GachaGet>();
        }
        else if (weightRandom >= normalWeight && weightRandom < normalWeight + rareWeight)
        {
            int index = (int)Random.Range(0, normalList.Count);
            selectCharacter = rareList[index];
            rareWeight -= rareList[index]._weight;
            rareList.RemoveAt(index);
            selectCharacter._isHave = true;
            DataManager.singleTon.jsonManager.Save<DataDefine.UserCharacterData>(DataManager.singleTon.userCharacterData);
            Managers.UI.ShowPopUpUI<UI_GachaGet>();
        }
        else if (weightRandom >= normalWeight + rareWeight && weightRandom <= totalWeight)
        {
            int index = (int)Random.Range(0, normalList.Count);
            selectCharacter = epicList[index];
            epicWeight -= epicList[index]._weight;
            epicList.RemoveAt(index);
            selectCharacter._isHave = true;
            DataManager.singleTon.jsonManager.Save<DataDefine.UserCharacterData>(DataManager.singleTon.userCharacterData);
            Managers.UI.ShowPopUpUI<UI_GachaGet>();
        }
    }
    private void Update()
    {
        totalWeight = normalWeight + rareWeight + epicWeight;
    }
}
