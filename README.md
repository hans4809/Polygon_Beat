# PolygonBeat
![icon (2)](https://github.com/user-attachments/assets/e23a8022-588d-4ec1-9902-1c58c6b439c2)

# 홍익대학교 ExP Make 2023 1학기 학기중 프로젝트 Polygon_Beat
Unity / 2D / 리듬

## 역할 분담 🧑‍💻
### 개발 인원 : 8명 [ExP Make 2023 1학기 학기 중 팀프로젝트]
| 이름 | 개인 역할 | 담당 역할 및 기능 |
| ------ | ---------- | ------ |
| 구지연 | 기획 | 메인 기획자 |
| 김예현 | 기획 | 서브 기획자 |
| 이민경 | 아트 | 디자이너 |
| 김수연 | 아트 | 디자이너 |
| 박연준 | 아트 | 디자이너 |
| 한효빈 | Developer | 개발 |
| 김수연 | Developer | 개발 |
| 김영재 | 사운드 | 사운드 |

## 개발 기간 📅
2023.04 ~ 2023.08

## 시연영상 
#### ⬇ Link Here ⬇
[https://youtu.be/4PYj3PyUdYQ](https://youtu.be/oudbHDODpSQ)
 
## 기술 스택 💻
<img src="https://img.shields.io/badge/Unity-FFFFFF?style=for-the-badge&logo=Unity&logoColor=black">
<img src="https://img.shields.io/badge/csharp-512BD4?style=for-the-badge&logo=csharp&logoColor=white">

## 구현 내용

### Json을 활용한 데이터 관리
```{cpp}
public class JsonManager
{
    public void Save<T>(T data, string name = null)
    {
        //안드로이드에서의 저장 위치를 다르게 해주어야 한다
        //Application.dataPath를 이용하면 어디로 가는지는 구글링 해보길 바란다
        //안드로이드의 경우에는 데이터조작을 막기위해 2진데이터로 변환을 해야한다
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name + ".json";
        }
#if UNITY_EDITOR_WIN // Window에서의 에디터 코드용 #define 지시어
        string savePath = Application.dataPath;
#endif
#if UNITY_ANDROID // Android 플랫폼을 위한 #define 지시어
        string savePath = Application.persistentDataPath;
#endif
        string appender = $"/userData/{name}";

        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        string jsonText = JsonUtility.ToJson(data, true);
        //이러면은 일단 데이터가 텍스트로 변환이 된다
        //jsonUtility를 이용하여 data인 T를 json형식의 text로 바꾸어준다
        //파일스트림을 이렇게 지정해주고 저장해주면된당 끗
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }
    public T Load<T>(string name = null) where T : new()
    {
        T data;
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name + ".json";
        }
#if UNITY_EDITOR_WIN // Window에서의 에디터 코드용 #define 지시어
        string loadPath = Application.dataPath; // 프로젝트 폴더 내부(Asset)
#endif
#if UNITY_ANDROID // Android 플랫폼을 위한 #define 지시어
        string loadPath = Application.persistentDataPath; // /mnt/sdcard/Android/data/번들이름/files
#endif
        string directory = "/userData";
        string appender = $"/{name}";

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
            data = JsonUtility.FromJson<T>(jsonData);
        }
        else
        {
            TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{typeof(T).Name}");
            Debug.Log(textAsset.text);
            data = JsonUtility.FromJson<T>(textAsset.text);
            Save<T>(data);
        }
        return data;
        //이 정보를 게임매니저나, 로딩으로 넘겨주는 것이당
    }
}
```
