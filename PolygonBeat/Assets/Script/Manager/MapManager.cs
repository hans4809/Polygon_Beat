using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    public int[] coinIndex;

    public void InstantiateGround(List<string> _resourceStrings, List<GameObject> grounds, int index, Vector3 position, Transform transformParent) // 게임오브젝트 복제하는 함수
    {
        GameObject myGameObject;
        if (index >= DataManager.singleTon.currentMusic.data.Count)
        {
            return;
        }
        switch (DataManager.singleTon.currentMusic.data[index].count)
        {
            case 2:
                myGameObject = Managers.Resource.Instantiate(_resourceStrings[1], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                grounds.Add(myGameObject);
                break;
            case 3:
                myGameObject = Managers.Resource.Instantiate(_resourceStrings[2], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                grounds.Add(myGameObject);
                break;
            case 4:
                myGameObject = Managers.Resource.Instantiate(_resourceStrings[3], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                grounds.Add(myGameObject);
                break;
            default:
                myGameObject = Managers.Resource.Instantiate(_resourceStrings[0], position, transformParent);
                myGameObject.name = DataManager.singleTon.currentMusic.data[index].count.ToString();
                grounds.Add(myGameObject);
                break;
        }
    }
    public void CreateGround(List<string> _resourceStrings, List<GameObject> grounds, string coinResourceString, Transform transformParent)
    {
        if (grounds.Count == 0)
        {
            coinIndex = new int[DataManager.singleTon.currentMusic.data.Count / 10];
            int coinNum = 0;
            for (int j = 0; j < DataManager.singleTon.currentMusic.data.Count / 10; j++)
            {
                coinIndex[j] = UnityEngine.Random.Range(j * 10, j * 10 + 10);
            }

            for (int i = -1; i < DataManager.singleTon.currentMusic.data.Count + 1; i++)
            {
                InstantiateGround(_resourceStrings, grounds, i + 1, new Vector3(i + 1, 0, 0), transformParent);
                if (coinNum >= DataManager.singleTon.currentMusic.data.Count / 10)
                {
                    coinNum = DataManager.singleTon.currentMusic.data.Count / 10;
                    continue;
                }
                else
                {
                    if (i == coinIndex[coinNum])
                    {
                        Managers.Resource.Instantiate(coinResourceString, new Vector3(i, 0.7f, 0), grounds[i].transform);
                        coinNum++;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < grounds.Count; i++)
            {
                switch (DataManager.singleTon.currentMusic.data[i].count)
                {
                    case 2:
                        grounds[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_resourceStrings[1]);
                        break;
                    case 3:
                        grounds[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_resourceStrings[2]);
                        break;
                    case 4:
                        grounds[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_resourceStrings[3]);
                        break;
                    default:
                        grounds[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_resourceStrings[0]);
                        break;
                }
            }
        }

    }
}
