using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class JsonManager
{
    public void Save(PlayerData data)
    {
        //�ȵ���̵忡���� ���� ��ġ�� �ٸ��� ���־�� �Ѵ�
        //Application.dataPath�� �̿��ϸ� ���� �������� ���۸� �غ��� �ٶ���
        //�ȵ���̵��� ��쿡�� ������������ �������� 2�������ͷ� ��ȯ�� �ؾ��Ѵ�

        string savePath = Application.dataPath;
        string appender = "/userData/SaveData.json";
#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDROID
        savePath = Application.persistentDataPath;
 
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

    public PlayerData LoadSaveData()
    {
        PlayerData playerData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/SaveData.json";
#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID
        loadPath = Application.persistentDataPath;
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
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            //���̺������� ���°��
            playerData = new PlayerData();
        }
        return playerData;
        //�� ������ ���ӸŴ�����, �ε����� �Ѱ��ִ� ���̴�
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
