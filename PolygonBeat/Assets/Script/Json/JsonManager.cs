using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static Define;

public class JsonManager
{
    public void Save(CharacterData data)
    {
        //�ȵ���̵忡���� ���� ��ġ�� �ٸ��� ���־�� �Ѵ�
        //Application.dataPath�� �̿��ϸ� ���� �������� ���۸� �غ��� �ٶ���
        //�ȵ���̵��� ��쿡�� ������������ �������� 2�������ͷ� ��ȯ�� �ؾ��Ѵ�

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
        //�̷����� �ϴ� �����Ͱ� �ؽ�Ʈ�� ��ȯ�� �ȴ�
        //jsonUtility�� �̿��Ͽ� data�� WholeGameData�� json������ text�� �ٲپ��ش�
        //���Ͻ�Ʈ���� �̷��� �������ְ� �������ָ�ȴ� ��
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }
    public void Save(WholeGameData data)
    {
        //�ȵ���̵忡���� ���� ��ġ�� �ٸ��� ���־�� �Ѵ�
        //Application.dataPath�� �̿��ϸ� ���� �������� ���۸� �غ��� �ٶ���
        //�ȵ���̵��� ��쿡�� ������������ �������� 2�������ͷ� ��ȯ�� �ؾ��Ѵ�

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
        //�̷����� �ϴ� �����Ͱ� �ؽ�Ʈ�� ��ȯ�� �ȴ�
        //jsonUtility�� �̿��Ͽ� data�� WholeGameData�� json������ text�� �ٲپ��ش�
        //���Ͻ�Ʈ���� �̷��� �������ְ� �������ָ�ȴ� ��
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
        //�������� ���̺�� �Ȱ���
        //���Ͻ�Ʈ���� ������ش�. ���ϸ�带 open���� �ؼ� �����ش�. �� ���۸��̴�
        if (!Directory.Exists(builder.ToString()))
        {
            //���丮�� ���°�� ������ش�
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(appender);

        if (File.Exists(builder.ToString()))
        {
            //���̺� ������ �ִ°��
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);

            //�ؽ�Ʈ�� string���� �ٲ۴����� FromJson�� �־��ָ��� �츮�� �� �� �ִ� ��ü�� �ٲ� �� �ִ�
            wholeGameData = JsonUtility.FromJson<WholeGameData>(jsonData);
        }
        else
        {
            //���̺������� ���°��
            wholeGameData = new WholeGameData(false,0,50,50,50,0);
        }
        return wholeGameData;
        //�� ������ ���ӸŴ�����, �ε����� �Ѱ��ִ� ���̴�
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
        //�������� ���̺�� �Ȱ���
        //���Ͻ�Ʈ���� ������ش�. ���ϸ�带 open���� �ؼ� �����ش�. �� ���۸��̴�
        if (!Directory.Exists(builder.ToString()))
        {
            //���丮�� ���°�� ������ش�
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(appender);

        if (File.Exists(builder.ToString()))
        {
            //���̺� ������ �ִ°��
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);
            //TextAsset textAsset = Resources.Load<TextAsset>(builder.ToString());
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);
            //�ؽ�Ʈ�� string���� �ٲ۴����� FromJson�� �־��ָ��� �츮�� �� �� �ִ� ��ü�� �ٲ� �� �ִ�
            musicData = JsonUtility.FromJson<MusicData>(jsonData);
        }
        else
        {
            musicData= new MusicData();
        }
        return musicData;
        //�� ������ ���ӸŴ�����, �ε����� �Ѱ��ִ� ���̴�
    }
}
