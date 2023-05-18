using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCreater : MonoBehaviour
{
    public AnalyzeExample analyzeExample;
    public List<GameObject> myGameObject;
    public Transform transformParent;
    public int slowIndex = 15;
    public int fastIndex = 15 + 6;
    // Start is called before the first frame update
    private void CreateObject(GameObject gameObject, string name, Vector3 vector3) // ���ӿ�����Ʈ �����ϴ� �Լ�
    {
        GameObject obj = Instantiate(gameObject, vector3, Quaternion.identity, transformParent);
        obj.name = name;
    }

    public void Start()
    {
        for( int i = 0; i <= analyzeExample.beats.Count + (fastIndex - slowIndex); i++)
        {
            if (i == slowIndex)
            {
                CreateObject(myGameObject[2], "slow", new Vector3(i, 0.6f, 0));
            }
            else if (i == fastIndex) 
            {
                CreateObject(myGameObject[3], "fast", new Vector3(i, 0.6f, 0));
            }
            CreateObject(myGameObject[0], i.ToString(), new Vector3(i, 0, 0)); //��Ʈ ������ŭ �ٴڸ���
        }
        //CreateObject(myGameObject[1], "flag", new Vector3((int)analyzeExample.beats.Count / 2, 0.6f, 0)); // ���̺�����Ʈ?
    }


    // Update is called once per frame
    void Update()
    {
    }
}
