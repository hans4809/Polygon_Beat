using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.U2D.Animation;
using UnityEngine;
using static Define;

public class JsonManager
{
    public void Save(UserCharacterData data)
    {
        //안드로이드에서의 저장 위치를 다르게 해주어야 한다
        //Application.dataPath를 이용하면 어디로 가는지는 구글링 해보길 바란다
        //안드로이드의 경우에는 데이터조작을 막기위해 2진데이터로 변환을 해야한다

        string savePath = Application.dataPath;
        string appender = "/userData/CharacterData.json";
#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDROID
        //savePath = Application.persistentDataPath;
 
#endif
        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        string jsonText = JsonUtility.ToJson(data, true);
        //이러면은 일단 데이터가 텍스트로 변환이 된다
        //jsonUtility를 이용하여 data인 WholeGameData를 json형식의 text로 바꾸어준다
        //파일스트림을 이렇게 지정해주고 저장해주면된당 끗
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }
    public void Save(WholeGameData data)
    {
        //안드로이드에서의 저장 위치를 다르게 해주어야 한다
        //Application.dataPath를 이용하면 어디로 가는지는 구글링 해보길 바란다
        //안드로이드의 경우에는 데이터조작을 막기위해 2진데이터로 변환을 해야한다

        string savePath = Application.dataPath;
        string appender = "/userData/WholeGameData.json";
#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDROID
        //savePath = Application.persistentDataPath;

#endif
        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        string jsonText = JsonUtility.ToJson(data, true);
        //이러면은 일단 데이터가 텍스트로 변환이 된다
        //jsonUtility를 이용하여 data인 WholeGameData를 json형식의 text로 바꾸어준다
        //파일스트림을 이렇게 지정해주고 저장해주면된당 끗
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }

    public WholeGameData LoadWholeGameData()
    {
        WholeGameData wholeGameData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/WholeGameData.json";
#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID
        //loadPath = Application.persistentDataPath;
#endif
        StringBuilder builder = new StringBuilder(loadPath);
        builder.Append(directory);
        //위까지는 세이브랑 똑같다
        //파일스트림을 만들어준다. 파일모드를 open으로 해서 열어준다. 다 구글링이다
        if (!Directory.Exists(builder.ToString()))
        {
            //디렉토리가 없는경우 만들어준다
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(appender);

        if (File.Exists(builder.ToString()))
        {
            //세이브 파일이 있는경우
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);

            //텍스트를 string으로 바꾼다음에 FromJson에 넣어주면은 우리가 쓸 수 있는 객체로 바꿀 수 있다
            wholeGameData = JsonUtility.FromJson<WholeGameData>(jsonData);
        }
        else
        {
            //세이브파일이 없는경우
            wholeGameData = new WholeGameData(false,0,50,50,50,0);
        }
        return wholeGameData;
        //이 정보를 게임매니저나, 로딩으로 넘겨주는 것이당
    }
    public MusicData LoadMusicData()
    {
        MusicData musicData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/MusicData.json";
#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID
        //loadPath = Application.persistentDataPath;
#endif
        StringBuilder builder = new StringBuilder(loadPath);
        builder.Append(directory);
        //위까지는 세이브랑 똑같다
        //파일스트림을 만들어준다. 파일모드를 open으로 해서 열어준다. 다 구글링이다
        if (!Directory.Exists(builder.ToString()))
        {
            //디렉토리가 없는경우 만들어준다
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(appender);

        if (File.Exists(builder.ToString()))
        {
            //세이브 파일이 있는경우
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);
            //TextAsset textAsset = Resources.Load<TextAsset>(builder.ToString());
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);
            //텍스트를 string으로 바꾼다음에 FromJson에 넣어주면은 우리가 쓸 수 있는 객체로 바꿀 수 있다
            musicData = JsonUtility.FromJson<MusicData>(jsonData);
        }
        else
        {
            musicData= new MusicData();
        }
        return musicData;
        //이 정보를 게임매니저나, 로딩으로 넘겨주는 것이당
    }
    public UserCharacterData LoadCharacterData()
    {
        UserCharacterData userCharacterData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/CharacterData.json";
#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID
        //loadPath = Application.persistentDataPath;
#endif
        StringBuilder builder = new StringBuilder(loadPath);
        builder.Append(directory);
        //위까지는 세이브랑 똑같다
        //파일스트림을 만들어준다. 파일모드를 open으로 해서 열어준다. 다 구글링이다
        if (!Directory.Exists(builder.ToString()))
        {
            //디렉토리가 없는경우 만들어준다
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(appender);

        if (File.Exists(builder.ToString()))
        {
            //세이브 파일이 있는경우
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);
            //TextAsset textAsset = Resources.Load<TextAsset>(builder.ToString());
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);
            //텍스트를 string으로 바꾼다음에 FromJson에 넣어주면은 우리가 쓸 수 있는 객체로 바꿀 수 있다
            userCharacterData = JsonUtility.FromJson<UserCharacterData>(jsonData);
        }
        else
        {
            userCharacterData = new UserCharacterData();
        }
        return userCharacterData;
        //이 정보를 게임매니저나, 로딩으로 넘겨주는 것이당
    }
}
