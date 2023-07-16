using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManagerEx : MonoBehaviour
{
    public Dictionary<int, DataDefine.MusicData> MusicData { get; private set; } = new Dictionary<int, DataDefine.MusicData>();
    public void Init()
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/MusicDataEx");
        DataDefine.MusicData musicData = JsonUtility.FromJson<DataDefine.MusicData>(textAsset.text);

    }
}
